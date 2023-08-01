using fungoodMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fungoodMVC.Areas.Backstage.Pages.Tables
{
	[Authorize(Roles = "staff")]
	public class Index : PageModel
	{
		private readonly DataContext _context;
		public List<Table> Tables { get; set; } = new List<Table>();
		public List<Order> Orders { get; set; } = new List<Order>();

		public Index(DataContext context)
		{
			_context = context;
		}

		public async Task OnGet()
		{
			Tables = await _context.tables.ToListAsync();
			// Orders = await _context.orders
			//         .Include(o => o.Table)
			//         .Where(o => (o.Table.Status == Status.Occupied)
		}
	}
}