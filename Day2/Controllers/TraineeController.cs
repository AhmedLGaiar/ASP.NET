using Day2.Models;
using Day2.VewModel;
using Day2_Institute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Day2.Controllers
{
    public class TraineeController : Controller
    {
        InstituteContext instituteContext = new InstituteContext();
        public IActionResult Index()
        {
            var TraineeList = instituteContext.Trainee.Include(e => e.Department).ToList();
            return View("Index", TraineeList);
        }
        public IActionResult IndexVM(int Traineeid, int Courseid)
        {
            var Trainee = instituteContext.crsResult.Include(e => e.Trainee)
                .Include(e => e.Course).FirstOrDefault(e => e.TraineeID == Traineeid && e.CourseID == Courseid);

            var mapper = MapperConfig.InitializeAutomapper();
            var TraineeVM = mapper.Map<TraineeDetails>(Trainee);

            return View("IndexVM", TraineeVM);
        }
    }
}
