namespace MealPlanner.Models
{
    public class CalendarMeal
    {
        public int CalendarMealID { get; set; }
        public int CalendarID { get; set; }
        public int MealID { get; set; }
        public DateTime MealDate { get; set; }
        public string MealTime { get; set; }
    }
}
