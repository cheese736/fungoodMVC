using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace fungoodMVC.Authorization
{
	public class Operations
	{
		public static OperationAuthorizationRequirement Create =
		new OperationAuthorizationRequirement { Name = Constants.CreateOperationName };
	}
	public class Constants
	{
		public static readonly string CreateOperationName = "create";
	}
}