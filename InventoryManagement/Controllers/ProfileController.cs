using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
	public class ProfileController : Controller
	{
		ControlLayer dl = new ControlLayer();

		[HttpGet]
		public IActionResult MyProfile()
		{
			return View();
		}
		[HttpPost]
		public IActionResult MyProfile(ProfileClass obj)
		{
			if (obj != null)
			{
				string image = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/UploadImg/ProfileImg",obj.Photo.FileName);
				using(var pic=System.IO.File.Create(image))
				{
					obj.Photo.CopyTo(pic);
				}
				obj.PhotoUrl = obj.Photo.FileName;

				bool a = dl.UpdateProfile(obj);
				if(a)
				{
					ViewBag.sms = "Profile Data Updated";
				}
				else
				{
					ViewBag.sms = "Something went wrong";
				}

			}
			return View();
		}
	}
}
