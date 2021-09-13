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
    public partial class StockList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["AdminInfo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

                var stockList = StockManager.GetStockList();

                gvStockList.DataSource = stockList;
                gvStockList.DataBind();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemStock/AddStock.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }
    }
}