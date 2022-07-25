using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ProjectGroup10.Models;
namespace ProjectGroup10.Controllers
{
    public class HomeController : Controller
    {
        PRN2Context context = new PRN2Context();
        public IActionResult Index()
        {
            var product = context.Products.ToList();
            product = (from p in context.Products
                       where p.Status == 1
                       select p).ToList();
            if (product == null)
                return View();
            return View(product);
            
        }

        [HttpPost]

        public IActionResult Index(string name)
        {
            var product = context.Products.ToList();
            if (name != null)
            {

                product = (from p in context.Products
                           where p.ProductName.Contains(name)
                           select p).ToList();
            }
            return View(product);
        }


}
}
