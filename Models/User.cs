namespace fungoodMVC.Models
{
	public class User : BaseEnity
	{
		public int Id { get; set; }
		public string Username { get; set; } = string.Empty;
		public byte[] PasswordHash { get; set; } = new byte[0];
		public byte[] PasswordSalt { get; set; } = new byte[0];
		public int Rewards { get; set; }
	}
}