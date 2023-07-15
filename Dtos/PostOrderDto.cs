using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fungoodMVC.Models;

namespace fungoodMVC.Dtos
{
	public class PostOrderDto
	{
		public int FoodItem { get; set; }
		public int? Table { get; set; }
		public string Name { get; set; } = string.Empty;
		public Spiciness? Spiciness { get; set; }
	}
}