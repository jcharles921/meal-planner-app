namespace MealPlanner.Models
{
    public class MealPlan
    {
        public int MealPlanID { get; set; }
        public int UserID { get; set; }
        public int MealID { get; set; }
        public DateTime MealDate { get; set; }
        public string MealTime { get; set; }
    }
}
