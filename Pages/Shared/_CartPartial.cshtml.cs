using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace fungoodMVC.Views.Partials
{
	public class _CartPartial : PageModel
	{
		private readonly ILogger<_CartPartial> _logger;

		public _CartPartial(ILogger<_CartPartial> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
		}
	}
}