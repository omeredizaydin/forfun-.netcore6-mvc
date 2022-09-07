using FoodEcommerceProject.Data.Models;
using FoodEcommerceProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodEcommerceProject.Controllers
{
    public class CategoryController : Controller
    {

        //Context c = new Context();
        public CategoryRepository categoryRepository = new CategoryRepository();

        //[Authorize]
        public IActionResult Index()
        {
            return View(categoryRepository.TList());
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
           return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {


           
            categoryRepository.TAdd(p);
            //there is no save changes;

            return RedirectToAction("Index");
        }
        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepository.TGet(id);
            Category ct = new Category()
            {
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription,
                CategoryID = x.CategoryID
            };


            return View(ct);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category category)
        {
            var x = categoryRepository.TGet(category.CategoryID);
            //x.CategoryID = category.CategoryID;
            x.CategoryName = category.CategoryName;
            x.CategoryDescription = category.CategoryDescription;
            x.Status = true;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryDelete(int id)
        {
            var x = categoryRepository.TGet(id);
            x.Status = false;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
