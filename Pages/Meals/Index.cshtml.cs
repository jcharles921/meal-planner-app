﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Data;
using MealPlanner.Models;

namespace MealPlanner.Pages.Meals
{
    public class IndexModel : PageModel
    {
        private readonly MealPlanner.Data.ApplicationDbContext _context;

        public IndexModel(MealPlanner.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Meal> Meal { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Meal = await _context.Meals.ToListAsync();
        }
    }
}
