using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace InventoryManagement.Controllers
{
	public class ChangePassController : Controller
	{
        ControlLayer lyer = new ControlLayer();

        [HttpGet]
		public IActionResult ChangePassView()
		{
			return View();
		}
        [HttpPost]
        public IActionResult ChangePassView(String oldPass, String confirmPass ,String newPass)
        {
            ChangePasswordC obj = new ChangePasswordC();
            obj.UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            string msg = "";
            
            DataTable old=lyer.CheckPassword(obj);



            if (oldPass != null && oldPass == old.Rows[0]["Password"])
            {
                obj.oldpassword = oldPass;
            }
            else
            {
                msg = "Old Password is Wrong";
                return Json(msg);
            }
            if (confirmPass != null && newPass != null && confirmPass == newPass)
            {
                obj.Confirmpassword = confirmPass;
                obj.newpassword = newPass;
            }else
            {
                msg = "confirm password is wrong";
            }
             
            bool status = lyer.ChangePasswords(obj);
            if (status == true)
            {
            msg = "Password Changes Sucessfully";
            }
            else
            {
                msg = "Some thing went wrong";
            }
            return Json(msg);
        }

    }
}
