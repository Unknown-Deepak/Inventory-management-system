using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
	public class SalesController : Controller
	{
		public IActionResult SalesList()
		{
			return View();
		}
		public IActionResult AddSales()
		{
			return View();
		}


		[HttpGet]
		public ActionResult SalesReport()
		{
			return View();
		}
	}
}
