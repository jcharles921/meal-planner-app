namespace MealPlanner.Models
{
    public class Meal
    {
        public int MealID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Instructions { get; set; }
        public string Ingredients { get; set; }
        public string NutritionInfo { get; set; }
    }
}
