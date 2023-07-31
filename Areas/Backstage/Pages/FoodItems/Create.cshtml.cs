using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using fungoodMVC.Data;
using fungoodMVC.Models;
using fungoodMVC.Areas.Backstage.Pages.FoodItems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Azure;
using fungoodMVC.Authorization;
using fungoodMVC.Helper;
using System.ComponentModel.DataAnnotations;
using fungoodMVC.Dtos;

namespace fungoodMVC.Areas.Backstage.Pages.FoodItems
{
	[Authorize(Roles = "staff")]
	public class CreateModel : PageModel
	{
		private readonly fungoodMVC.Data.DataContext _context;
		private readonly IWebHostEnvironment _environment;

		public CreateModel(fungoodMVC.Data.DataContext context, IWebHostEnvironment environment)
		{
			_context = context;
			_environment = environment;
		}

		public IActionResult OnGet()
		{
			var categorySelectList = new SelectList(_context.categories, "Id", "Name");
			System.Console.WriteLine();
			categorySelectList.First().Selected = true;
			ViewData["CategorySelectList"] = categorySelectList;
			return Page();
		}

		[BindProperty]
		public PostFoodItemDto FoodItemDto { get; set; } = default!;

		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync([FromForm] IFormFile foodImage)
		{
			if (!ModelState.IsValid || _context.food_items == null || FoodItemDto == null)
			{
				var errors = ModelState.Select(x => x.Value.Errors)
						.Where(y => y.Count > 0)
						.ToList();
				errors.ForEach(e => Dumper.print(e));

				var categorySelectList = new SelectList(_context.categories, "Id", "Name");
				Dumper.print(categorySelectList);
				categorySelectList.First().Selected = true;
				Dumper.print(categorySelectList);
				ViewData["CategorySelectList"] = categorySelectList;
				return Page();
			}

			Dumper.print(foodImage);
			string path = await FileUploadHelper.CopyFileAndGeneratePath(_environment, foodImage);
			FoodItemDto.ImageSrc = path;
			Dumper.print(FoodItemDto);

			FoodItem foodItem = new FoodItem
			{
				Name = FoodItemDto.Name,
				Price = FoodItemDto.Price,
				Category = await _context.categories.FirstAsync(c => c.Id == FoodItemDto.CategoryId),
				CategoryId = FoodItemDto.CategoryId,
				ImageSrc = path
			};
			_context.food_items.Add(foodItem);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
