using Foodies.Areas.Identity.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foodies.Models
{
    public class EndUser
    {
        public int EndUserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; }
        public ICollection<UserShoppinglist> UserShoppinglists { get; set; }
        public ICollection<MealWeekScheduleUser> MealWeekScheduleUsers { get; set; }
        public ICollection<FavoriteMeal> FavoriteMeals { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Meal> Meals { get; set; }

    }
}
