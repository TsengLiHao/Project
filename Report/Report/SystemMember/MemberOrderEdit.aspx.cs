using Project.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report.SystemMember
{
    public partial class MemberOrderEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["MemberInfo"] == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            var currentAccount = this.Session["MemberInfo"].ToString();

            var orderInfo = OrderManager.GetOrderInfoByAccount(currentAccount);

            this.txtAccount.Text = orderInfo.Account;
            this.txtName.Text = orderInfo.MemberName;
            this.txtProductName.Text = orderInfo.ProductName;
            this.txtPrice.Text = orderInfo.UnitPrice.ToString();
            this.txtQuantity.Text = orderInfo.OrderedQuantity.ToString();
            this.txtPayment.Text = orderInfo.Payment.ToString();
            this.txtTotal.Text = (orderInfo.UnitPrice * orderInfo.OrderedQuantity).ToString();
            this.txtDate.Text = orderInfo.OrderDate.ToString();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            var orderID = Request.QueryString["OrderID"];

            OrderManager.DeleteOrder(Convert.ToInt32(orderID));

            Response.Redirect("/SystemOrder/OrderRecord.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemOrder/OrderRecord.aspx");
        }
    }
}