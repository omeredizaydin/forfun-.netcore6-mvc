using System.ComponentModel.DataAnnotations;

namespace FoodEcommerceProject.Data.Models
{
    public class Category
    {
        //[Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage ="Category name cannot be empty")]
        [StringLength(20,ErrorMessage ="Category name cannot exceed 20 of length")]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }

        public List<Food> Foods { get; set; }

    }
}
