using FoodEcommerceProject.Data.Models;

namespace FoodEcommerceProject.Repositories
{
    public class FoodRepository:GenericRepository<Food>
    {
       /* Context c = new Context();

        public  List<Food> FoodList()
        {
            return c.Foods.ToList();
        }
        public void FoodAdd(Food food)
        {
            c.Foods.Add(food);
            c.SaveChanges();
        }

        public void FoodDelete(Food food)
        {
            c.Foods.Remove(food);
            c.SaveChanges();
        }
        public void FoodUpdate(Food food)
        {
            c.Foods.Update(food);
            c.SaveChanges();
        }
        public void GetFood(int id)
        {
            c.Foods.Find(id);
            //c.SaveChanges();
        }*/

    }
}
