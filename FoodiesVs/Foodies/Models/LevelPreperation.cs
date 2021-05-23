using System.Collections.Generic;

namespace Foodies.Models
{
    public class LevelPreperation
    {
        public int LevelPreperationId { get; set; }

        public string Level { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
