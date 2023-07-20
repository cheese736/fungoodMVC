using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace fungoodMVC.Areas.Backstage.Pages.Tables
{
	public class Details : PageModel
	{
		private readonly DataContext _context;
		public List<Models.Order> Orders { get; set; } = new List<Models.Order>();
		public int TableId { get; set; }

		public Details(DataContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> OnGetAsync(int? orderNumber)
		{
			if (orderNumber == null)
			{
				return NotFound();
			}

			var orders = await _context.orders
			.Include(o => o.FoodItem)
			.Include(o => o.Table)
			.Where(o => o.OrderNumber == orderNumber)
			.ToListAsync();

			if (orders == null)
			{
				return NotFound();
			}
			else
			{
				Orders = orders;
				TableId = orders[0].Table!.Id;
			}
			return Page();
		}
	}
}