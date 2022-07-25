using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ProjectGroup10.Models;

namespace ProjectGroup10.Controllers
{
    public class AdminController : Controller
    {
        PRN2Context context = new PRN2Context();
        public IActionResult Index()
        {
            int id = 2;
            //lay ra nhung product co cateid = cateid da chon
            var product = context.Products.ToList();
            if (id != 0)
            {
                product = (from p in context.Products
                           where p.UserId == id
                           select p).ToList();

            }
            return View(product);

        }
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {

            ViewBag.Product = context.Products.Find(id);
            ViewBag.Category = context.Categories.ToList();
            return View();
        }
      
        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (product.ProductName == null || product.Image == null || product.Price == 0 || product.Date.ToString() == "" || product.Detail == null)
                return RedirectToAction("Update");
            context.Products.Update(product);
            context.SaveChanges(true);
            return RedirectToAction("Index");
        }
        public IActionResult Insert()
        {
            ViewBag.cate = context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Product product)
        {
            if (product.ProductName == null || product.Image == null || product.Price == 0 || product.Date.ToString() == "" || product.Detail == null)
                return RedirectToAction("Insert");
            ViewBag.cate = context.Categories.ToList();
            context.Products.Add(product);
            context.SaveChanges(true);
            return View();
        }
    }

}
