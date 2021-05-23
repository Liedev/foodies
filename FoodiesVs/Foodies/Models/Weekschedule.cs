using System;
using System.Collections.Generic;

namespace Foodies.Models
{
    public class Weekschedule
    {
        public int WeekscheduleId { get; set; }
        public int Week { get; set; }
        public string Day { get; set; }
        public DateTime Date { get; set; }
        public ICollection<MealWeekScheduleUser> MealWeekScheduleUsers { get; set; }
    }
}
