using Project.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report.SystemAdmin
{
    public partial class AllOrderRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["AdminInfo"] != null)
            {
                var AllOrderInfo = OrderManager.GetAllOrderList();

                if (AllOrderInfo.Count > 0)
                {
                    this.gvOrderList.DataSource = AllOrderInfo;
                    this.gvOrderList.DataBind();
                }
                else
                {
                    this.ltlMsg.Text = "No Record";
                    return;
                }
            }
            else
            {
                Response.Redirect("/Default.aspx");
                return;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }
    }
}