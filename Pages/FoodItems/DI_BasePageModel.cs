using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace fungoodMVC.Pages.FoodItems
{
	public class DI_BasePageModel : PageModel
	{
		protected DataContext Context { get; }
		protected IAuthorizationService AuthorizationService { get; }
		protected UserManager<IdentityUser> UserManager { get; }

		public DI_BasePageModel(DataContext context, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager)
		{
			Context = context;
			AuthorizationService = authorizationService;
			UserManager = userManager;
		}

	};
}