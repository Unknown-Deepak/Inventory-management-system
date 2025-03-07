using InventoryManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation.Context;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
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
		[HttpPost]
		public IActionResult AddPurchage(string data)
		{
			string sms= "";
			var transaction = JsonConvert.DeserializeObject<PurchageProduct>(data);
			if (data != null && transaction!=null)
			{
				transaction.CreateBy = HttpContext.Session.GetString("UserId");
				var ddd = Convert.ToDateTime(transaction.PurchageDate);
				transaction.PurchageDate = ddd.ToString("yyyy-MM-dd");

				bool dt = lyer.InsertPurchaseData(transaction);
				if(dt)
				{
					sms = "Purchage Data Insert Successfully";
				}
				else
				{
					sms = "Some thing went Wrong";
				}
			}
			return Json(sms);
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
					pro.SupplierName = dr["CustomerName"].ToString();
					pro.Mobile = dr["CustomerMobile"].ToString();
				}
			}

			return Json(pro);
		}
	}
}
