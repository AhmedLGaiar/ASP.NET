using Day2.Models;
using Day2.VewModel;
using Day2_Institute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day2.Controllers
{
    public class CourseController : Controller
    {
        InstituteContext instituteContext = new InstituteContext();

        public IActionResult AllTrainee()
        {
            List<crsResult> Trainees = instituteContext.crsResult.Include(e => e.Trainee)
                                        .Include(e => e.Course).ToList();

            var mapper = MapperConfig.InitializeAutomapper();

            var TraineeListVM = mapper.Map<List<TraineeDetails>>(Trainees);

            return View("AllTrainee", TraineeListVM);
        }
    }
}
