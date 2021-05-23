using Foodies.Data.Repository;
using Foodies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoodiesContext _context;
        private IGenericRepository<Category> _categoryRepository;
        private IGenericRepository<Ingredient> _ingredientRepository;

        private IGenericRepository<LevelPreperation> _levelPreperationRepository;

        private IGenericRepository<Meal> _mealRepository;

        private IGenericRepository<PreperationTime> _preperationTimeRepository;

        private IGenericRepository<Rating> _ratingRepository;

        private IGenericRepository<Shoppinglist> _shoppinglistRepository;

        private IGenericRepository<Unit> _unitRepository;

        private IGenericRepository<Weekschedule> _weekscheduleRepository;
        public UnitOfWork(FoodiesContext context)
        {
            _context = context;
        }
        public IGenericRepository<Category> CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                {
                    this._categoryRepository = new GenericRepository<Category>(_context);
                }
                return _categoryRepository;
            }
        }

        public IGenericRepository<Ingredient> IngredientRepository
        {
            get
            {
                if (this._ingredientRepository == null)
                {
                    this._ingredientRepository = new GenericRepository<Ingredient>(_context);
                }
                return _ingredientRepository;
            }
        }

        public IGenericRepository<LevelPreperation> LevelPreperationRepository
        {
            get
            {
                if (this._levelPreperationRepository == null)
                {
                    this._levelPreperationRepository = new GenericRepository<LevelPreperation>(_context);
                }
                return _levelPreperationRepository;
            }
        }

        public IGenericRepository<Meal> MealRepository
        {
            get
            {
                if (this._mealRepository == null)
                {
                    this._mealRepository = new GenericRepository<Meal>(_context);
                }
                return _mealRepository;
            }
        }

        public IGenericRepository<PreperationTime> PreperationTimeRepository
        {
            get
            {
                if (this._preperationTimeRepository == null)
                {
                    this._preperationTimeRepository = new GenericRepository<PreperationTime>(_context);
                }
                return _preperationTimeRepository;
            }
        }

        public IGenericRepository<Rating> RatingRepository
        {
            get
            {
                if (this._ratingRepository == null)
                {
                    this._ratingRepository = new GenericRepository<Rating>(_context);
                }
                return _ratingRepository;
            }
        }

        public IGenericRepository<Shoppinglist> ShoppinglistRepository
        {
            get
            {
                if (this._shoppinglistRepository == null)
                {
                    this._shoppinglistRepository = new GenericRepository<Shoppinglist>(_context);
                }
                return _shoppinglistRepository;
            }
        }

        public IGenericRepository<Unit> UnitRepository
        {
            get
            {
                if (this._unitRepository == null)
                {
                    this._unitRepository = new GenericRepository<Unit>(_context);
                }
                return _unitRepository;
            }
        }

        public IGenericRepository<Weekschedule> WeekscheduleRepository
        {
            get
            {
                if (this._weekscheduleRepository == null)
                {
                    this._weekscheduleRepository = new GenericRepository<Weekschedule>(_context);
                }
                return _weekscheduleRepository;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
