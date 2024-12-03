using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MealPlanner.Data;
using MealPlanner.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Pages.MealSelection
{
    public class WeeklyCalendarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public WeeklyCalendarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<string> DaysOfWeek { get; } = new List<string>
        {
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
        };

        public Dictionary<string, List<Meal>> Calendar { get; set; } = new();

        public List<Meal> AvailableMeals { get; set; } = new();

        public void OnGet()
        {
            foreach (var day in DaysOfWeek)
            {
                Calendar[day] = new List<Meal>();
            }

            var scheduledMeals = _context.ScheduledMeals
                .Include(sm => sm.Meal)
                .ToList();

            // Populate calendar with scheduled meals
            foreach (var scheduledMeal in scheduledMeals)
            {
                if (Calendar.ContainsKey(scheduledMeal.Day))
                {
                    Calendar[scheduledMeal.Day].Add(scheduledMeal.Meal);
                }
            }

            // Retrieve available meals from the database
            AvailableMeals = _context.Meals.ToList();
        }

        public async Task<IActionResult> OnPostAsync([FromBody] List<ScheduleInput> schedule)
        {
            if (schedule == null || !schedule.Any())
            {
                return BadRequest("Invalid schedule data.");
            }

            // Clear existing schedules
            var existingSchedules = _context.ScheduledMeals.ToList();
            _context.ScheduledMeals.RemoveRange(existingSchedules);

            // Add new schedules
            foreach (var item in schedule)
            {
                foreach (var mealId in item.Meals)
                {
                    var scheduledMeal = new ScheduledMeal
                    {
                        Day = item.Day,
                        MealID = int.Parse(mealId)
                    };
                    _context.ScheduledMeals.Add(scheduledMeal);
                }
            }

            await _context.SaveChangesAsync();
            return new JsonResult(new { success = true });
        }

        public List<Meal> GetMealsForDay(string day)
        {
            return Calendar.ContainsKey(day) ? Calendar[day] : new List<Meal>();
        }

        public class ScheduleInput
        {
            public string Day { get; set; }
            public List<string> Meals { get; set; }
        }
    }
}