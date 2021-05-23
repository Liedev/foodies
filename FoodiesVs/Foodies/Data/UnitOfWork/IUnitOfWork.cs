using Foodies.Data.Repository;
using Foodies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<Ingredient> IngredientRepository { get; }
        IGenericRepository<LevelPreperation> LevelPreperationRepository { get; }
        IGenericRepository<Meal> MealRepository { get; }
        IGenericRepository<PreperationTime> PreperationTimeRepository { get; }
        IGenericRepository<Rating> RatingRepository { get; }
        IGenericRepository<Shoppinglist> ShoppinglistRepository { get; }
        IGenericRepository<Unit> UnitRepository { get; }
        IGenericRepository<Weekschedule> WeekscheduleRepository { get; }
        Task Save();
    }
}
