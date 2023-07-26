using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fungoodMVC.Dtos;
using fungoodMVC.Helper;
using fungoodMVC.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace fungoodMVC.Areas.Backstage.Pages.Orders
{
	public class Edit : PageModel
	{
		private readonly DataContext _context;
		public List<Models.Order> Orders { get; set; } = new List<Models.Order>();
		public int TableId { get; set; }
		public List<FoodItem> FoodItems = new List<FoodItem>();
		public SelectList Spiciness { get; set; } = new SelectList(Models.Spiciness.GetValues(typeof(Spiciness)));

		[BindProperty]
		public EditOrderDto editOrderDto { get; set; } = new EditOrderDto();

		public Edit(DataContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> OnGet(int? orderNumber)
		{
			if (orderNumber == null)
			{
				return NotFound();
			}

			FoodItems = await _context.food_items.ToListAsync();


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

		public async Task OnPostAsync()
		{
			var order = await _context.orders.FirstOrDefaultAsync(o => o.Id == editOrderDto.Id);
			var foodItem = await _context.food_items.FirstOrDefaultAsync(f => f.Id == editOrderDto.FoodItemId);
			if (order != null && foodItem != null)
			{
				order.Id = editOrderDto.Id;
				order.FoodItem = foodItem;
				order.Spiciness = editOrderDto.Spiciness;
			}
			await _context.SaveChangesAsync();
		}
	}
}