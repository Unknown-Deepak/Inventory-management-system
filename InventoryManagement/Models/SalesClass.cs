namespace InventoryManagement.Models
{
	public class SalesClass
	{
		public int Id { get; set; }
		public string CustomerName { get; set; }
		public string BillNo { get; set; }
		public string BillDetails { get; set; }
		public string SalesDate { get; set; }
		public string Mobile { get; set; }
		public string CreateBy { get; set; }

		public List<Items> Salesitem = new List<Items>();
	}
	public class Items
	{
		public string itemId { get; set; }
		public string itemName { get; set; }
		public string Qty { get; set; }
		public string Salesprice { get; set; }
		public string TotalCost { get; set; }
	}
}
