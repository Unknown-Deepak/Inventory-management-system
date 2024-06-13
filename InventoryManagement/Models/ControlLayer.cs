using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Cryptography.Xml;
using System.Reflection;

namespace InventoryManagement.Models
{
	public class ControlLayer
	{
		string DatabaseString = "";
		public ControlLayer()
		{
			DatabaseString = "Data Source=DESKTOP-4PUO57K;Initial Catalog=InventoryManagement;Integrated Security=True;";
		}

		public bool CategoryInsertData(AddCategory obj)
		{
			try
			{
				using (SqlConnection SqlConnect = new SqlConnection(DatabaseString))
				{
					SqlConnect.Open();
					SqlCommand cmd = new SqlCommand("Sp_Insert", SqlConnect);
					cmd.CommandType= CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@CategoryName", obj.CategoryName);
					cmd.Parameters.AddWithValue("@CategoryCode", obj.CategoryCode);
					cmd.Parameters.AddWithValue("@CategoryDesc", obj.CategoryDesc);
					cmd.Parameters.AddWithValue("@CategoryImg", obj.CategoryImg);
					int x = cmd.ExecuteNonQuery();
					if (x > 0)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch (Exception ex)
			{
				return false ;
			}
			
		}

		public DataTable GetCategoryData()
		{
			DataTable dt = new DataTable();
			try
			{
				using (SqlConnection sqlConnect = new SqlConnection(DatabaseString))
				{
					sqlConnect.Open();
					SqlCommand cmd = new SqlCommand("SP_GetAllCategoryData", sqlConnect);
					cmd.CommandType = CommandType.StoredProcedure;
					SqlDataAdapter data = new SqlDataAdapter(cmd);
					data.Fill(dt);

				}
			}
			catch(Exception ex)
			{

			}
			
			return dt;
		}       

        public bool DeleteCategory(int? id)
        {
			
			using(SqlConnection sqlconnect=new SqlConnection(DatabaseString))
			{
				sqlconnect.Open();
				SqlCommand cmd = new SqlCommand("SP_UserDeleteData", sqlconnect);
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@CategoryId", id);
				int a=cmd.ExecuteNonQuery();
				if (a > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

        }

		public DataTable GetUpdateUserCategory(int? id)
		{
			DataTable table=new DataTable();
			using(SqlConnection sqlConnect=new SqlConnection(DatabaseString))
			{
				sqlConnect.Open();
				SqlCommand cmd = new SqlCommand("Sp_GetCategoryUpdataData", sqlConnect);
				cmd.CommandType= CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@CategoryId",id);
				SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
				Adapter.Fill(table);
			}
			return table;
		}

		public bool PostUpdateUserCategory(AddCategory obj)
		{
			try
			{
				using (SqlConnection SqlConnect = new SqlConnection(DatabaseString))
				{
					SqlConnect.Open();
					SqlCommand cmd = new SqlCommand("Sp_PostCategoryUpadateData", SqlConnect);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@CategoryId", obj.CategoryId);
					cmd.Parameters.AddWithValue("@CategoryName", obj.CategoryName);
					cmd.Parameters.AddWithValue("@CategoryCode", obj.CategoryCode);
					cmd.Parameters.AddWithValue("@CategoryDesc", obj.CategoryDesc);
					cmd.Parameters.AddWithValue("@CategoryImg", obj.CategoryImg);
					int x = cmd.ExecuteNonQuery();
					if (x > 0)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch (Exception ex)
			{
				return false;
			}
			
		}


		//------------------------------------Brand Section ------------------------------------
		public DataTable GetBrandData()
		{
			DataTable dt = new DataTable();
			try
			{
				using (SqlConnection sqlConnect = new SqlConnection(DatabaseString))
				{
					sqlConnect.Open();
					SqlCommand cmd = new SqlCommand("Br_GetAllBrand", sqlConnect);
					cmd.CommandType = CommandType.StoredProcedure;
					SqlDataAdapter data = new SqlDataAdapter(cmd);
					data.Fill(dt);

				}
			}
			catch (Exception ex)
			{

			}
			return dt;
		}

		public bool BrandInsertData(BrandClass obj)
		{
			try
			{
				using (SqlConnection SqlConnect = new SqlConnection(DatabaseString))
				{
					SqlConnect.Open();
					SqlCommand cmd = new SqlCommand("Br_AddBrand", SqlConnect);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@BrandName", obj.BrandName);
					cmd.Parameters.AddWithValue("@BrandDisc", obj.BrandDesc);
					cmd.Parameters.AddWithValue("@BrandImgPath", obj.BrandImgPath);
					int x = cmd.ExecuteNonQuery();
					if (x > 0)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch (Exception ex)
			{
				return false; ;
			}
		}

		public bool DeleteBrand(int id)
		{
			using (SqlConnection sqlconnect = new SqlConnection(DatabaseString))
			{
				sqlconnect.Open();
				SqlCommand cmd = new SqlCommand("Br_BrandDelete", sqlconnect);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@BrandId", id);
				int a = cmd.ExecuteNonQuery();
				if (a > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}


		public DataTable GetUpdateUserBrand(int? id)
		{
			DataTable table = new DataTable();
			using (SqlConnection sqlConnect = new SqlConnection(DatabaseString))
			{
				sqlConnect.Open();
				SqlCommand cmd = new SqlCommand("Br_GetBrandData", sqlConnect);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@BrandId", id);
				SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
				Adapter.Fill(table);
			}
			return table;
		}

		public bool PostUpdateBrand(BrandClass obj)
		{
			try
			{
				using (SqlConnection SqlConnect = new SqlConnection(DatabaseString))
				{
					SqlConnect.Open();
					SqlCommand cmd = new SqlCommand("Br_PostBrandData", SqlConnect);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@BrandId", obj.BrandId);
					cmd.Parameters.AddWithValue("@BrandName", obj.BrandName);
					cmd.Parameters.AddWithValue("@BrandDisc", obj.BrandDesc);
					cmd.Parameters.AddWithValue("@BrandImgPath", obj.BrandImgPath);
					int x = cmd.ExecuteNonQuery();
					if (x > 0)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		//-------------------------------------------------------------------------------
		//------------------------------Sub Category Data--------------------------------------
		public bool AddSubCategoryData(SubCategoryDB obj)
		{
			try
			{
				using (SqlConnection SqlConnect = new SqlConnection(DatabaseString))
				{
					SqlConnect.Open();
					SqlCommand cmd = new SqlCommand("Sb_AddSubCategoryData", SqlConnect);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@CategoryId", obj.CategoryId);
					cmd.Parameters.AddWithValue("@SubCategoryName", obj.SubCategoryName);
					cmd.Parameters.AddWithValue("@SubCategoryCode", obj.SubCategoryCode);
					cmd.Parameters.AddWithValue("@SubCategoryDisc", obj.SubCategoryDisc);
					cmd.Parameters.AddWithValue("@SubCategoryImgPath", obj.SubCategoryImgPath);
					int x = cmd.ExecuteNonQuery();
					if (x > 0)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public DataTable GetSubCategoryData()
		{
			DataTable dt = new DataTable();
			try
			{
				using (SqlConnection sqlConnect = new SqlConnection(DatabaseString))
				{
					sqlConnect.Open();
					SqlCommand cmd = new SqlCommand("[Sb_SubCategoryAllData]", sqlConnect);
					cmd.CommandType = CommandType.StoredProcedure;
					SqlDataAdapter data = new SqlDataAdapter(cmd);
					data.Fill(dt);

				}
			}
			catch (Exception ex)
			{

			}
			return dt;
		}
		public bool DeleteSubCategory(int? id)
		{

			using (SqlConnection sqlconnect = new SqlConnection(DatabaseString))
			{
				sqlconnect.Open();
				SqlCommand cmd = new SqlCommand("Sb_DeleteSubCategory", sqlconnect);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@SubCategoryId", id);
				int a = cmd.ExecuteNonQuery();
				if (a > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

		}
		public DataTable GetEditSubCategoryData(int? id)
		{
			DataTable table = new DataTable();
			using (SqlConnection sqlConnect = new SqlConnection(DatabaseString))
			{
				sqlConnect.Open();
				SqlCommand cmd = new SqlCommand("Sb_GetEditSubCategory", sqlConnect);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@SubCategoryId", id);
				SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
				Adapter.Fill(table);
			}
			return table;
		}
		public bool PostEditSubCategoryData(SubCategoryDB subCatObj)
		{
			try
			{
				using (SqlConnection SqlConnect = new SqlConnection(DatabaseString))
				{
					SqlConnect.Open();
					SqlCommand cmd = new SqlCommand("Sb_PostEditSubCategory", SqlConnect);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@SubCategoryId", subCatObj.SubCategoryId);
					cmd.Parameters.AddWithValue("@CategoryId", subCatObj.CategoryId);
					cmd.Parameters.AddWithValue("@SubCategoryName", subCatObj.SubCategoryName);
					cmd.Parameters.AddWithValue("@SubCategoryCode", subCatObj.SubCategoryCode);
					cmd.Parameters.AddWithValue("@SubCategoryDisc", subCatObj.SubCategoryDisc);
					cmd.Parameters.AddWithValue("@SubCategoryImg", subCatObj.SubCategoryImgPath);
					int x = cmd.ExecuteNonQuery();
					if (x > 0)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public DataTable GetSubCategoryData(int? id)
		{
			DataTable dt = new DataTable();
			try
			{
				using (SqlConnection sqlConnect = new SqlConnection(DatabaseString))
				{
					sqlConnect.Open();
					string query = "select * from [tbl-SubCategory] where CategoryId='" + id + "'";
					SqlCommand cmd = new SqlCommand(query, sqlConnect);
					SqlDataAdapter data = new SqlDataAdapter(cmd);
					data.Fill(dt);

				}
			}
			catch (Exception ex)
			{

			}
			return dt;
		}

		//-------------------Login Page-----------------------------------

		public DataTable GetLoginDetails(LoginClass model)
        {
            DataTable dt = new DataTable();
			try
			{
				using (SqlConnection con = new SqlConnection(DatabaseString))
				{
					con.Open();
					SqlCommand cmd = new SqlCommand("Lg_Login", con);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@Username", model.UserName);
					cmd.Parameters.AddWithValue("@Password", model.Password);
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					da.Fill(dt);
				}
			}
			catch (Exception ex)
			{
				throw new NotImplementedException();
			}
            return dt;
        }
        //------------Product------------------------------------------------------------
        public DataTable GetProductData()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlConnect = new SqlConnection(DatabaseString))
                {
                    sqlConnect.Open();
                    SqlCommand cmd = new SqlCommand("Pr_ProductView", sqlConnect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter data = new SqlDataAdapter(cmd);
                    data.Fill(dt);

                }
            }
            catch (Exception ex)
            {
				
            }
            return dt;
        }
        public bool AddProductData(ProductClass obj)
		{
			try
			{
				using (SqlConnection SqlConnect = new SqlConnection(DatabaseString))
				{
					SqlConnect.Open();
					SqlCommand cmd = new SqlCommand("Pr_AddProduct", SqlConnect);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@ProductName", obj.ProductName);
					cmd.Parameters.AddWithValue("@ProductPrice", obj.Price);
					cmd.Parameters.AddWithValue("@Qty", obj.Qty);
					cmd.Parameters.AddWithValue("@TotalPrice", obj.TotalPrice);
					cmd.Parameters.AddWithValue("@ProductDisc", obj.ProductDisc);
					cmd.Parameters.AddWithValue("@ProductImgPath", obj.ProductImg);
					cmd.Parameters.AddWithValue("@CategoryId", obj.CategoryId);
					cmd.Parameters.AddWithValue("@SubCategoryId", obj.SubCategoryId);
					cmd.Parameters.AddWithValue("@BrandId", obj.BrandId);
					int x = cmd.ExecuteNonQuery();
					if (x > 0)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool DataProductDelete(int? Id)
		{
			using (SqlConnection sqlconnect = new SqlConnection(DatabaseString))
			{
				sqlconnect.Open();
				SqlCommand cmd = new SqlCommand("Pr_DeleteProduct", sqlconnect);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ProductId", Id);
				int a = cmd.ExecuteNonQuery();
				if (a > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

		}

		public DataTable ProductEdit(int? id)
		{
			DataTable table = new DataTable();
			using (SqlConnection sqlConnect = new SqlConnection(DatabaseString))
			{
				sqlConnect.Open();
				SqlCommand cmd = new SqlCommand("Pr_GetEditProduct", sqlConnect);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ProductId", id);
				SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
				Adapter.Fill(table);
			}

			return table;
		}

        public bool ProductEditPost(ProductClass obj)
        {
            try
            {
                using (SqlConnection SqlConnect = new SqlConnection(DatabaseString))
                {
                    SqlConnect.Open();
                    SqlCommand cmd = new SqlCommand("Pr_ProductEditData", SqlConnect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductName", obj.ProductName);
                    cmd.Parameters.AddWithValue("@ProductDisc", obj.ProductDisc);
                    cmd.Parameters.AddWithValue("@ProductImgPath", obj.ProductImg);
                    cmd.Parameters.AddWithValue("@ProductPrice", obj.Price);
                    cmd.Parameters.AddWithValue("@TotalPrice", obj.TotalPrice);
                    cmd.Parameters.AddWithValue("@Qty", obj.Qty);
                    cmd.Parameters.AddWithValue("@ProductId", obj.ProductId);
                    cmd.Parameters.AddWithValue("@user", obj.CreateBy);

                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }







        //---------------------Change Password----------------------------------------------------
        public DataTable CheckPassword(ChangePasswordC obj)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(DatabaseString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Cp_CheckPass", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
            return dt;
        }
        public bool ChangePasswords(ChangePasswordC obj)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(DatabaseString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Cp_changePass", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", obj.UserId);
                    cmd.Parameters.AddWithValue("@oldPass", obj.oldpassword);
                    cmd.Parameters.AddWithValue("@newPass", obj.newpassword == null ? "" : obj.newpassword);
                    cmd.Parameters.AddWithValue("@comfirmpass", obj.Confirmpassword);
                    int n = cmd.ExecuteNonQuery();
                    if (n > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

		public DataTable GetCustomerData()
		{
			DataTable dt = new DataTable();
			using (SqlConnection con = new SqlConnection(DatabaseString))
			{
				SqlCommand sqlCommand = new SqlCommand("purchageCustomer", con);
				sqlCommand.CommandType= CommandType.StoredProcedure;
				SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
				adapter.Fill(dt);
			}
			return dt;
		}
//-----------------------------------------------Profile -----------------------------------------------------------------
		public bool UpdateProfile(ProfileClass obj)
		{
			bool d = false;
			try
			{
				using(SqlConnection  con = new SqlConnection(DatabaseString))
				{
					SqlCommand Command = new SqlCommand("", con);
					Command.CommandType=CommandType.StoredProcedure;
					Command.Parameters.AddWithValue("@FirstName",obj.FirstName);
					Command.Parameters.AddWithValue("@LastName",obj.LastName);
					Command.Parameters.AddWithValue("@Email",obj.Email);
					Command.Parameters.AddWithValue("@Phone",obj.Phone);
					Command.Parameters.AddWithValue("@OldUserName",obj.OldUserName);
					Command.Parameters.AddWithValue("@UserName",obj.UserName);
					Command.Parameters.AddWithValue("@Password",obj.Password);
					Command.Parameters.AddWithValue("@PhotoUrl",obj.PhotoUrl);
					int b=Command.ExecuteNonQuery();
					if (b > 0)
					{
						return d;
					}
					else
						return d;
				}
			}
			catch (Exception ex)
			{
				return d;
			}
		}



//----------------------------------Purchase Data And Purchase Item-------------------------------------------
		public bool InsertPurchaseData(PurchageProduct? obj)
		{
			DataTable dt = new DataTable();
			var check = 1;
			try
			{
				using(SqlConnection con = new SqlConnection(DatabaseString))
				{
					SqlCommand cmd = new SqlCommand("purchaseInsertSupplierDetails",con);
					cmd.CommandType= CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@SupplierName", obj.SupplierName);
					cmd.Parameters.AddWithValue("@BillNo", Convert.ToInt32(obj.BillNo));
					cmd.Parameters.AddWithValue("@BillDetails", obj.BillDetails);
					cmd.Parameters.AddWithValue("@PurchageDate", Convert.ToDateTime(obj.PurchageDate));
					cmd.Parameters.AddWithValue("@MobileNo",(int)Convert.ToInt64(obj.Mobile));
					cmd.Parameters.AddWithValue("@CreateBy", obj.CreateBy);
					SqlDataAdapter dl = new SqlDataAdapter(cmd);
					dl.Fill(dt);
					if (dt.Rows.Count > 0)
					{
						var id = dt.Rows[0]["Column1"];
						if (obj.purchageitem.Count > 0)
						{
							foreach (var mod in obj.purchageitem)
							{
								SqlConnection conItem = new SqlConnection(DatabaseString); 
								conItem.Open();
								SqlCommand cmdd = new SqlCommand("purchaseInsert_Item", conItem);
								cmdd.CommandType = CommandType.StoredProcedure;
								cmdd.Parameters.AddWithValue("@purchageId", id);
								cmdd.Parameters.AddWithValue("@ItemName", mod.itemName);
								cmdd.Parameters.AddWithValue("@Qty", mod.Qty);
								cmdd.Parameters.AddWithValue("@purchaseprince", mod.purchaseprince);
								cmdd.Parameters.AddWithValue("@TotalCost", mod.TotalCost);
								int a=cmdd.ExecuteNonQuery();
								if(a > 0)
								{
									continue;
								}
								else
								{
									return false;
								}
							}
							check = 0;
						}
					}										 
				}										
			}
			catch(Exception ex)
			{
				return false;
			}
			return true;
		}
	}
}



   
