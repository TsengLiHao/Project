using Project.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report.SystemAdmin
{
    public partial class AllOrderEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Session["AdminInfo"] == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var orderID = Convert.ToInt32(Request.QueryString["OrderID"]);

            var orderInfo = OrderManager.GetOrderInfo(orderID);

            this.txtAccount.Text = orderInfo.Account;
            this.txtName.Text = orderInfo.MemberName;
            this.txtProductName.Text = orderInfo.ProductName;
            this.txtPrice.Text = orderInfo.UnitPrice.ToString();
            this.txtQuantity.Text = orderInfo.OrderedQuantity.ToString();
            this.txtTotal.Text = (orderInfo.UnitPrice * orderInfo.OrderedQuantity).ToString();
            this.txtPayment.Text = orderInfo.Payment;
            this.txtDate.Text = orderInfo.OrderDate.ToString();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemOrder/AllOrderRecord.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var orderID = Request.QueryString["OrderID"];

            OrderManager.DeleteOrder(Convert.ToInt32(orderID));

            Response.Redirect("/SystemOrder/AllOrderRecord.aspx");
        }
    }
}