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
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["AdminInfo"] == null)
            {
                Response.Redirect("/Default.aspx");
                return;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string priceText = this.txtPrice.Text;
            string weightText = this.txtWeight.Text;
            string firstText = this.txtFirstDate.Text;
            string lastText = this.txtLastDate.Text;
            string disText = this.txtDiscontinued.Text;

            decimal price = Convert.ToDecimal(priceText);
            decimal weight = Convert.ToDecimal(weightText);
            DateTime firstDate = Convert.ToDateTime(firstText);
            DateTime lastDate = Convert.ToDateTime(lastText);
            int discontinued = Convert.ToInt32(disText);


            Product newProduct = new Product()
            {
                ProductName = this.txtName.Text,
                UnitPrice = price,
                WeightPerUnit = weight,
                ManufactureDate = firstDate,
                ExpirationDate = lastDate,
                Body = this.txtInfo.Text,
                Discontinued = discontinued
            };

            // 假如有上傳檔案，就寫入檔名
            if (this.fileUpload.HasFile && FileHelper.ValidFileUpload(this.fileUpload, out List<string> tempList))
            {
                string saveFileName = FileHelper.GetNewFileName(this.fileUpload);
                string filePath = Path.Combine(this.GetSaveFolderPath(), saveFileName);
                this.fileUpload.SaveAs(filePath);

                newProduct.Photo = saveFileName;
            }

            if (string.IsNullOrEmpty(this.txtName.Text) || string.IsNullOrEmpty(this.txtPrice.Text) || string.IsNullOrEmpty(this.txtWeight.Text) || string.IsNullOrEmpty(this.txtFirstDate.Text) || string.IsNullOrEmpty(this.txtLastDate.Text) || string.IsNullOrEmpty(this.txtDiscontinued.Text))
            {
                ltlMsg.Text = "輸入項目不能為空白";
                return;
            }

            if (Convert.ToInt32(this.txtDiscontinued.Text) < 0 || Convert.ToInt32(this.txtDiscontinued.Text) > 1)
            {
                this.ltlMsg.Text = "商品狀態請輸入整數 0 或 1";
                return;
            }

            if (!this.fileUpload.HasFile)
            {
                ltlMsg.Text = "請上傳商品照片";
                return;
            }
            var stockInfo = StockManager.GetStockInfoByProductName(this.txtName.Text);
            if(stockInfo == null)
            {
                this.ltlMsg.Text = "此商品並無庫存";
                return;
            }
            ProductManager.CreateProduct(newProduct);

            Response.Redirect("/SystemProduct/ProductList.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }

        private string GetSaveFolderPath()
        {
            return Server.MapPath("~/FileDownload/Admin");
        }
    }
}