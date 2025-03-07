using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace InventoryManagement.Controllers
{
	public class ProductController : Controller
	{
		ControlLayer lyer = new ControlLayer();
		[HttpGet]
		public IActionResult ProductView()
		{
			List<ProductClass> prolst = new List<ProductClass>();
			ProductClass Pro_Obj = new ProductClass();
			
			DataTable dt = lyer.GetProductData();
			foreach (DataRow dr in dt.Rows)
			{
				ProductClass addCat = new ProductClass();
				addCat.ProductId = Convert.ToInt32(dr["ProductId"].ToString());
				addCat.CategoryName = dr["CategoryName"].ToString();
				addCat.SubCategoryName = dr["SubCategoryName"].ToString();
				addCat.BrandName = dr["BrandName"].ToString();
				addCat.ProductName = dr["ProductName"].ToString();
				addCat.Qty = dr["Qty"].ToString();
				addCat.ProductPrice = dr["ProductPrice"].ToString();
				addCat.ProductDisc = dr["ProductDisc"].ToString();
				addCat.TotalPrice = dr["TotalPrice"].ToString();
				addCat.ProductImg = dr["ProductImgPath"].ToString();
				addCat.SubCategoryId = Convert.ToInt32(dr["SubCategoryId"].ToString());
				addCat.CategoryId = Convert.ToInt32(dr["CategoryId"].ToString());
				addCat.BrandId = Convert.ToInt32(dr["BrandId"].ToString());
				prolst.Add(addCat);
			}
            Pro_Obj.ProductList = prolst;									   
            return View(Pro_Obj);
		}

		[HttpGet]
		public IActionResult AddProduct(int? id)//Category Dropdown in Product 
		{
			ProductClass ProObj = new ProductClass();
			if(id != null)
			{
                List<SelectListItem> SelectList = new List<SelectListItem>();
                DataTable dt=lyer.ProductEdit(id);
				if (dt.Rows.Count > 0)
				{
					ProObj.ProductId = Convert.ToInt32(dt.Rows[0]["ProductId"].ToString());
					ProObj.CategoryName = dt.Rows[0]["CategoryName"].ToString();                    
                    ProObj.ProductName = dt.Rows[0]["ProductName"].ToString();
					ProObj.Price = dt.Rows[0]["ProductPrice"].ToString();
					ProObj.Qty = dt.Rows[0]["Qty"].ToString();
					ProObj.ProductDisc = dt.Rows[0]["ProductDisc"].ToString();
					ProObj.ProductImg = dt.Rows[0]["ProductImgPath"].ToString();

                    SelectList.Add(new SelectListItem
                    {
                        Text = dt.Rows[0]["CategoryName"].ToString(),
                        Value = dt.Rows[0]["CategoryId"].ToString()

                    });
                    ViewBag.SelectList = SelectList;
                    return View(ProObj);
				}   
			}     
			else
			{
				DataTable Catdt = lyer.GetCategoryData();
				List<SelectListItem> SelectList = new List<SelectListItem>();
				if (Catdt.Rows.Count > 0 && Catdt != null)
				{
					foreach (DataRow dr in Catdt.Rows)
					{
						SelectList.Add(new SelectListItem
						{
							Text = dr["CategoryName"].ToString(),
							Value = dr["CategoryId"].ToString()

						});
					}
                    ViewBag.SelectList = SelectList;
				}
			} 			
			return View();
		}

		[HttpPost]
        public JsonResult AddProductSub(int? id)
		{
            DataTable SubCatdt = lyer.GetSubCategoryData(id);
			List<ProductClass> SubCategoryList = new List<ProductClass>();
			if(SubCatdt.Rows.Count>0 && SubCatdt != null)
			{
				foreach (DataRow dr in SubCatdt.Rows)
				{
					SubCategoryList.Add(new ProductClass
					{
						CategoryId = Convert.ToInt32(dr["CategoryId"]),
						SubCategoryId = Convert.ToInt32(dr["SubCategoryId"]),
						SubCategoryName = dr["SubCAtegoryName"].ToString()
					}) ; 
				}
            }/*
            SubCategoryList = SubCategoryList.Distinct().ToList();*/
            return Json(SubCategoryList);
		}

        [HttpPost]
        public JsonResult AddProductBrand(int? id)
        {
            DataTable Brand_dt = lyer.GetBrandData();
            List<ProductClass> BrandList = new List<ProductClass>();
            if (Brand_dt.Rows.Count > 0 && Brand_dt != null)
            {
                foreach (DataRow dr in Brand_dt.Rows)
                {
                    BrandList.Add(new ProductClass
                    {
                        BrandId = Convert.ToInt32(dr["BrandId"]),
                        BrandName = dr["BrandName"].ToString()
                    });
                }
            }
            return Json(BrandList);
        }
       
        [HttpPost]
		public IActionResult AddProduct(ProductClass obj)
		{
			bool status = false;
			if (obj.ProductImage != null)
			{
				string Imgpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadImg/Product/", obj.ProductImage.FileName);

				using (var stream1 = System.IO.File.Create(Imgpath))
				{
					obj.ProductImage.CopyTo(stream1);
				}
				obj.ProductImg = obj.ProductImage.FileName;

				if (obj.ProductId != null && obj.ProductId!=0)
                {
					obj.CreateBy= Convert.ToInt32(HttpContext.Session.GetString("UserId"));
                    status = lyer.ProductEditPost(obj);
				}
				else
				{
                    status = lyer.AddProductData(obj);
                }				
			}

			if (status)
			{
				ViewBag.sms = "Product Data Inserted";
			}
			return View(obj);
		}

		public IActionResult ProductDelete(int? Id)
		{
			bool a=lyer.DataProductDelete(Id);
			if (a)
			{
				ViewBag.del = "Product Data is Deleted";
				return RedirectToAction("ProductView","Product");
			}
			return View();			
		}
	}
}


