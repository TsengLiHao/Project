using Project.ORM;
using Project.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report.SystemStock
{
    public partial class EditStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(this.Session["AdminInfo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }

                var stockID = Convert.ToInt32(Request.QueryString["StockID"]);

                var stockInfo = StockManager.GetStockInfo(stockID);

                this.txtName.Text = stockInfo.ProductName;
                this.txtCurrentValue.Text = stockInfo.CurrentQuantity.ToString();
                this.txtOrderedValue.Text = stockInfo.OrderedQuantity.ToString();
                this.txtExpirationValue.Text = stockInfo.ExpirationQuantity.ToString();
                this.ddlStatus.SelectedValue = stockInfo.ProductStatus.ToString();

            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtName.Text) || string.IsNullOrEmpty(this.txtCurrentValue.Text) || string.IsNullOrEmpty(this.txtOrderedValue.Text) || string.IsNullOrEmpty(this.txtExpirationValue.Text))
            {
                this.ltlMsg.Text = "輸入項目不可為空";
                return;
            }

            string stockIDText = Request.QueryString["StockID"];
            string currentText = this.txtCurrentValue.Text;
            string orderedText = this.txtOrderedValue.Text;
            string expirationText = this.txtExpirationValue.Text;
            string statusText = this.ddlStatus.SelectedValue;

            int stockID = Convert.ToInt32(stockIDText);
            int currentQuantity = Convert.ToInt32(currentText);
            int orderedQuantity = Convert.ToInt32(orderedText);
            int expirationQuantity = Convert.ToInt32(expirationText);
            int productStatus = Convert.ToInt32(statusText);


            Stock stockInfo = new Stock()
            {
                StockID = stockID,
                ProductName = this.txtName.Text,
                CurrentQuantity = currentQuantity,
                OrderedQuantity = orderedQuantity,
                ExpirationQuantity = expirationQuantity,
                ProductStatus = productStatus,
                ChangedDate = DateTime.Now
            };

            if(currentQuantity < 0 || expirationQuantity < 0)
            {
                this.ltlMsg.Text = "輸入數量不可小於0";
                return;
            }

            var getExDay = StockManager.GetExDay();
            if (getExDay != null)
            {
                var targetStockInfo = StockManager.GetStockInfoByProductName(getExDay.ProductName);
                var currentStockID = Request.QueryString["StockID"];
                if(targetStockInfo.StockID == Convert.ToInt32(currentStockID))
                {
                    this.ltlMsg.Text = "請先將販賣商品修正為非即期品再進行數量修改";
                    return;
                }

            }

            StockManager.UpdateStockInfo(stockInfo);

            Response.Redirect("/SystemStock/StockList.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemStock/StockList.aspx");
        }
    }
}