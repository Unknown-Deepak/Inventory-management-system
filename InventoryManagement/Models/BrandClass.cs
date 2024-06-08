namespace InventoryManagement.Models
{
	public class BrandClass
	{
		public int BrandId { get; set; }
		public string BrandName { get; set; }
		public string BrandDesc { get; set;}
		public string BrandImgPath { get; set; }
		public IFormFile BrandImg {  get; set; }
		public List<BrandClass> Brand =new List<BrandClass>();
	}
}
