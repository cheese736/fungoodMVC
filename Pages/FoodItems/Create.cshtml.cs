using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using fungoodMVC.Data;
using fungoodMVC.Models;
using fungoodMVC.Pages.FoodItems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Azure;
using fungoodMVC.Authorization;

namespace fungoodMVC.Pages_FoodItems
{
    public class CreateModel : DI_BasePageModel
    {

        public CreateModel(DataContext context, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager)
         : base(context, authorizationService, userManager)
        {

        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(Context.categories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public FoodItem FoodItem { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Context.food_items == null || FoodItem == null)
            {
                return Page();
            }

            Context.food_items.Add(FoodItem);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
