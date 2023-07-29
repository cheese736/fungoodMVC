using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fungoodMVC.Dtos;
using fungoodMVC.Helper;
using fungoodMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace fungoodMVC.Areas.Backstage.Pages.Orders
{
	public class Create : PageModel
	{
		private readonly DataContext _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public List<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
		public List<Category> Categories { get; set; } = new List<Category>();
		public Table Table { get; set; } = new Table();




		public Create(DataContext context, UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
			_context = context;
		}

		public async Task<IActionResult> OnGet(int orderNumber)
		{
			FoodItems = await _context.food_items.ToListAsync();
			Categories = await _context.categories.ToListAsync();
			Table = await _context.tables.FirstAsync(t => (t.OrderNumer == orderNumber));
			return Page();
		}
		public async Task<IActionResult> OnPost([FromBody] List<PostOrderDto> data, [FromRoute] int orderNumber)
		{
			FoodItems = await _context.food_items.ToListAsync();
			Table = await _context.tables.FirstAsync(t => (t.OrderNumer == orderNumber));
			string? userId = _context.orders.FirstOrDefault(o => o.OrderNumber == orderNumber)?.UserId;

			// map EditOrderDto to Order
			List<fungoodMVC.Models.Order> orders = data.Select(item =>
			{
				return new fungoodMVC.Models.Order
				{
					OrderNumber = orderNumber,
					FoodItem = FoodItems.Find(f => (f.Id == item.FoodItem))!,
					Table = Table,
					Spiciness = item.Spiciness,
					UserId = userId
				};
			}).ToList();

			try
			{
				foreach (var item in orders)
				{
					_context.orders.Add(item);
				}
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Processing failed: {ex.Message}");
			}
			return RedirectToPage("./Edit", new { orderNumber = orderNumber });
		}
	}
}