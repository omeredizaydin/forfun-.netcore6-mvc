using FoodEcommerceProject.Data.Models;
using FoodEcommerceProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace FoodEcommerceProject.Controllers
{
    public class FoodController : Controller
    {
        public FoodRepository foodRepository = new FoodRepository();
        Context c = new Context();
        public IActionResult Index(int page=1)
        {

            return View(foodRepository.TList("Category").ToPagedList(page,3));
        }

        [HttpGet]
        public IActionResult AddFood()
        {
            // dropdown's elements
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddFood(Food food)
        {
            foodRepository. TAdd(food);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteFood(int id)
        {
            foodRepository.TDelete(new Food { FoodID=id});
            return RedirectToAction("Index");
        }

        // it shows food names with respect to their id. What we've intended to here is list items with their names and whenever it's selected
        // it is going to hold id of the related item.
        public IActionResult GetFood(int id)
        {

            List<SelectListItem> values = (from kk in c.Categories.ToList()
                                           select new SelectListItem
                                           {    
                                               Text = kk.CategoryName,
                                               Value = kk.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;

            var x = foodRepository.TGet(id);
            Food food = new Food()
            {
                FoodID = x.FoodID,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                ImageURL = x.ImageURL,
                Stock = x.Stock,
                CategoryID = x.CategoryID
            };
            return View(x);    

            
        }
        [HttpPost]
        public IActionResult UpdateFood(Food food)
        {
            var x = foodRepository.TGet(food.FoodID);
            x.Name = food.Name;
            x.Description= food.Description;
            x.Price = food.Price;
            x.ImageURL = food.ImageURL;
            x.Stock= food.Stock;
            x.CategoryID = food.CategoryID;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
