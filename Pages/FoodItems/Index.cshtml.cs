using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using fungoodMVC.Data;
using fungoodMVC.Models;
using fungoodMVC.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace fungoodMVC.Pages_FoodItems
{
    [Authorize(Roles = "staff")]
    public class IndexModel : PageModel
    {
        private readonly fungoodMVC.Data.DataContext _context;

        public IndexModel(fungoodMVC.Data.DataContext context)
        {
            _context = context;
        }

        public IList<FoodItem> FoodItem { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.food_items != null)
            {
                FoodItem = await _context.food_items
                .Include(f => f.category).ToListAsync();
            }
        }
    }
}
