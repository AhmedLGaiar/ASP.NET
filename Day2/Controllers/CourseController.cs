using Day2.Models;
using Day2.VewModel;
using Day2_Institute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day2.Controllers
{
    public class CourseController : Controller
    {
        InstituteContext Context = new InstituteContext();

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
            var exists = Context.Department.Any(d => d.ID == DepartmentID);

            if (exists)
                return Json(true);
            else
                return Json(false);
        }
        #endregion

        #region Actions

        public IActionResult AllTrainee()
        {
            List<crsResult> Trainees = Context.crsResult.Include(e => e.Trainee)
                                        .Include(e => e.Course).ToList();

            var mapper = MapperConfig.InitializeAutomapper();

            var TraineeListVM = mapper.Map<List<TraineeDetails>>(Trainees);

            return View("AllTrainee", TraineeListVM);
        }

        public IActionResult AllCourses()
        {
            List<Course> courses = Context.Course.Include(e => e.Department).ToList();

            return View("AllCourses", courses);
        }

        public IActionResult New()
        {
            var InsMV = new CourseVM();
            InsMV.DepartmentsList = Context.Department.ToList();
            if (InsMV.DepartmentsList is null) return Content("Error");
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
                    Context.Add(courseVM1);
                    Context.SaveChanges();
                    return RedirectToAction("AllCourses");
                }
                catch (Exception msg)
                {
                    ModelState.AddModelError(string.Empty, msg.InnerException.Message);
                }

            }

            var mapper = MapperConfig.InitializeAutomapper();
            var courseVM = mapper.Map<CourseVM>(Crs);
            courseVM.DepartmentsList = Context.Department.ToList();

            return View("New", courseVM);
        }

        #endregion

    }
}
