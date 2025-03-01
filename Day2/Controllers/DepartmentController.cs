using Microsoft.AspNetCore.Mvc;
using Day2.Models;
using Repository;

namespace Day2.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            var DepartmentList= _departmentRepository.GetAll();
            return View("Index", DepartmentList);
        }
    }
}
