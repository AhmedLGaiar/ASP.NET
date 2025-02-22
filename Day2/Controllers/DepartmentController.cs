using Microsoft.AspNetCore.Mvc;
using Day2.Models;

namespace Day2.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            var instituteContext = new InstituteContext();
          var DepartmentList=  instituteContext.Department.ToList();
            return View("Index", DepartmentList);
        }
    }
}
