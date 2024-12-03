using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MealPlanner.Data;
using MealPlanner.Models;
using System.Threading.Tasks;

namespace MealPlanner.Pages.MealSelection
{
    [Authorize]
    public class MealDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public MealDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Meal Meal { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Meal = await _context.Meals.FindAsync(id);

            if (Meal == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
