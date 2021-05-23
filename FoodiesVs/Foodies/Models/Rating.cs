namespace Foodies.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }
        public int MealId { get; set; }
        public decimal Number { get; set; }
        public EndUser EndUser { get; set; }
        public Meal Meal { get; set; }
    }
}
