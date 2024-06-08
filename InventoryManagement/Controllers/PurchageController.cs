using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace InventoryManagement.Controllers
{
	public class PurchageController : Controller
	{
		ControlLayer lyer=new ControlLayer();
		public IActionResult PurchageList()
		{
			return View();
		}

		public IActionResult AddPurchage() 
		{
			return View();
		}
		public IActionResult PurchageImport()
		{
			return View();
		}
		[HttpPost]
		public JsonResult CustomerDelail()
		{
			PurchageProduct pro = new PurchageProduct();	
			DataTable dt=lyer.GetCustomerData();
			if (dt != null)
			{
				foreach (DataRow dr in dt.Rows)
				{
					pro.CustomerName = dr["CustomerName"].ToString();
					pro.CustomerMobile = dr["CustomerMobile"].ToString();
				}
			}

			return Json(pro);
		}
	}
}
