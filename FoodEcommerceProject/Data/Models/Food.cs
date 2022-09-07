using System.ComponentModel.DataAnnotations;

namespace FoodEcommerceProject.Data.Models
{
    public class Food
    {
        //[Key]
        public int FoodID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public string LongDescription { get; set; }
        public double Price { get; set; }
        public string ImageURL {get; set; }
        //public string ThumbNailImageURL {get; set; } // small size before bigger one.
        public int Stock {get; set; }
        public int CategoryID { get; set; }


        public virtual Category Category { get; set; }
    }
}
