using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ProjectGroup10.Models;

namespace ProjectGroup10.Controllers


{
    public class CategoryController : Controller
    {
        PRN2Context context = new PRN2Context();
        public IActionResult Index()
        {
            int id = 2;
            //lay ra nhung product co cateid = cateid da chon
            var category = context.Categories.ToList();
            if (id != 0)
            {
                category = (from p in context.Categories
                          
                           select p).ToList();

            }
            return View(category);


        }
        public IActionResult Insert()
        {
            ViewBag.cate = context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Category category)
        {
            if (category.CategoryName == null )
                return RedirectToAction("Insert");
            ViewBag.cate = context.Categories.ToList();
            context.Categories.Add(category);
            context.SaveChanges(true);
            return View();
        }
        public IActionResult Update(int id)
        {

            ViewBag.Category = context.Categories.Find(id);
   
            return View();
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (category.CategoryName == null )
                return RedirectToAction("Update");
            context.Categories.Update(category);
            context.SaveChanges(true);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
