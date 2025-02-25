using Day2.Models;
using Day2.VewModel;
using Day2_Institute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day2.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public InstructorController(IWebHostEnvironment env)
        {
            _env = env;
        }

        InstituteContext context = new();
        public IActionResult Index()
        {
            var Instructors = context.Instructor.Include(e=>e.Course)
                        .Include(e=>e.Department).ToList();

            return View("Index", Instructors);
        }
        public IActionResult IndexDetails(int id)
        {
            var Instructors = context.Instructor.Include(e=>e.Course)
                        .Include(e=>e.Department).FirstOrDefault(e=>e.ID==id);

            if (Instructors == null) return NotFound("Instructor not found.");

            return View("IndexDetails", Instructors);
        }
        public IActionResult New()
        {

            var InsMV = new InstructorVM();
            InsMV.Departments= context.Department.ToList();
            InsMV.courses= context.Course.ToList();

            return View("NewInst", InsMV);
        }
        [HttpPost]
        public async Task<IActionResult> NewInst(Instructor ins, IFormFile Image)
        {
            
            if (ins.Name != null)
            {
                if (Image != null ) 
                {
                    var uploadsFolder = Path.Combine(_env.WebRootPath, "Images");

                    var filePath = Path.Combine(uploadsFolder, Image.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await Image.CopyToAsync(fileStream);
                    }
                }
                ins.Image = Image?.FileName;
                context.Add(ins);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            var mapper = MapperConfig.InitializeAutomapper();
            var INSVM = mapper.Map<InstructorVM>(ins);
            INSVM.Departments = context.Department.ToList();
            INSVM.courses= context.Course.ToList();

            return View("NewInst", INSVM);
        }
    }
}
