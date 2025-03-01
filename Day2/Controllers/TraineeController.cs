using Day2.Models;
using Day2.VewModel;
using Institute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
namespace Day2.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ITraineeRepository _traineeRepository;
        public TraineeController(ITraineeRepository trainee)
        {
            _traineeRepository = trainee;
        }
        public IActionResult Index()
        {
            var TraineeList = _traineeRepository.GetAll();
            return View("Index", TraineeList);
        }
        public IActionResult IndexVM(int Traineeid, int Courseid)
        {
            var Trainee = _traineeRepository.GetTraineeByIDandCourseID( Traineeid,  Courseid);

            var mapper = MapperConfig.InitializeAutomapper();
            var TraineeVM = mapper.Map<TraineeDetails>(Trainee);

            return View("IndexVM", TraineeVM);
        }
    }
}
