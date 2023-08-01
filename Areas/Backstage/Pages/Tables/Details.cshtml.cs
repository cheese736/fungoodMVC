using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fungoodMVC.Areas.Backstage.Pages.Tables
{
	[Authorize(Roles = "staff")]
	public class Details : PageModel
	{
		private readonly DataContext _context;
		private readonly IdentityDbContext _identityDbContext;

		public List<Models.Order> Orders { get; set; } = new List<Models.Order>();
		public int TableId { get; set; }
		public int OrderNumber { get; set; }
		public string? UserName { get; set; }

		public Details(DataContext context, IdentityDbContext identityDbContext)
		{
			_context = context;
			_identityDbContext = identityDbContext;
		}

		public async Task<IActionResult> OnGetAsync(int tableId)
		{
			var orders = await _context.orders
			.Include(o => o.FoodItem)
			.Include(o => o.Table)
			.Where(o => (o.Table != null) && (o.Table.Id == tableId) && (o.Check == false))
			.ToListAsync();
			var userId = orders[0].UserId;
			if (userId is not null)
			{
				var user = await _identityDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
				UserName = user?.UserName;
			}


			if (orders == null)
			{
				return NotFound();
			}
			else
			{
				Orders = orders;
				OrderNumber = orders[0].OrderNumber;
				TableId = tableId;
			}
			return Page();
		}
	}
}