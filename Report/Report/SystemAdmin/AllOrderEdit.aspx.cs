using Project.ORM;
using Project.ORM.DBModels;
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
            if (!IsPostBack)
            {
                if (this.Session["AdminInfo"] == null)
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
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtQuantity.Text))
            {
                this.ltlMsg.Text = "輸入項目不能為空";
                return;
            }

            string orderIDText = Request.QueryString["OrderID"];
            string priceText = this.txtPrice.Text;
            string quantityText = this.txtQuantity.Text;

            int orderID = Convert.ToInt32(orderIDText);
            decimal price = Convert.ToDecimal(priceText);
            int quantity = Convert.ToInt32(quantityText);


            Order orderInfo = new Order()
            {
                OrderID = orderID,
                Account = this.txtAccount.Text,
                MemberName = this.txtName.Text,
                ProductName = this.txtProductName.Text,
                UnitPrice = price,
                OrderedQuantity = quantity,
                Payment = this.txtPayment.Text
            };

            var stockInfo = StockManager.GetStockInfoByProductName(orderInfo.ProductName);


            if(quantity > stockInfo.CurrentQuantity)
            {
                this.ltlMsg.Text = "輸入數量大於商品庫存量,請重新輸入";
                return;
            }

            var orderText = OrderManager.GetOrderInfo(Convert.ToInt32(orderIDText));

            var originOrderQuantity = orderText.OrderedQuantity;

            OrderManager.UpdateOrder(orderInfo);
            StockManager.UpdateStockByRevise(orderInfo, originOrderQuantity);

            Response.Redirect("/SystemOrder/AllOrderRecord.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemOrder/AllOrderRecord.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtQuantity.Text))
            {
                this.ltlMsg.Text = "請輸入商品數量";
                return;
            }

            string priceText = this.txtPrice.Text;
            string quantityText = this.txtQuantity.Text;

            decimal price = Convert.ToDecimal(priceText);
            int quantity = Convert.ToInt32(quantityText);

            Order orderInfo = new Order()
            {
                Account = this.txtAccount.Text,
                MemberName = this.txtName.Text,
                ProductName = this.txtProductName.Text,
                UnitPrice = price,
                OrderedQuantity = quantity,
                Payment = this.txtPayment.Text
            };

            var orderID = Request.QueryString["OrderID"];

            var orderText = OrderManager.GetOrderInfo(Convert.ToInt32(orderID));

            var originOrderQuantity = orderText.OrderedQuantity;

            OrderManager.DeleteOrder(Convert.ToInt32(orderID));
            StockManager.UpdateStockByDelete(orderInfo, originOrderQuantity);

            Response.Redirect("/SystemOrder/AllOrderRecord.aspx");
        }

        protected void btnCal_Click(object sender, EventArgs e)
        {
            var price = Convert.ToDecimal(this.txtPrice.Text);
            var quantity = Convert.ToInt32(this.txtQuantity.Text);
            this.txtTotal.Text = (price * quantity).ToString();

        }
    }
}