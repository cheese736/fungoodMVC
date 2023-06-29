using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fungoodMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace fungoodMVC.Pages
{
	public class Index : PageModel
	{
		private readonly ILogger<Index> _logger;

		public Index(ILogger<Index> logger)
		{
			_logger = logger;

		}

		public void OnGet()
		{

		}
	}
}