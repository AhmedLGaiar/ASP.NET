using Day1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    public class ProductsController : Controller
    {
         ProductsBL ProductsBL = new ProductsBL();
        public IActionResult All()
        {
           List<Products> Product_List= ProductsBL.GetAll();
            return View("Products", Product_List);
        }
        public IActionResult Details(int id)
        {
            Products Product = ProductsBL.GetByID(id);
            return View("Details", Product);
        }
    }
}
