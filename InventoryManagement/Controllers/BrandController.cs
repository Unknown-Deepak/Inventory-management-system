using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;

namespace InventoryManagement.Controllers
{
	public class BrandController : Controller
	{
		ControlLayer br_Lyer = new ControlLayer();
		[HttpGet]
		public IActionResult ViewBrand()
		{
			DataTable dt = br_Lyer.GetBrandData();
			BrandClass obj = new BrandClass();
			List<BrandClass> lst = new List<BrandClass>();
			foreach (DataRow dr in dt.Rows)
			{
				BrandClass addCat = new BrandClass();
				addCat.BrandId = Convert.ToInt32(dr["BrandId"].ToString());
				addCat.BrandName = dr["BrandName"].ToString();
				addCat.BrandDesc = dr["BrandDisc"].ToString();
				addCat.BrandImgPath = dr["BrandImgPath"].ToString();
				lst.Add(addCat);

			}
			obj.Brand = lst;
			return View(obj);
		}		
		

		[HttpGet]
		public IActionResult AddBrandData(int? id)
		{
			BrandClass user = new BrandClass();
			if (id != null)
			{
				DataTable dt = br_Lyer.GetUpdateUserBrand(id);
				if (dt.Rows.Count > 0)
				{
					user.BrandId = Convert.ToInt32(dt.Rows[0]["BrandId"].ToString());
					user.BrandName = dt.Rows[0]["BrandName"].ToString();
					user.BrandDesc = dt.Rows[0]["BrandDisc"].ToString();
					user.BrandImgPath = dt.Rows[0]["BrandImgPath"].ToString();
				}
				return View(user);
			}
			else
			{
				return View();
			}
		}
		[HttpPost]
		public IActionResult AddBrandData(BrandClass obj)
		{
			bool a = false;
			if (obj.BrandImg != null)
			{
				string Imgpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadImg/BrandImage/", obj.BrandImg.FileName);

				using (var stream1 = System.IO.File.Create(Imgpath))
				{
					obj.BrandImg.CopyTo(stream1);
				}
				obj.BrandImgPath = obj.BrandImg.FileName;
				if (obj.BrandId != 0)
				{
					a = br_Lyer.PostUpdateBrand(obj);
				}
				else
					a = br_Lyer.BrandInsertData(obj);
			}	

			if (a)
			{
				ViewBag.sms = "Brand Data Uploaded";
			}
			else
			{
				ViewBag.sms = "Something want to wrong";
			}

			return View();
		}

		[HttpPost]
		public IActionResult DeleteBrandData(int Id)		
		{
			string result = "";
			bool x = br_Lyer.DeleteBrand(Id);
			if (x)
			{
				result = "Category Data is Deleted";
			}
			else
			{
				result = "Something went wrong";
			}

			return View();
		}


	
	}
}
