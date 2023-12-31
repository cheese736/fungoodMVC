using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using fungoodMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace fungoodMVC.Areas.Backstage.Pages.FoodItems
{
	[Authorize(Roles = "staff")]
	public class DetailsModel : PageModel
	{
		private readonly fungoodMVC.Data.DataContext _context;

		public DetailsModel(fungoodMVC.Data.DataContext context)
		{
			_context = context;
		}

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
	}
}
