using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using fungoodMVC.Data;
using fungoodMVC.Dtos;
using fungoodMVC.Helper;
using fungoodMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace fungoodMVC.Pages
{
	public class Order : PageModel
	{
		private readonly DataContext _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public List<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
		public List<Category> Categories { get; set; } = new List<Category>();
		public List<Table> Tables { get; set; } = new List<Table>();




		public Order(DataContext context, UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
			_context = context;
		}

		public async Task<IActionResult> OnGet()
		{
			FoodItems = await _context.food_items.ToListAsync();
			Categories = await _context.categories.ToListAsync();
			Tables = await _context.tables.ToListAsync();
			return Page();
		}
		public async Task OnPost([FromBody] List<PostOrderDto> data)
		{
			if (ModelState.IsValid)
			{
				System.Console.WriteLine("reading request body...");
			}
			string? userId = _userManager.GetUserId(User);
			int? tableId = data[0].Table;
			var orderNumber = await _context.orders.AnyAsync() ? _context.orders.Max(i => i.OrderNumber) + 1 : 1;

			FoodItems = await _context.food_items.ToListAsync();
			Tables = await _context.tables.ToListAsync();

			// map PostOrderDto to Order
			List<fungoodMVC.Models.Order> orders = data.Select(item =>
			{
				return new fungoodMVC.Models.Order
				{
					OrderNumber = orderNumber,
					FoodItem = FoodItems.Find(f => (f.Id == item.FoodItem))!,
					Table = Tables.Find(t => (t.Id == tableId)),
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
				var orderingTable = await _context.tables.FirstOrDefaultAsync(t => t.Id == tableId);
				if (orderingTable is not null)
				{
					orderingTable.Status = Status.Occupied;
					orderingTable.OrderNumer = orderNumber;
				}
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Processing failed: {ex.Message}");
			}
		}

	}
}