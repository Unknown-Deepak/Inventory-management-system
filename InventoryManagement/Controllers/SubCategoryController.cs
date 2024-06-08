using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace InventoryManagement.Controllers
{
	public class SubCategoryController : Controller
	{
		ControlLayer lyer = new ControlLayer();
		SubCategoryDB SubCatObj = new SubCategoryDB();
		public IActionResult ViewPage()
		{			
			SubCategoryDB SubCatObj=new SubCategoryDB();
			List<SubCategoryDB> lst = new List<SubCategoryDB>();

			DataTable dt = lyer.GetSubCategoryData();

			foreach (DataRow dr in dt.Rows)
			{
				SubCategoryDB addCat = new SubCategoryDB();
				addCat.CategoryId =dr["CategoryId"].ToString();
				addCat.SubCategoryId =dr["SubCategoryId"].ToString();
				addCat.SubCategoryName = dr["SubCategoryName"].ToString();
				addCat.SubCategoryCode =dr["SubCategoryCode"].ToString();
				addCat.SubCategoryDisc = dr["SubCategoryDisc"].ToString();
				addCat.SubCategoryImgPath = dr["SubCategoryImg"].ToString();
				addCat.CategoryName = dr["CategoryName"].ToString();
				lst.Add(addCat);
			}
			SubCatObj.SubCategories = lst;
			return View(SubCatObj);
		}
		[HttpGet]
		public IActionResult AddSubCategory(int? Id)
		{
			SubCategoryDB SubCatObj = new SubCategoryDB();
			if (Id != null)
			{
				DataTable dtl = lyer.GetEditSubCategoryData(Id);
				if (dtl.Rows.Count > 0)
				{
					SubCatObj.CategoryId = dtl.Rows[0]["CategoryId"].ToString();
					SubCatObj.SubCategoryId = dtl.Rows[0]["SubCategoryId"].ToString();
					SubCatObj.SubCategoryName = dtl.Rows[0]["SubCategoryName"].ToString();
					SubCatObj.SubCategoryCode = dtl.Rows[0]["SubCategoryCode"].ToString();
					SubCatObj.SubCategoryDisc = dtl.Rows[0]["SubCategoryDisc"].ToString();
					SubCatObj.SubCategoryImgPath = dtl.Rows[0]["SubCategoryImg"].ToString();
				}
			}
			DataTable dt = lyer.GetCategoryData();
			foreach (DataRow dr in dt.Rows)
			{
				SubCategoryDB SObj = new SubCategoryDB();
				SelectListItem selectListItem = new SelectListItem();
				selectListItem.Text = dr["CategoryName"].ToString();
				selectListItem.Value = dr["CategoryId"].ToString();
				SObj.CategoryId= dr["CategoryId"].ToString();
				SubCatObj.CategoryList.Add(selectListItem);
			}			
			return View(SubCatObj);
		}

		[HttpPost]
		public IActionResult AddSubCategory(SubCategoryDB SubCatObj)
		{
			bool status = false;
			if (SubCatObj.SubCategoryImage != null)
			{
				string Imgpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadImg/SubCategory/", SubCatObj.SubCategoryImage.FileName);

				using (var stream1 = System.IO.File.Create(Imgpath))
				{
					SubCatObj.SubCategoryImage.CopyTo(stream1);
				}
				SubCatObj.SubCategoryImgPath = SubCatObj.SubCategoryImage.FileName;
				if (SubCatObj.SubCategoryId!=null) 
				{
					status= lyer.PostEditSubCategoryData(SubCatObj);
				}
				else
					status = lyer.AddSubCategoryData(SubCatObj);
			}

			if (status)
			{
				ViewBag.sms = "Sub Category Data Inserted";
				return RedirectToAction("ViewPage", "SubCategory");
			}
			return View(SubCatObj);
		}

		[HttpPost]
		public IActionResult DeleteSubCategory(int? id)
		{
			bool x = lyer.DeleteSubCategory(id);
			if (x)
			{
				ViewBag.res = "Sub Category Data is Deleted";
			}
			else
			{
				ViewBag.res = "Something went wrong";
			}

			return RedirectToAction("ViewPage", "SubCategory"); 
		}
		
	}
}
