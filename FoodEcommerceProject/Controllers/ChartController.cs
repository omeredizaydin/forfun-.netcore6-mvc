using FoodEcommerceProject.Data;
using FoodEcommerceProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodEcommerceProject.Controllers
{

    [AllowAnonymous]

    public class ChartController : Controller
    {

        //Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }

        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();  
            cs.Add(new Class1(){
                proname="Computer",
                stock=150
            });
            cs.Add(new Class1() { 
                proname="LCD",
                stock=75
            });

            cs.Add(new Class1()
            {
                proname="USB Device",
                stock=220
            });
            return cs;
        }
    
        
        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }


        public List<Class2> FoodList()
        {
            List<Class2> cs2 = new List<Class2>();
            using (var c = new Context())
            {
                cs2 = c.Foods.Select(x => new Class2
                {
                    foodname = x.Name,
                    stock = x.Stock
                }).ToList();

            }
        
            return cs2;
        }
        public IActionResult Statistics() 
        {
            Context c = new Context();
            

            var val1 = c.Foods.Count();
            ViewBag.totalFood = val1;

            var val2 = c.Categories.Count();
            ViewBag.sumcategories = val2;


            var foodID = c.Categories.Where(x => x.CategoryName == "Fruits").Select(y => y.CategoryID).FirstOrDefault();

            var val3 = c.Foods.Where(x => x.CategoryID == foodID).Count();
            ViewBag.fruitCount = val3;

            var vegetableID = c.Categories.Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault();

            var val4 = c.Foods.Where(x => x.CategoryID == vegetableID).Count();
            ViewBag.vegetablesCount = val4;

            var val5 = c.Foods.Sum(x => x.Stock);
            ViewBag.sumfood = val5;

            

            var Legumes = c.Categories.Where(x => x.CategoryName == "Legumes").Select(y => y.CategoryID).FirstOrDefault();
            var val6 = c.Foods.Where(x => x.CategoryID == Legumes).Count();
            ViewBag.legumesCount = val6;


            var val88 = c.Foods.Max(x => x.Stock);

           /* var val7 = c.Foods.Where(x => x.Stock == val88).Select(y => y.CategoryID).FirstOrDefault();
            ViewBag.maxStockCategory = val7;*/


            var val77 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.maxFood = val77;


            var val78 = c.Foods.OrderBy(x => x.Stock).Select(y=>y.Name).FirstOrDefault();
            ViewBag.minFood = val78;




            /* var val8 = c.Foods.Average(x => x.Price);
             val8 = Math.Round(val8, 2);
             ViewBag.averagePrice = val8.ToString()+" ₺";
            */

            var valFoodAvg = c.Foods.Average(x => x.Price);
            //var calculated = Math.Round(valFoodAvg / val3, 2);
            ViewBag.foodAvgPrice = Math.Round(valFoodAvg,2).ToString()+" ₺";


            var val10 = c.Categories.Where(x => x.CategoryName == "Fruits").Select(y => y.CategoryID).FirstOrDefault();

            var val10p = c.Foods.Where(x => x.CategoryID == val10).Sum(y => y.Stock);

            ViewBag.d10= val10p;


            var totalVeg = c.Categories.Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault();

            var totalVegVal = c.Foods.Where(x=>x.CategoryID==totalVeg).Sum(y => y.Stock);
            ViewBag.d11 = totalVegVal;

            var maxPriceFoodName = c.Foods.OrderByDescending(x => x.Price).Select(y=>y.Name).FirstOrDefault();
            var maxPriceFoodPrice = c.Foods.OrderByDescending(x => x.Price).Select(y => y.Price).FirstOrDefault();

            ViewBag.maxPriceFood = maxPriceFoodName.ToString()+" ("+maxPriceFoodPrice+" ₺)";


            return View(); 
        }


    }
}
