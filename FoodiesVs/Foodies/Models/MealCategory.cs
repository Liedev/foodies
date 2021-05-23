namespace Foodies.Models
{
    public class MealCategory
    {
        public int MealCategoryId { get; set; }
        public int MealId { get; set; }
        public int CategoryId { get; set; }
        public Meal Meal { get; set; }
        public Category Category { get; set; }
    }
}
