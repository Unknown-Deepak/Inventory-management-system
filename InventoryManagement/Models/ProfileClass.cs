namespace InventoryManagement.Models
{
	public class ProfileClass
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public int Phone { get; set; }
		public string OldUserName { get; set; }
		public string UserName { get; set; }
		public int Password { get; set; }
		public IFormFile Photo { get; set; }
		public string PhotoUrl { get; set; }
	}
}
