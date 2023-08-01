using Microsoft.AspNetCore.Mvc.RazorPages;
using fungoodMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace fungoodMVC.Areas.Backstage.Pages.FoodItems
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
				.Include(f => f.Category).ToListAsync();
			}
		}
	}
}
