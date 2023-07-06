using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using fungoodMVC.Data;
using fungoodMVC.Models;
using fungoodMVC.Pages.FoodItems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace fungoodMVC.Pages_FoodItems
{
    [Authorize(Roles = "staff")]
    public class DeleteModel : DI_BasePageModel
    {
        public DeleteModel(DataContext context, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager)
         : base(context, authorizationService, userManager)
        {

        }

        [BindProperty]
        public FoodItem FoodItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || Context.food_items == null)
            {
                return NotFound();
            }

            var fooditem = await Context.food_items
            .Include(f => f.category)
            .FirstOrDefaultAsync(m => m.Id == id);

            if (fooditem == null)
            {
                return NotFound();
            }
            else
            {
                FoodItem = fooditem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || Context.food_items == null)
            {
                return NotFound();
            }
            var fooditem = await Context.food_items.FindAsync(id);

            if (fooditem != null)
            {
                FoodItem = fooditem;
                Context.food_items.Remove(FoodItem);
                await Context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
