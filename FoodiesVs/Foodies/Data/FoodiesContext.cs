using Foodies.Areas.Identity.Data;
using Foodies.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Foodies.Data
{
    public class FoodiesContext : IdentityDbContext<ApplicationUser>
    {
        public FoodiesContext(DbContextOptions<FoodiesContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<FavoriteMeal> FavoriteMeals { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<LevelPreperation> LevelPreperations { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealCategory> MealCategories { get; set; }
        public DbSet<MealIngredient> MealIngredients { get; set; }
        public DbSet<MealWeekScheduleUser> MealWeekScheduleUsers { get; set; }
        public DbSet<PreperationTime> PreperationTimes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Shoppinglist> Shoppinglists { get; set; }
        public DbSet<ShoppinglistIngredient> ShoppinglistIngredients { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<EndUser> EndUsers { get; set; }
        public DbSet<UserShoppinglist> UserShoppinglists { get; set; }
        public DbSet<Weekschedule> Weekschedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Foodies");
            base.OnModelCreating(modelBuilder);
            #region Category
            modelBuilder.Entity<Category>()
                .ToTable("Category")
                .Property(category => category.Name)
                .IsRequired();
            modelBuilder.Entity<Category>()
                .HasIndex(category => category.Name);
            #endregion
            #region FavoriteMeal
            modelBuilder.Entity<FavoriteMeal>()
                .ToTable("FavoriteMeal");
            #endregion
            #region Ingredient
            modelBuilder.Entity<Ingredient>()
                .ToTable("Ingredient")
                .Property(ingredient => ingredient.Name)
                .HasMaxLength(150)
                .IsRequired();
            modelBuilder.Entity<Ingredient>()
                .HasIndex(ingredient => ingredient.Name)
                .IsUnique();
            modelBuilder.Entity<Ingredient>()
                .Property(ingredient => ingredient.EnergyKcal)
                .IsRequired();
            modelBuilder.Entity<Ingredient>()
                .Property(ingredient => ingredient.Water)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Ingredient>()
                .Property(ingredient => ingredient.EggWhite)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Ingredient>()
                .Property(ingredient => ingredient.Carbohydrates)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Ingredient>()
                .Property(ingredient => ingredient.Sugar)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Ingredient>()
                .Property(ingredient => ingredient.Fat)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Ingredient>()
                .Property(ingredient => ingredient.SaturatedFat)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Ingredient>()
                .Property(ingredient => ingredient.SingleSaturatedFat)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Ingredient>()
                .Property(ingredient => ingredient.MultiSaturatedFat)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Ingredient>()
                .Property(ingredient => ingredient.Cholesterol)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Ingredient>()
                .Property(ingredient => ingredient.Fiber)
                .HasColumnType("decimal(18,2)");
            #endregion
            #region Levelpreperation
            modelBuilder.Entity<LevelPreperation>()
                .ToTable("LevelPreperation")
                .Property(levelPreperation => levelPreperation.Level)
                .IsRequired();
            #endregion
            #region Meal
            modelBuilder.Entity<Meal>()
                .ToTable("Meal")
                .Property(meal => meal.Name)
                .IsRequired();
            modelBuilder.Entity<Meal>()
                .HasIndex(Meal => Meal.Name)
                .IsUnique();
            modelBuilder.Entity<Meal>()
                .Property(meal => meal.ShortDiscription)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<Meal>()
                .Property(meal => meal.PreperationDiscribtion)
                .IsRequired();
            modelBuilder.Entity<Meal>()
                .Property(meal => meal.NumberOfPeople)
                .IsRequired();
            modelBuilder.Entity<Meal>()
                .Property(meal => meal.PictureMeal)
                .IsRequired()
                .HasMaxLength(2083);
            modelBuilder.Entity<Meal>()
                .Property(meal => meal.LevelPreperationId)
                .IsRequired();
            modelBuilder.Entity<Meal>()
                .Property(meal => meal.EndUserId)
                .IsRequired();
            modelBuilder.Entity<Meal>()
                .HasOne(user => user.EndUser)
                .WithMany(meals => meals.Meals)
                .OnDelete(DeleteBehavior.NoAction);//Solving recuring delete because a user can be an admin but also a normal user
            #endregion
            #region MealCategory
            modelBuilder.Entity<MealCategory>()
                .ToTable("MealCategory");
            #endregion
            #region MealIngredient
            modelBuilder.Entity<MealIngredient>()
                .ToTable("MealIngredient")
                .Property(mealIngredient => mealIngredient.Amount)
                .IsRequired();
            #endregion
            #region MealWeekScheduleUser
            modelBuilder.Entity<MealWeekScheduleUser>()
                .ToTable("MealWeekScheduleUser");
            #endregion
            #region PreperationTime
            modelBuilder.Entity<PreperationTime>()
                .ToTable("Preperationtime")
                .Property(preperationTime => preperationTime.RangeMinutes)
                .IsRequired();
            #endregion
            #region Rating
            modelBuilder.Entity<Rating>()
                .ToTable("Rating")
                .Property(rating => rating.Number)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            #endregion
            #region ShoppingList
            modelBuilder.Entity<Shoppinglist>()
                .ToTable("Shoppinglist")
                .Property(shoppinglist => shoppinglist.Name)
                .IsRequired();
            #endregion
            #region ShoppingListIngredient
            modelBuilder.Entity<ShoppinglistIngredient>()
                .ToTable("ShoppinglistIngredient");
            #endregion
            #region Unit
            modelBuilder.Entity<Unit>()
                .ToTable("Unit")
                .Property(unit => unit.Name)
                .IsRequired();
            modelBuilder.Entity<Unit>()
                .HasIndex(unit => unit.Name)
                .IsUnique();
            #endregion
            #region EndUser
            modelBuilder.Entity<EndUser>()
                .ToTable("EndUser")
                .HasIndex(user => user.NickName)
                .IsUnique();
            modelBuilder.Entity<EndUser>()
                .Property(user => user.Name)
                .IsRequired();
            modelBuilder.Entity<EndUser>()
                .Property(user => user.LastName)
                .IsRequired();
            modelBuilder.Entity<EndUser>()
                .Property(user => user.NickName)
                .IsRequired();
            modelBuilder.Entity<EndUser>()
                .Property(user => user.Avatar)
                .HasMaxLength(2083);
            #endregion
            #region UserShoppinglist
            modelBuilder.Entity<UserShoppinglist>()
                .ToTable("UserShoppinglist");
            #endregion
            #region Weekschedule
            modelBuilder.Entity<Weekschedule>()
                .ToTable("Weekschedule")
                .Property(weekschedule => weekschedule.Week)
                .IsRequired();
            modelBuilder.Entity<Weekschedule>()
                .Property(weekschedule => weekschedule.Day)
                .IsRequired();
            modelBuilder.Entity<Weekschedule>()
                .Property(weekschedule => weekschedule.Date)
                .IsRequired()
                .HasColumnType("dateTime");
            #endregion

        }
    }
}
