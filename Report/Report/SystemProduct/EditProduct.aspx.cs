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
            if (string.IsNullOrEmpty(this.txtName.Text) || string.IsNullOrEmpty(this.txtPrice.Text) || string.IsNullOrEmpty(this.txtWeight.Text) || string.IsNullOrEmpty(this.txtFirstDate.Text) || string.IsNullOrEmpty(this.txtLastDate.Text) || string.IsNullOrEmpty(this.txtDiscontinued.Text))
            {
                ltlMsg.Text = "輸入項目不能為空白";
                return;
            }

            string productIDText = Request.QueryString["ProductID"];
            string priceText = this.txtPrice.Text;
            string weightText = this.txtWeight.Text;
            string firstText = this.txtFirstDate.Text;
            string lastText = this.txtLastDate.Text;
            string disText = this.txtDiscontinued.Text;

            int productID = Convert.ToInt32(productIDText);
            decimal price = Convert.ToDecimal(priceText);
            decimal weight = Convert.ToDecimal(weightText);
            DateTime firstDate = Convert.ToDateTime(firstText);
            DateTime lastDate = Convert.ToDateTime(lastText);
            int discontinued = Convert.ToInt32(disText);

            Product productUpdate = new Product()
            {
                ProductID = productID,
                ProductName = this.txtName.Text,
                UnitPrice = price,
                WeightPerUnit = weight,
                ManufactureDate = firstDate,
                ExpirationDate = lastDate,
                Body = this.txtInfo.Text,
                Discontinued = discontinued,
                Photo = this.fileUpload.FileName
            };

            if (this.fileUpload.HasFile && FileHelper.ValidFileUpload(this.fileUpload, out List<string> tempList))
            {
                string saveFileName = FileHelper.GetNewFileName(this.fileUpload);
                string filePath = Path.Combine(this.GetSaveFolderPath(), saveFileName);
                this.fileUpload.SaveAs(filePath);

                productUpdate.Photo = saveFileName;
            }

            ProductManager.UpdateProduct(productUpdate);
            Response.Redirect("/SystemProduct/ProductList.aspx");
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