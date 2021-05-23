using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foodies.Models
{
    public class Ingredient
    {
        //https://stackoverflow.com/questions/10710393/nullable-property-to-entity-field-entity-framework-through-code-first/10710934
        // Code first nullable and requered
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public int EnergyKcal { get; set; }
        public int? EnergyKj { get; set; }
        public decimal? Water { get; set; }
        public decimal? EggWhite { get; set; }
        public decimal? Carbohydrates { get; set; }
        public decimal? Sugar { get; set; }
        public decimal? Fat { get; set; }
        [Display(Name = "Saturated Fat")]
        public decimal? SaturatedFat { get; set; }
        [Display(Name = " Single Saturated Fat")]
        public decimal? SingleSaturatedFat { get; set; }
        [Display(Name = "Multi Saturated Fat")]
        public decimal? MultiSaturatedFat { get; set; }
        public decimal? Cholesterol { get; set; }
        public decimal? Fiber { get; set; }

        public ICollection<MealIngredient> MealIngredients { get; set; }
    }
}
