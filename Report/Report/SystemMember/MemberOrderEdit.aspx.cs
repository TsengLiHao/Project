using Project.ORM;
using Project.ORM.DBModels;
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

            var orderID = Convert.ToInt32(Request.QueryString["OrderID"]);

            var orderInfo = OrderManager.GetOrderInfo(orderID);

            this.txtAccount.Text = orderInfo.Account;
            this.txtName.Text = orderInfo.MemberName;
            this.HiddenField1.Value = orderInfo.ProductID.ToString();
            this.txtProductName.Text = orderInfo.ProductName;
            this.txtPrice.Text = orderInfo.UnitPrice.ToString();
            this.txtQuantity.Text = orderInfo.OrderedQuantity.ToString();
            this.txtPayment.Text = orderInfo.Payment.ToString();
            this.txtTotal.Text = (orderInfo.UnitPrice * orderInfo.OrderedQuantity).ToString();
            this.txtDate.Text = orderInfo.OrderDate.ToString();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Order orderInfo = new Order()
            {
                Account = this.txtAccount.Text,
                MemberName = this.txtName.Text,
                ProductID = Convert.ToInt32(this.HiddenField1.Value),
                ProductName = this.txtProductName.Text,
                UnitPrice = Convert.ToDecimal(this.txtPrice.Text),
                OrderedQuantity = Convert.ToInt32(this.txtQuantity.Text),
                Payment = this.txtPayment.Text.ToString()
            };

            var orderID = Request.QueryString["OrderID"];

            OrderManager.DeleteOrder(Convert.ToInt32(orderID));
            StockManager.UpdateStockByCancel(orderInfo);

            Response.Redirect("/SystemOrder/OrderRecord.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemOrder/OrderRecord.aspx");
        }
    }
}