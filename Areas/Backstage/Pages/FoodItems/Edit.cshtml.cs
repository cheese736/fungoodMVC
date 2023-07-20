using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fungoodMVC.Data;
using fungoodMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace fungoodMVC.Areas.Backstage.Pages.FoodItems
{
	[Authorize(Roles = "staff")]
	public class EditModel : PageModel
	{
		private readonly fungoodMVC.Data.DataContext _context;

		public EditModel(fungoodMVC.Data.DataContext context)
		{
			_context = context;
		}

		[BindProperty]
		public FoodItem FoodItem { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.food_items == null)
			{
				return NotFound();
			}

			var fooditem = await _context.food_items.FirstOrDefaultAsync(m => m.Id == id);
			if (fooditem == null)
			{
				return NotFound();
			}
			FoodItem = fooditem;
			ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Name");
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(FoodItem).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!FoodItemExists(FoodItem.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage("./Index");
		}

		private bool FoodItemExists(int id)
		{
			return (_context.food_items?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
