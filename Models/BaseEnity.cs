using System.ComponentModel.DataAnnotations.Schema;

namespace fungoodMVC.Models
{
	public class BaseEnity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime Inserted { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime LastUpdated { get; set; }
	}
}