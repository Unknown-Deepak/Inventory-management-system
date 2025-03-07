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
		public string Totalamount { get; set; }
		public string Grandtotal { get; set; }
		public string Discount { get; set; }
		public string CreateBy { get; set; }
		public List<purchaseItem> purchageitem = new List<purchaseItem>{};

	}
	public class purchaseItem { 
		public int ItemId { get; set; }
		public string itemName { get; set; }	
		public string Qty { get; set; }	
		public string purchaseprince { get; set; }
		public string TotalCost { get; set;}
	}
}
