using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fungoodMVC.Areas.Backstage.Pages.Orders
{
	[Authorize(Roles = "staff")]
	public class Index : PageModel
	{
		private readonly DataContext _context;
		public List<dynamic> Orders { get; set; } = new List<dynamic>();

		public Index(DataContext context)
		{
			_context = context;
		}

		public async Task OnGet()
		{
			Orders = await _context.orders
					.GroupBy(o => new { o.OrderNumber, o.Inserted, o.Table!.Id, o.Check })
					.Select(g => new
					{
						OrderNumber = g.Key.OrderNumber,
						Inserted = g.Key.Inserted,
						TableId = g.Key.Id,
						Sum = g.Sum(o => o.FoodItem.Price),
						Check = g.Key.Check
					})
					.Cast<dynamic>()
					.ToListAsync();
		}
	}
}