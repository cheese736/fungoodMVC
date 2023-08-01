using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using fungoodMVC.Models;
using Microsoft.AspNetCore.Authorization;
using fungoodMVC.Helper;

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

			var fooditem = await _context.food_items.Include(f => f.Category).FirstOrDefaultAsync(m => m.Id == id);
			if (fooditem == null)
			{
				return NotFound();
			}
			FoodItem = fooditem;
			var selectList = new SelectList(_context.categories, "Id", "Name");
			selectList.First(c => Int32.Parse(c.Value) == FoodItem.Category.Id).Selected = true;
			ViewData["CategoryId"] = selectList;
			_context.Dispose();
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			FoodItem.Category = await _context.categories.FirstAsync(c => c.Id == FoodItem.CategoryId);
			Dumper.print(FoodItem);
			var entity = _context.Attach(FoodItem);
			entity.State = EntityState.Modified;

			try
			{
				_context.SaveChanges();
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
