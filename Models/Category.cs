namespace fungoodMVC.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;

		public ICollection<FoodItem> FoodItems { get; } = new List<FoodItem>();
	}
}