using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using fungoodMVC.Data;
using fungoodMVC.Models;

namespace fungoodMVC.Pages_FoodItems
{
    public class CreateModel : PageModel
    {
        private readonly fungoodMVC.Data.DataContext _context;

        public CreateModel(fungoodMVC.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public FoodItem FoodItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.food_items == null || FoodItem == null)
            {
                return Page();
            }

            _context.food_items.Add(FoodItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
