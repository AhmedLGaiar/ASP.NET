using Day2.Models;
using Day2.VewModel;
using Institute;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Day2.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public CourseController(IDepartmentRepository departmentRepo,
                             ICourseRepository courseRepo)
        {
            _courseRepository = courseRepo;
            _departmentRepository = departmentRepo;
        }

        #region Remote Validation
        public IActionResult CheckMinDegree(byte MinDegree, byte Degree)
        {
            if (MinDegree < Degree)
                return Json(true);
            else
                return Json(false);
        }

        public IActionResult Modules_by_3(byte Hours)
        {
            if (Hours % 3 == 0)
                return Json(true);
            else
                return Json(false);
        }

        public IActionResult ISValidDepartmentID(int DepartmentID)
        {
            var exists = _departmentRepository.GetByID(DepartmentID);

            if (exists != null)
                return Json(true);
            else
                return Json(false);
        }
        #endregion

        #region Actions

        public IActionResult AllTrainee()
        {
            var Trainee = _courseRepository.GetAllTraineeWithCourses().ToList();

            var mapper = MapperConfig.InitializeAutomapper();

            var TraineeListVM = mapper.Map<List<TraineeDetails>>(Trainee);

            return View("AllTrainee", TraineeListVM);
        }

        public IActionResult AllCourses()
        {
            var courses = _courseRepository.GetAll();

            return View("AllCourses", courses);
        }

        public IActionResult New()
        {
            var InsMV = new CourseVM();
            InsMV.DepartmentList = (List<Department>)_departmentRepository.GetAll();
            if (InsMV.DepartmentList is null) return Content("Error");
            return View("New", InsMV);
        }

        [HttpPost]
        public async Task<IActionResult> NewCrs(CourseVM Crs)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var mapper1 = MapperConfig.InitializeAutomapper();
                    var courseVM1 = mapper1.Map<Course>(Crs);
                    _courseRepository.Add(courseVM1);
                    _courseRepository.Save();
                    return RedirectToAction("AllCourses");
                }
                catch (Exception msg)
                {
                    ModelState.AddModelError(string.Empty, msg.InnerException.Message);
                }

            }

            var mapper = MapperConfig.InitializeAutomapper();
            var courseVM = mapper.Map<CourseVM>(Crs);
            courseVM.DepartmentList = (List<Department>)_departmentRepository.GetAll();

            return View("New", courseVM);
        }

        #endregion

    }
}
