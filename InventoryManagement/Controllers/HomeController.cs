using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace InventoryManagement.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        ControlLayer lyer = new ControlLayer();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //Home Page Layout
        public IActionResult Index()
        {
            var res=HttpContext.Session.GetString("UserId");

			if (res == null)
			{
				return RedirectToAction("LoginPage", "Login");
			}
            else
			    return View();
        }
        //Get All Data in Database to display
        [HttpGet]
        public IActionResult ViewProduct()
        {
            DataTable dt = lyer.GetCategoryData();
            AddCategory obj= new AddCategory();
            List<AddCategory> lst = new List<AddCategory>();
            foreach(DataRow dr in dt.Rows)
            {
                AddCategory addCat = new AddCategory();
                addCat.CategoryId = Convert.ToInt32(dr["CategoryId"].ToString());
				addCat.CategoryName = dr["CategoryName"].ToString();
				addCat.CategoryCode = dr["CategoryCode"].ToString();
				addCat.CategoryDesc = dr["CategoryDesc"].ToString();
                addCat.CategoryImg = dr["CategoryImg"].ToString();
                lst.Add(addCat);
            }
            obj.lstCat = lst;
            return View(obj);
		}
		
        //Add category section
		[HttpGet]
        public IActionResult AddCategoryUser(int? id)
        {
            AddCategory user = new AddCategory();
            if(id != null)
            {
                DataTable dt=lyer.GetUpdateUserCategory(id);
                if (dt.Rows.Count > 0)
                {
                    user.CategoryId = Convert.ToInt32(dt.Rows[0]["CategoryId"].ToString());
                    user.CategoryName = dt.Rows[0]["CategoryName"].ToString();
                    user.CategoryCode = dt.Rows[0]["CategoryCode"].ToString();
                    user.CategoryDesc = dt.Rows[0]["CategoryDesc"].ToString();
                    user.CategoryImg = dt.Rows[0]["CategoryImg"].ToString();
                }
				return View(user);
			}
            else
            {
                return View();
            }
            
        }
        [HttpPost]
		public IActionResult AddCategoryUser(AddCategory obj)
		{
            bool a = false;
            if (obj.CategoryImage != null)
            {
				string Imgpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadImg/Category/", obj.CategoryImage.FileName);

				using (var stream1 = System.IO.File.Create(Imgpath))
				{
					obj.CategoryImage.CopyTo(stream1);
				}
				obj.CategoryImg = obj.CategoryImage.FileName;



				if (obj.CategoryId != 0)
				{
					a = lyer.PostUpdateUserCategory(obj);
				}
				else
				{
					a = lyer.CategoryInsertData(obj);
				}
			}
						
            if (a)
            {
                ViewBag.sms = "Category Data UpDated Successfully";
            }

			return RedirectToAction("ViewProduct", "Home");
		}

        [HttpPost]
        public IActionResult DeleteCategoryUser(int Id)
        {
            string result = "";
            bool x=lyer.DeleteCategory(Id);
            if(x)
            {
				result = "Category Data is Deleted";
            }
            else
            {
				result = "Something went wrong";
            }

            return Content(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
