namespace Foodies.Models
{
    public class FavoriteMeal
    {
        public int FavoriteMealId { get; set; }
        public int UserId { get; set; }
        public int MealId { get; set; }

        public EndUser User { get; set; }
        public Meal Meal { get; set; }
    }
}
