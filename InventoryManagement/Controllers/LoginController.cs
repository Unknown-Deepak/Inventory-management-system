using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace InventoryManagement.Controllers
{
	public class LoginController : Controller
	{
		ControlLayer lyer = new ControlLayer();
		[HttpGet]
		public IActionResult LoginPage()
		{
			return View();
		}
		[HttpPost]
		public IActionResult LoginPage(LoginClass obj)
		{
			
			DataTable dt = lyer.GetLoginDetails(obj);
			if (dt.Rows.Count > 0)
			{
				string Username = dt.Rows[0]["Username"].ToString();
				string password = dt.Rows[0]["Password"].ToString();
				int RollId = Convert.ToInt32(dt.Rows[0]["RoleId"].ToString());
				string UserId = dt.Rows[0]["UserId"].ToString();
				if (obj.Password.Trim() == password)
				{

					HttpContext.Session.SetString("UserName", Username);
					HttpContext.Session.SetString("Password", password);
					HttpContext.Session.SetString("UserId",UserId);
					if (RollId == 1)
					{
						return RedirectToAction("index", "Home");
					}
				}

			}
			return View();
		}

		[HttpGet]
		public IActionResult Logout()
		{		
			HttpContext.Session.Clear();
			HttpContext.Response.Clear();
			return RedirectToAction("LoginPage","Login");
		}

	}

}
