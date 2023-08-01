using fungoodMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fungoodMVC.Areas.Backstage.Pages.Tables
{
	[Authorize(Roles = "staff")]
	public class Checkout : PageModel
	{
		private readonly ILogger<Checkout> _logger;
		private readonly DataContext _context;
		private readonly IdentityDbContext _identityDbContext;

		public Checkout(ILogger<Checkout> logger, DataContext context, IdentityDbContext identityDbContext)
		{
			_identityDbContext = identityDbContext;
			_logger = logger;
			_context = context;
		}
		public int TableId { get; set; }
		public string? UserName { get; set; }
		public int TotalPrice { get; set; }

		public async Task<IActionResult> OnGet(int tableId)
		{
			TableId = tableId;
			var orders = await FindOrdersByTableId(tableId);

			if (orders == null)
				return NotFound();

			TotalPrice = CaculateTotalPrice(orders);
			UserName = await FindUserNameById(orders[0]); //nullable
			return Page();
		}

		public async Task<IActionResult> OnPost(int tableId)
		{
			// 改變table的狀態
			var table = await _context.tables.FirstOrDefaultAsync(t => t.Id == tableId);
			if (table == null)
				return NotFound();
			table.Status = Models.Status.Available;

			// 將Order.Check設為true，表示已結清
			var orders = await FindOrdersByTableId(tableId);
			orders.ForEach(o => o.Check = true);
			await _context.SaveChangesAsync();

			// 累積會員紅利
			var userId = orders[0].UserId;
			if (userId != null)
			{
				int points = CaculateTotalPrice(orders) / 10;
				var user = await _identityDbContext.Users.FirstAsync(u => u.Id == userId);
				user.Bonus += points;
				await _identityDbContext.SaveChangesAsync();
			}
			return RedirectToPage("./Index");
		}


		public async Task<List<Order>> FindOrdersByTableId(int tableId)
		{
			return await _context.orders
			.Include(o => o.FoodItem)
			.Include(o => o.Table)
			.Where(o => (o.Check == false) && (o.Table.Id == tableId))
			.ToListAsync();
		}

		public async Task<string?> FindUserNameById(Order order)
		{
			var userId = order.UserId;
			if (userId == null)
				return null;
			var user = await _identityDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
			return (user == null) ? null : user.UserName;
		}

		public int CaculateTotalPrice(List<Order> orders)
		{
			return orders.Aggregate(0, (acc, current) =>
			{
				return acc + current.FoodItem.Price;
			});
		}


	}
}