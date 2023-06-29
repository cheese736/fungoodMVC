using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace fungoodMVC.Models
{
	public class FoodItem : BaseEnity
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;
		public int Price { get; set; }
		public Category category { get; set; } = null!;
		public int CategoryId { get; set; }
		public string ImageSrc { get; set; } = string.Empty;

		public bool HasSpiciness { get; set; }

	}




}