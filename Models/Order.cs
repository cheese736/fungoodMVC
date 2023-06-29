using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace fungoodMVC.Models
{
	public class Order : BaseEnity
	{
		public int Id { get; set; }
		public int OrderNumber { get; set; }
		public int TableNumber { get; set; }
		public int FoodItemId { get; set; }
		public int UserId { get; set; }

		public Spiciness? Spiciness { get; set; }
	}

	public enum Spiciness
	{
		none,
		mild,
		medium,
		hot
	}
}