using Project.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report
{
    public partial class OrderPage : System.Web.UI.Page
    {
        private const string _orderName = "orderKey";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var productList = ProductManager.GetProductList();

                ddlProduct.DataSource = productList;
                ddlProduct.DataTextField = "ProductName";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--"));

                if (this.Session["AdminInfo"] != null)
                {
                    this.btnConfirm.Visible = false;
                }
            }
        }

        protected void ddlProduct_TextChanged(object sender, EventArgs e)
        {
                this.ltlMsg.Text = "";
            
            var productInfo = ProductManager.GetProductInfoByName(ddlProduct.SelectedValue);

            var stockInfo = StockManager.GetStockInfoByProductName(ddlProduct.SelectedValue);

            if (productInfo != null)
            {
                PlaceHolder1.Visible = true;
                this.txtValue.Visible = true;
                this.rblPayment.Visible = true;

                this.HiddenField1.Value = productInfo.ProductID.ToString();
                this.ltlPrice.Text = productInfo.UnitPrice.ToString();
                this.ltlWeight.Text = $"{productInfo.WeightPerUnit} kg";
                this.ltlFirst.Text = productInfo.ManufactureDate.ToShortDateString();
                this.ltlLast.Text = productInfo.ExpirationDate.ToShortDateString();
                this.TextBox1.Text = productInfo.Body;
                this.Image1.ImageUrl = $"/FileDownload/Admin/{productInfo.Photo}" ;

                TimeSpan day = productInfo.ExpirationDate.Subtract(DateTime.Today);

                if (day.TotalDays < 14)
                {
                    productInfo.Discontinued = 0;
                    StockManager.UpdateStockByExpiration();
                }

                if(DateTime.Today > productInfo.ExpirationDate)
                {
                    stockInfo.ProductStatus = 0;
                }

                if(stockInfo.CurrentQuantity <= 5)
                {
                    this.ltlProductStatus.Text = $"此商品現在剩餘數量 : {stockInfo.CurrentQuantity}";
                }
                else
                {
                    this.ltlProductStatus.Text = "";
                }

                if (productInfo.Discontinued == 0 || stockInfo.CurrentQuantity == 0 || stockInfo.ProductStatus == 0)
                {
                    PlaceHolder1.Visible = false;
                    this.ltlProductStatus.Text = "此商品目前暫時下架";
                    return;
                }
            }
            else
            {
                PlaceHolder1.Visible = false;
                this.Image1.ImageUrl = "";
            }
                
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if(this.Session["MemberInfo"] == null)
            {
                Response.Write("<script>alert('請先登入後再進行購買')</script>");
                return;
            }

            if (this.txtValue.Text == string.Empty)
            {
                this.ltlMsg.Text = "請輸入商品數量";
                return;
            }


            var value = this.txtValue.Text;

            if (!int.TryParse(value, out int tempValue))
            {
                this.ltlMsg.Text = "請輸入整數";
                return;
            }

            var productInfo = ProductManager.GetProductInfoByName(ddlProduct.SelectedValue);

            var stockInfo = StockManager.GetStockInfoByProductName(productInfo.ProductName);

            if (Convert.ToInt32(this.txtValue.Text) > stockInfo.CurrentQuantity)
            {
                this.ltlMsg.Text = "選擇數量大於庫存數量,請重新輸入";
                return;
            }

            var currentUserAccount = this.Session["MemberInfo"].ToString();

            var memberInfo = MemberManager.GetMemberInfoByAccount(currentUserAccount);

            HttpCookie cookie = new HttpCookie(_orderName);

            cookie["MemberName"] = memberInfo.MemberName;
            cookie["Account"] = memberInfo.Account;
            cookie["Email"] = memberInfo.Email;
            cookie["MobilePhone"] = memberInfo.MobilePhone;
            cookie["Adress"] = memberInfo.Adress;
            cookie["ProductID"] = this.HiddenField1.Value;
            cookie["ProductName"] = this.ddlProduct.SelectedItem.Text;
            cookie["Price"] = this.ltlPrice.Text;
            cookie["Quantity"] = this.txtValue.Text;
            cookie["Payment"] = HttpUtility.UrlEncode(this.rblPayment.SelectedItem.Text);

            cookie.Expires = DateTime.Now.AddHours(1);
            cookie.HttpOnly = true;
            Response.Cookies.Add(cookie);

            Response.Redirect("/SystemOrder/CheckOrder.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }

    }
}