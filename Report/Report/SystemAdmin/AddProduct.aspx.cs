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
            Product newProduct = new Product()
            {
                ProductName = this.txtName.Text,
                UnitPrice = Convert.ToDecimal(this.txtPrice.Text),
                WeightPerUnit = Convert.ToDecimal(this.txtWeight.Text),
                ManufactureDate = Convert.ToDateTime(this.txtFirstDate.Text),
                ExpirationDate = Convert.ToDateTime(this.txtLastDate.Text),
                Body = this.txtInfo.Text,
                Discontinued = Convert.ToInt32(this.txtDiscontinued.Text)
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