using System;
using System.Collections.Generic;
using System.Linq;
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
		private readonly ILogger<Order> _logger;
		private readonly DataContext _context;
		[BindProperty]
		public List<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
		[BindProperty]
		public List<Category> Categories { get; set; } = new List<Category>();
		public List<FoodItem> Cart { get; set; } = new List<FoodItem>();

		public Order(ILogger<Order> logger, DataContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<IActionResult> OnGet()
		{
			FoodItems = await _context.food_items.ToListAsync();
			Categories = await _context.categories.ToListAsync();
			return Page();
		}

	}
}