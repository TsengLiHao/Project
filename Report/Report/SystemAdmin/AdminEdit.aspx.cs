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
    public partial class AdminEdit : System.Web.UI.Page
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

                var adminAccount = this.Session["AdminInfo"].ToString();

                var adminInfo = AdminManager.GetAdminInfoByAccount(adminAccount);

                this.txtAccount.Text = adminInfo.AdminAccount;
                this.txtName.Text = adminInfo.AdminName;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            var adminID = Guid.Parse(Request.QueryString["AdminID"]);

            var currentAdmin = AdminManager.GetAdminInfoByID(adminID);

            AdminInfo adminInfo = new AdminInfo()
            {
                AdminID = adminID,
                AdminAccount = this.txtAccount.Text,
                AdminName = this.txtName.Text,
                AdminPWD = this.txtPWD.Text
            };

            if(string.IsNullOrEmpty(this.txtAccount.Text) || string.IsNullOrEmpty(this.txtName.Text) || string.IsNullOrEmpty(this.txtPWD.Text) || string.IsNullOrEmpty(this.txtDoubleCheck.Text))
            {
                this.ltlMsg.Text = "輸入項目不可為空";
                return;
            }

            if (this.txtPWD.Text.Length < 8 || this.txtPWD.Text.Length > 16)
            {
                this.ltlMsg.Text = "密碼長度須為8～16";
                return;
            }

            if (string.Compare(this.txtPWD.Text, this.txtDoubleCheck.Text, false) != 0)
            {
                this.ltlMsg.Text = "密碼的確認有誤 , 請重新輸入";
                return;
            }

            AdminManager.UpdateAdmin(adminInfo);

            Response.Redirect("/SystemAdmin/Admin.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/AdminEdit.aspx");
        }
    }
}