using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foodies.Models
{
    public class Meal
    {
        public int MealId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Short Description")]
        public string ShortDiscription { get; set; }
        [Display(Name = "Preperation Describtion")]
        public string PreperationDiscribtion { get; set; }
        [Display(Name = "Number of people")]
        public int NumberOfPeople { get; set; }
        [Display(Name = "Level of preperation")]
        public int LevelPreperationId { get; set; }
        [Display(Name = "Time of preperation")]
        public int PreperationTimeId { get; set; }
        [Display(Name = "Meal picture")]
        public string PictureMeal { get; set; }

        [Display(Name = "Meal Creator")]
        public int EndUserId { get; set; }
        public LevelPreperation LevelPreperation { get; set; }
        public PreperationTime PreperationTime { get; set; }
        public EndUser EndUser { get; set; }
        public List<MealCategory> MealCategories { get; set; }
        public ICollection<MealIngredient> MealIngredients { get; set; }
        public ICollection<FavoriteMeal> FavoriteMeals { get; set; }
        public ICollection<MealWeekScheduleUser> MealWeekScheduleUsers { get; set; }
        public ICollection<Rating> Ratings { get; set; }

    }
}
