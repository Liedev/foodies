using System.Collections.Generic;

namespace Foodies.Models
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string Name { get; set; }
        public ICollection<MealIngredient> MealIngredients { get; set; }
    }
}
