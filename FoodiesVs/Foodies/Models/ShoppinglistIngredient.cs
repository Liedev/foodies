namespace Foodies.Models
{
    public class ShoppinglistIngredient
    {
        public int ShoppinglistIngredientId { get; set; }
        public int ShoppinglistId { get; set; }
        public int MealIngredientId { get; set; }

        public Shoppinglist Shoppinglist { get; set; }
        public MealIngredient MealIngredient { get; set; }


    }
}
