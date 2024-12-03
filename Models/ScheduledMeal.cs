namespace MealPlanner.Models
{
    public class ScheduledMeal
    {
        public int ID { get; set; }
        public string Day { get; set; }
        public int MealID { get; set; }
        public Meal Meal { get; set; }
    }
}
