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
        public async Task<IActionResult> NewCrs(Course Crs)
        {

            if (Crs.Name != null)
            {
                Context.Add(Crs);
                Context.SaveChanges();
                return RedirectToAction("AllCourses");
            }

            var mapper = MapperConfig.InitializeAutomapper();
            var courseVM = mapper.Map<CourseVM>(Crs);
            courseVM.DepartmentsList = Context.Department.ToList();

            return View("New", courseVM);
        }
    }
}
