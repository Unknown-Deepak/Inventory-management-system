using System.Numerics;

namespace InventoryManagement.Models
{
	public class PurchageProduct
	{
		public int SupplierId { get; set; }
		public string SupplierName { get; set; }
		public string BillNo { get; set; }
		public string BillDetails { get; set; }
		public string PurchageDate { get; set; }
		public string Mobile { get; set; }
		public List<purchaseItem> purchaseItems { get; set; }

	}
	public class purchaseItem { 
		public int ItemId { get; set; }
		public string ItemName { get; set; }	
		public string QTY { get; set; }	
		public string purchaseprince { get; set; }
		public string TotalCast { get; set;}
	}
}
