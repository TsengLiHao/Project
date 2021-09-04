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
                this.txtProductName.Text = cookie["ProductName"];
                this.txtPrice.Text = cookie["Price"];
                this.txtQuantity.Text = cookie["Quantity"];

                var price = Convert.ToDecimal(this.txtPrice.Text);
                var quantity = Convert.ToInt32(this.txtQuantity.Text);

                this.txtTotal.Text = (price * quantity).ToString();
                this.txtPayment.Text = cookie["Payment"];
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Order orderInfo = new Order()
            {
                Account = this.txtAccount.Text,
                MemberName = this.txtName.Text,
                ProductName = this.txtProductName.Text,
                UnitPrice = Convert.ToDecimal(this.txtPrice.Text),
                OrderedQuantity = Convert.ToInt32(this.txtQuantity.Text),
                Payment = this.txtPayment.Text.ToString()
            };

            if(string.IsNullOrEmpty(this.txtName.Text) || string.IsNullOrEmpty(this.txtEmail.Text) || string.IsNullOrEmpty(this.txtPhone.Text) || string.IsNullOrEmpty(this.txtAdress.Text))
            {
                this.ltlMsg.Text = "輸入項目不可為空";
                return;
            }

            OrderManager.CreateOrder(orderInfo);

            Response.Redirect("/SystemOrder/OrderRecord.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemOrder/OrderPage.aspx");
        }
    }
}