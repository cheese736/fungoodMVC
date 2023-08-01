using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using fungoodMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace fungoodMVC.Areas.Backstage.Pages.FoodItems
{
	[Authorize(Roles = "staff")]
	public class DeleteModel : PageModel
	{
		private readonly DataContext _context;

		public DeleteModel(DataContext context)
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

			var fooditem = await _context.food_items
			.Include(f => f.Category)
			.FirstOrDefaultAsync(m => m.Id == id);

			if (fooditem == null)
			{
				return NotFound();
			}
			else
			{
				FoodItem = fooditem;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.food_items == null)
			{
				return NotFound();
			}
			var fooditem = await _context.food_items.FindAsync(id);

			if (fooditem != null)
			{
				FoodItem = fooditem;
				_context.food_items.Remove(FoodItem);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}
