using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Data;
using MealPlanner.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealPlanner.Pages.MealSelection
{
    public class BrowseMealsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BrowseMealsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Meal> Meals { get; set; } = new List<Meal>();
        public List<string> Categories { get; set; } = new List<string>();
        public string SearchTerm { get; set; }
        public string SelectedCategory { get; set; }

        public async Task OnGetAsync(string searchTerm, string category)
        {
            SearchTerm = searchTerm;
            SelectedCategory = category;

            Categories = await _context.Meals
                .Select(m => m.Category)
                .Distinct()
                .ToListAsync();

            IQueryable<Meal> query = _context.Meals;

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                query = query.Where(m => m.Name.Contains(SearchTerm));
            }

            if (!string.IsNullOrEmpty(SelectedCategory))
            {
                query = query.Where(m => m.Category == SelectedCategory);
            }

            Meals = await query.ToListAsync();
        }
    }
}
