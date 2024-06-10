namespace InventoryManagement.Models
{
	public class PurchageProduct
	{
		public int SupplierId { get; set; }
		public string SupplierName { get; set; }
		public int BillNo { get; set; }
		public string BillDetails { get; set; }
		public DateTime PurchageDate { get; set; }
		public int Mobile { get; set; }
		public List<purchaseItem> purchaseItems { get; set; }

	}
	public class purchaseItem { 
		public int ItemId { get; set; }
		public string ItemName { get; set; }	
		public string QTY { get; set; }	
		public double purchaseprince { get; set; }
		public int TotalCast { get; set;}
	}
}
