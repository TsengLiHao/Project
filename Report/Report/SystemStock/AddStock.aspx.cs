using Project.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report.SystemStock
{
    public partial class AddStock : System.Web.UI.Page
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
            string currentText = this.txtCurrent.Text;
            string orderedText = this.txtOrdered.Text;
            string statusText = this.txtStatus.Text;

            int currentQuantity = Convert.ToInt32(currentText);
            int orderedQuantity = Convert.ToInt32(orderedText);
            int productStatus = Convert.ToInt32(statusText);

            Stock stockInfo = new Stock()
            {
                ProductName = this.txtName.Text,
                CurrentQuantity = currentQuantity,
                OrderedQuantity = orderedQuantity,
                ProductStatus = productStatus
            };

            if (Convert.ToInt32(this.txtStatus.Text) < 0 || Convert.ToInt32(this.txtStatus.Text) > 1)
            {
                this.ltlMsg.Text = "商品狀態請輸入整數 0 或 1";
                return;
            }

            if (string.IsNullOrEmpty(this.txtName.Text) || string.IsNullOrEmpty(this.txtCurrent.Text) || string.IsNullOrEmpty(this.txtOrdered.Text) || string.IsNullOrEmpty(this.txtStatus.Text))
            {
                this.ltlMsg.Text = "輸入項目不可為空";
                return;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemStock/StockList.aspx");
        }
    }
}