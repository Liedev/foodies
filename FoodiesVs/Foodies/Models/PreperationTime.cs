using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foodies.Models
{
    public class PreperationTime
    {
        public int PreperationTimeId { get; set; }
        [Display(Name = "Range of Minutes")]
        public string RangeMinutes { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
