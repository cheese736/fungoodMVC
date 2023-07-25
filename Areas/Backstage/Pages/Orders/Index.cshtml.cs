using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fungoodMVC.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace fungoodMVC.Areas.Backstage.Pages.Orders
{
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
					.GroupBy(o => new { o.OrderNumber, o.Inserted, o.Table.Id, o.Table.Status })
					.Select(g => new
					{
						OrderNumber = g.Key.OrderNumber,
						Inserted = g.Key.Inserted,
						TableId = g.Key.Id,
						Sum = g.Sum(o => o.FoodItem.Price),
						Status = g.Key.Status
					})
					.Cast<dynamic>()
					.ToListAsync();
		}
	}
}