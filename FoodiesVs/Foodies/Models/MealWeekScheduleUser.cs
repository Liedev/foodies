namespace Foodies.Models
{
    public class MealWeekScheduleUser
    {
        public int MealWeekScheduleUserId { get; set; }
        public int WeekscheduleId { get; set; }
        public int MealId { get; set; }
        public int UserId { get; set; }
        public Weekschedule Weekschedule { get; set; }
        public Meal Meal { get; set; }
        public EndUser EndUser { get; set; }
    }
}
