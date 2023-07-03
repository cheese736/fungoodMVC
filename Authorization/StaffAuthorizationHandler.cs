using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using fungoodMVC.Models;

namespace fungoodMVC.Authorization
{
	public class StaffAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, FoodItem>
	{
		private readonly UserManager<IdentityUser> _userManager;

		public StaffAuthorizationHandler(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}

		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, FoodItem resource)
		{
			throw new NotImplementedException();
		}
	}
}