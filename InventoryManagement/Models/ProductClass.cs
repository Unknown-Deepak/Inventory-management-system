using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace InventoryManagement.Models
{
	public class ProductClass
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string ProductDisc { get; set; }
		public string ProductImg { get; set; }
		public string ProductPrice { get; set; }
		public string Qty { get; set; }
		public string TotalQty { get; set; }
		public string Price { get; set; }
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public int SubCategoryId { get; set; }
		public string SubCategoryName { get; set; }
		public int BrandId { get; set; }
		public string BrandName { get; set; }
		public IFormFile ProductImage { get; set; }
		public string TotalPrice { get; set; }
		public int CreateBy { get; set; }
		/*public List<SelectListItem> CategoryList = new List<SelectListItem>() { new SelectListItem { Text = "Select", Value = "" } };
		public List<SelectListItem> SubCategoryList = new List<SelectListItem>() { new SelectListItem { Text = "Select", Value = "" } };
		public List<SelectListItem> BrandList = new List<SelectListItem>() { new SelectListItem { Text = "Select", Value = "" } };*/
		public List<ProductClass> ProductList = new List<ProductClass>();				
	}
}

