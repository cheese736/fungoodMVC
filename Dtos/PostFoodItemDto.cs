using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fungoodMVC.Dtos
{
	public class PostFoodItemDto
	{
		public string Name { get; set; } = string.Empty;
		public int Price { get; set; }
		public int CategoryId { get; set; }
		public string ImageSrc { get; set; } = string.Empty;

		public bool HasSpiciness { get; set; }
	}
}