using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MealPlanner.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Pages.MealSelection
{
    [Authorize]
    public class ShoppingListModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ShoppingListModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<string> ShoppingItems { get; set; } = new();

        public void OnGet()
        {
            var scheduledMeals = _context.ScheduledMeals
                .Include(sm => sm.Meal)
                .Select(sm => sm.Meal)
                .ToList();

            ShoppingItems = scheduledMeals
                .SelectMany(meal => meal.Ingredients?.Split(',') ?? Enumerable.Empty<string>())
                .Select(ingredient => ingredient.Trim())
                .Distinct()
                .OrderBy(item => item)
                .ToList();
        }

        public IActionResult OnPostExport()
        {
            OnGet();

            var textContent = new StringBuilder();
            textContent.AppendLine("Shopping List");
            textContent.AppendLine(new string('-', 20));

            if (ShoppingItems.Any())
            {
                foreach (var item in ShoppingItems)
                {
                    textContent.AppendLine(item);
                }
            }
            else
            {
                textContent.AppendLine("No items found.");
            }

            var fileBytes = Encoding.UTF8.GetBytes(textContent.ToString());
            return File(fileBytes, "text/plain", "ShoppingList.txt");
        }
    }
}
