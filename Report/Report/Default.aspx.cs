using Project.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report
{
    public partial class HP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Session["AdminInfo"] != null)
            {
                this.btnMemberInfo.Visible = true;
                this.btnOrderList.Visible = true;
                this.btnEditProduct.Visible = true;
                this.btnStock.Visible = true;
            }

            var getExDay = StockManager.GetExDay();
            if (getExDay != null)
            {
                var stockInfo = StockManager.GetStockInfoByProductName(getExDay.ProductName);

                stockInfo.ExpirationQuantity += stockInfo.CurrentQuantity;
                stockInfo.CurrentQuantity = 0;
                stockInfo.ProductStatus = 0;

                StockManager.UpdateStockInfo(stockInfo);
            }
        }
        protected void btnMemberInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/MemberList.aspx");
        }

        protected void btnOrderList_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemOrder/AllOrderRecord.aspx");
        }

        protected void btnEditProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemProduct/ProductList.aspx");
        }

        protected void btnStock_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemStock/StockList.aspx");
        }
    }
}