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

		public async Task<IActionResult> OnGetAsync(int orderNumber)
		{
			var orders = await _context.orders
			.Include(o => o.FoodItem)
			.Include(o => o.Table)
			.Where(o => o.OrderNumber == orderNumber)
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
				OrderNumber = orderNumber;
				TableId = orders[0].Table!.Id;
			}
			return Page();
		}
	}
}