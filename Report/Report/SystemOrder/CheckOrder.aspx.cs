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
            if (!IsPostBack)
            {
                if (this.Session["MemberInfo"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                var cookie = Request.Cookies[_orderName];
                if (cookie == null)
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
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            var account = this.Session["MemberInfo"].ToString();

            var member = MemberManager.GetMemberInfoByAccount(account);

            MemberInfo memberInfo = new MemberInfo()
            {
                MemberID = member.MemberID,
                Account = this.txtAccount.Text,
                MemberName = this.txtName.Text,
                Email = this.txtEmail.Text,
                MobilePhone = this.txtPhone.Text,
                Adress = this.txtAdress.Text,
                PWD = member.PWD
            };

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

            if (this.txtName.Text.Length > 10)
            {
                this.ltlMsg.Text = "輸入的名稱過長,請重新輸入";
                return;
            }

            if (this.txtPhone.Text.Length != 10)
            {
                this.ltlMsg.Text = "手機號碼長度須為10碼";
                return;
            }

            var emailList = MemberManager.GetMemberEmail();

            if (emailList.Contains(this.txtEmail.Text))
            {
                if (this.txtEmail.Text != member.Email)
                {
                    this.ltlMsg.Text = "Email名稱已重複,請重新輸入";
                    return;
                }
            }

            var phoneList = MemberManager.GetMemberPhone();

            if (phoneList.Contains(this.txtPhone.Text))
            {
                if (this.txtPhone.Text != member.MobilePhone)
                {
                    this.ltlMsg.Text = "手機號碼已重複,請重新輸入";
                    return;
                }
            }

            OrderManager.CreateOrder(orderInfo);
            StockManager.UpdateStockByOrder(orderInfo);
            MemberManager.UpdateMember(memberInfo);

            Response.Cookies["orderKey"].Expires = DateTime.Now.AddDays(-1);

            Response.Write("<script>alert('訂購成功!!')</script>");

            Response.Write("<script type='text/javascript'>location.href='OrderRecord.aspx'</script>");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Cookies["orderKey"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/SystemOrder/OrderPage.aspx");
        }
    }
}