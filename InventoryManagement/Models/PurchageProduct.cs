namespace InventoryManagement.Models
{
	public class PurchageProduct
	{
		public string CustomerName { get; set; }	
		public string CustomerMobile { get; set; }		
		public string ProductName { get; set; }	
		public string ProductId { get; set; }

		public double UnitPrice { get; set; }

		public int TotalUnit { get; set;}

		public int Quentity { get; set; }

		public double TotalPrice { get; set; }

	}

}
