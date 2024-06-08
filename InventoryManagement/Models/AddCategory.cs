namespace InventoryManagement.Models
{
	public class AddCategory
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string CategoryDesc{ get; set; }
		public string CategoryCode { get; set; }
		public string CategoryImg { get; set; }
		public IFormFile CategoryImage { get; set; }
		public int IsActive { get; set; }
		public int IsDeleted {  get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime UpdatedOn { get; set; }
		public int CreatedBy {  get; set; }
		public int UpdatedBy { get; set; }
		public List<AddCategory> lstCat=new List<AddCategory>();
	}
}
