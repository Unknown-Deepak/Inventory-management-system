using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagement.Models
{
	public class SubCategoryDB
	{
		public string SubCategoryId {  get; set; }
	    public string CategoryName {  get; set; }
	    public string SubCategoryName {  get; set; }
		public string CategoryId { get; set; }
		public string SubCategoryDisc {  get; set; }
	    public string SubCategoryCode {  get; set; }
	    public string SubCategoryImgPath {  get; set; }
		public IFormFile SubCategoryImage { get; set; }

		public List<SelectListItem> CategoryList = new List<SelectListItem>() { new SelectListItem { Text = "Select", Value = "" } };
		public List<SelectListItem> SubCategoryList = new List<SelectListItem>() { new SelectListItem { Text = "Select", Value = "" } };

		public List<SubCategoryDB> SubCategories=new List<SubCategoryDB>();	
	}
}
