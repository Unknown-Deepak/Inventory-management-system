namespace InventoryManagement.Models
{
	public class ChangePasswordC
	{
        public int UserId { get; set; }
        public string oldpassword { get; set; }
        public string newpassword { get; set; }
        public string Confirmpassword { get; set; }
    }
}
