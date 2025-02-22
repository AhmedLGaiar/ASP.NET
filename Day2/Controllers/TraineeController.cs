using Microsoft.AspNetCore.Mvc;
using Day2_Institute;
using Day2.Models;
using Microsoft.EntityFrameworkCore;
namespace Day2.Controllers
{
    public class TraineeController : Controller
    {
        public IActionResult Index()
        {
            var instituteContext = new InstituteContext();
            var TraineeList = instituteContext.Trainee.Include(e=>e.Department).ToList();
            return View("Index", TraineeList);
        }
    }
}
