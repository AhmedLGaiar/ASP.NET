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
            List<TraineeDetails> TraineeListVM = new List<TraineeDetails>();

            foreach (var trinee in Trainees)
            {
                var trineess = new TraineeDetails();
                trineess.TName = trinee.Trainee.Name;
                trineess.Degree = trinee.Degree;
                trineess.CName = trinee.Course.Name;
                TraineeListVM.Add(trineess);
            }

            return View("AllTrainee", TraineeListVM);
        }
    }
}
