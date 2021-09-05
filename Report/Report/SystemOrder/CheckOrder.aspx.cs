using Project.ORM;
using Project.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report.SystemOrder
{
    public partial class CheckOrder : System.Web.UI.Page
    {
        private const string _orderName = "orderKey";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Session["MemberInfo"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            var cookie = Request.Cookies[_orderName];
            if(cookie == null)
            {
                this.ltlMsg.Text = "Cookie 不存在";
            }
            else
            {
                this.txtName.Text = cookie["MemberName"];
                this.txtAccount.Text = cookie["Account"];
                this.txtEmail.Text = cookie["Email"];
                this.txtPhone.Text = cookie["MobilePhone"];
                this.txtAdress.Text = cookie["Adress"];
                this.HiddenField1.Value = cookie["ProductID"];
                this.txtProductName.Text = cookie["ProductName"];
                this.txtPrice.Text = cookie["Price"];
                this.txtQuantity.Text = cookie["Quantity"];

                var price = Convert.ToDecimal(this.txtPrice.Text);
                var quantity = Convert.ToInt32(this.txtQuantity.Text);

                this.txtTotal.Text = (price * quantity).ToString();
                this.txtPayment.Text = HttpUtility.UrlDecode(cookie["Payment"]);
            }
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

            if(string.IsNullOrEmpty(this.txtName.Text) || string.IsNullOrEmpty(this.txtEmail.Text) || string.IsNullOrEmpty(this.txtPhone.Text) || string.IsNullOrEmpty(this.txtAdress.Text))
            {
                this.ltlMsg.Text = "輸入項目不可為空";
                return;
            }

            OrderManager.CreateOrder(orderInfo);
            StockManager.UpdateStockByOrder(orderInfo);

            Response.Cookies["orderKey"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/SystemOrder/OrderRecord.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Cookies["orderKey"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/SystemOrder/OrderPage.aspx");
        }
    }
}