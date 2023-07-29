using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fungoodMVC.Models;
using System.Text.Json.Serialization;
namespace fungoodMVC.Dtos
{
	public class EditOrderDto
	{
		public int Id { get; set; }
		public int FoodItemId { get; set; }
		public Spiciness? Spiciness { get; set; }
		public bool ShouldBeDelete { get; set; } = false;
	}
}