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
            string productIDText = this.HiddenField1.Value;
            string priceText = this.txtPrice.Text;
            string quantityText = this.txtQuantity.Text;

            int productID = Convert.ToInt32(productIDText);
            decimal price = Convert.ToDecimal(priceText);
            int orderedPrice = Convert.ToInt32(quantityText);

            Order orderInfo = new Order()
            {
                Account = this.txtAccount.Text,
                MemberName = this.txtName.Text,
                ProductID = productID,
                ProductName = this.txtProductName.Text,
                UnitPrice = price,
                OrderedQuantity = orderedPrice,
                Payment = this.txtPayment.Text
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