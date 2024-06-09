namespace InventoryManagement.Models
{
	public class PurchageProduct
	{
		public string SupplierName { get; set; }	
		public string Mobile { get; set; }		
		public string ItemName { get; set; }	
		public string ProductId { get; set; }
		public double UnitPrice { get; set; }
		public int BillNo { get; set;}
		public int TotalUnit { get; set;}
		public int Quentity { get; set; }
		public double TotalPrice { get; set;}
		public string BillDetails { get; set;}
		public DateTime PurchageDate { get; set;}

	}

}
