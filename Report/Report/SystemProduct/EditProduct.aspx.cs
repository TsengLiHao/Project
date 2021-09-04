using Project.ORM;
using Project.ORM.DBModels;
using Report.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report.SystemAdmin
{
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["AdminInfo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }

                if (Request.QueryString["ProductID"] != null)
                {
                    var productID = Convert.ToInt32(Request.QueryString["ProductID"]);

                    var productInfo = ProductManager.GetProductInfo(productID);

                    this.txtName.Text = productInfo.ProductName;
                    this.txtPrice.Text = productInfo.UnitPrice.ToString();
                    this.txtWeight.Text = productInfo.WeightPerUnit.ToString();
                    this.txtFirstDate.Text = productInfo.ManufactureDate.ToString();
                    this.txtLastDate.Text = productInfo.ExpirationDate.ToString();
                    this.txtInfo.Text = productInfo.Body;
                    this.txtDiscontinued.Text = productInfo.Discontinued.ToString();
                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Product productUpdate = new Product()
            {
                ProductID = Convert.ToInt32(Request.QueryString["ProductID"]),
                ProductName = this.txtName.Text,
                UnitPrice = Convert.ToDecimal(this.txtPrice.Text),
                WeightPerUnit = Convert.ToDecimal(this.txtWeight.Text),
                ManufactureDate = Convert.ToDateTime(this.txtFirstDate.Text),
                ExpirationDate = Convert.ToDateTime(this.txtLastDate.Text),
                Body = this.txtInfo.Text,
                Discontinued = Convert.ToInt32(this.txtDiscontinued.Text),
                Photo = this.fileUpload.FileName
            };

            if (this.fileUpload.HasFile && FileHelper.ValidFileUpload(this.fileUpload, out List<string> tempList))
            {
                string saveFileName = FileHelper.GetNewFileName(this.fileUpload);
                string filePath = Path.Combine(this.GetSaveFolderPath(), saveFileName);
                this.fileUpload.SaveAs(filePath);

                productUpdate.Photo = saveFileName;
            }

            if (string.IsNullOrEmpty(this.txtName.Text) || string.IsNullOrEmpty(this.txtPrice.Text) || string.IsNullOrEmpty(this.txtWeight.Text) || string.IsNullOrEmpty(this.txtFirstDate.Text) || string.IsNullOrEmpty(this.txtLastDate.Text) || string.IsNullOrEmpty(this.txtDiscontinued.Text))
            {
                ltlMsg.Text = "輸入項目不能為空白";
                return;
            }

            ProductManager.UpdateProduct(productUpdate);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemProduct/ProductList.aspx");
        }
        private string GetSaveFolderPath()
        {
            return Server.MapPath("~/FileDownload/Admin");
        }
    }
}