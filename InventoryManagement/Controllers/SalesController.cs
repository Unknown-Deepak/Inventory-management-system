using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace InventoryManagement.Controllers
{
	public class SalesController : Controller
	{
		ControlLayer dl = new ControlLayer();
		public IActionResult SalesList()
		{
			return View();
		}
		public IActionResult AddSales()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddSales(string data)
		{
			var model = JsonConvert.DeserializeObject<SalesClass>(data);
			if(model!=null)
			{
				bool a=dl.SalesDataInsert(model);         
			}
			return View();
		}


		[HttpGet]
		public ActionResult SalesReport()
		{
			return View();
		}
	}
}
