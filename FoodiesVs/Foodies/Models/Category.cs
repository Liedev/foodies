using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foodies.Models
{
    //https://entityframework.net/knowledge-base/47960040/entity-framework-recursive-relationship-hierarchical-data
    //recrusive relationship
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Main Category")]
        public int? ParentId { get; set; }
        [Display(Name = "Main Category")]
        public Category Parent { get; set; }

        public ICollection<Category> Childeren { get; set; }

        public ICollection<MealCategory> MealCategories { get; set; }
    }
}
