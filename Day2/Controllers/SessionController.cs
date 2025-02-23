using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult SetSession()
        {
            string name = "Ahmed";
            int age = 20;

            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", age);

            return Content("Data Saved");
        }

        public IActionResult GetSession()
        {
            string name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("Age");

            return Content($"Name: {name} | Age: {age}");
        }
    }

}
