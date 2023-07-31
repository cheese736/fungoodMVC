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
		public int OrderNumber { get; set; }

		public Edit(DataContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> OnGet(int orderNumber)
		{
			OrderNumber = orderNumber;
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

		public async Task<IActionResult> OnPost([FromBody] List<EditOrderDto> data, [FromRoute] int orderNumber)
		{
			if (ModelState.IsValid)
			{
				//go on as normal
			}
			else
			{
				var errors = ModelState.Select(x => x.Value?.Errors)
										.Where(y => y?.Count > 0)
										.ToList();
				Dumper.print(errors);
			}
			FoodItems = await _context.food_items.ToListAsync();
			List<Order> orders = await _context.orders.Include(o => o.Table).Where(o => o.OrderNumber == orderNumber && o.Table!.Status == Status.Occupied).ToListAsync();
			try
			{
				orders.ForEach(o =>
				{
					var d = data.First(d => d.Id == o.Id);
					if (d.ShouldBeDelete)
					{
						_context.Remove(o);
					}
					else
					{
						o.FoodItem = FoodItems.First(f => f.Id == d.FoodItemId);
						o.Spiciness = (!o.FoodItem.HasSpiciness) ? null : (d.Spiciness == null) ? 0 : d.Spiciness;
					}
				});
				await _context.SaveChangesAsync();
			}
			catch (System.Exception ex)
			{
				Console.WriteLine($"Processing failed: {ex.Message}");
			}
			return RedirectToPage("../Tables/Details", new { tableId = orders[0].Table.Id });
		}
	}
}