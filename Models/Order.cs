namespace fungoodMVC.Models
{
	public class Order : BaseEnity
	{
		public int Id { get; set; }
		public int OrderNumber { get; set; }
		public FoodItem FoodItem { get; set; } = new FoodItem();
		public Table Table { get; set; } = new Table();
		public Spiciness? Spiciness { get; set; }
		public string? UserId { get; set; }
		public bool Check { get; set; }
	}

	public enum Spiciness
	{
		none,
		mild,
		medium,
		hot
	}
}