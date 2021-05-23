using System.Collections.Generic;

namespace Foodies.Models
{
    public class MealIngredient
    {
        public int MealIngredientId { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int Amount { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public ICollection<ShoppinglistIngredient> ShoppinglistIngredients { get; set; }
    }
}
