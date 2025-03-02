using Day2.Models;
using Day2.VewModel;
using Institute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
namespace Day2.Controllers
{
    public class InstructorController : Controller
    {
        #region Fields&ctor 

        private readonly IWebHostEnvironment _env;

        private readonly IInstructorRepository _instructorRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICourseRepository _courseRepository;

        public InstructorController(IWebHostEnvironment env,
                                     IInstructorRepository instRepo,
                                     IDepartmentRepository departmentRepo,
                                     ICourseRepository courseRepository)
        {
            _env = env;
            _instructorRepository = instRepo;
            _departmentRepository = departmentRepo;
            _courseRepository = courseRepository;
        }

        #endregion

        public IActionResult Index()
        {
            var Instructor = _instructorRepository.GetAll();

            return View("Index", Instructor);
        }

        public IActionResult IndexDetails(int id)
        {
            var Instructor = _instructorRepository.GetByID(id);

            if (Instructor == null) return NotFound("Instructor not found.");

            return View("IndexDetails", Instructor);
        }

        public IActionResult New()
        {

            var InsMV = new InstructorVM();
            InsMV.Department = (List<Department>)_departmentRepository.GetAll();
            InsMV.courses = (List<Course>)_courseRepository.GetAll();

            return View("NewInst", InsMV);
        }

        public IActionResult CourseByDeptID(int deptid)
        {

            var crs = _departmentRepository.GetCoursesInDepartment(deptid);

            return Json(crs);
        }

        [HttpPost]
        public async Task<IActionResult> NewInst(Instructor ins, IFormFile Image)
        {

            if (ins.Name != null)
            {
                if (Image != null)
                {
                    var uploadsFolder = Path.Combine(_env.WebRootPath, "Images");

                    var filePath = Path.Combine(uploadsFolder, Image.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await Image.CopyToAsync(fileStream);
                    }
                }
                ins.Image = Image?.FileName;
                _instructorRepository.Add(ins);
                _instructorRepository.Save();
                return RedirectToAction("Index");
            }

            var mapper = MapperConfig.InitializeAutomapper();
            var INSVM = mapper.Map<InstructorVM>(ins);
            INSVM.Department = (List<Department>)_departmentRepository.GetAll();
            INSVM.courses = (List<Course>)_courseRepository.GetAll();

            return View("NewInst", INSVM);
        }
    }
}
