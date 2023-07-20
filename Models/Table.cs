using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fungoodMVC.Models
{
	public class Table
	{
		public int Id { get; set; }
		public Status? Status { get; set; }
		public int? OrderNumer { get; set; }
	}

	public enum Status
	{
		Available,
		Occupied,
		Reserved,
		OutOfService
	}
}