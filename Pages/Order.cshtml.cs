using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using fungoodMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace fungoodMVC.Pages
{
	public class Order : PageModel
	{
		private readonly DataContext _context;

		public List<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
		public List<Category> Categories { get; set; } = new List<Category>();
		public List<Table> Tables { get; set; } = new List<Table>();


		public class OrderDto
		{
			public int FoodId { get; set; }
			public string Name { get; set; } = string.Empty;
			public Spiciness? Spiciness { get; set; }
			public int Price { get; set; }
		}

		public Order(DataContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> OnGet()
		{
			FoodItems = await _context.food_items.ToListAsync();
			Categories = await _context.categories.ToListAsync();
			Tables = await _context.tables.ToListAsync();
			return Page();
		}
		public void OnPost([FromBody] List<OrderDto> data)
		{
			if (ModelState.IsValid)
			{
				System.Console.WriteLine("reading request body...");
			}
			foreach (var item in data)
			{
				System.Console.WriteLine(item.Spiciness);
			}
		}

	}
}