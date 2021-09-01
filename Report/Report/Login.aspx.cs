using Project.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["AdminInfo"] != null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (this.Session["MemberInfo"] != null)
            {
                Response.Redirect("/Default.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var account = txtAccount.Text;
            var pwd = txtPWD.Text;

            if (string.IsNullOrWhiteSpace(account) ||
                string.IsNullOrWhiteSpace(pwd))
            {
                ltlMsg.Text = "帳號密碼不能為空";
                return;
            }

            var member = MemberManager.GetMemberInfoByAccount(account);

            if (member == null)
            {
                ltlMsg.Text = "帳號不存在或輸入錯誤";
                return;
            }

            if (string.Compare(member.Account, account, true) == 0 && string.Compare(member.PWD, pwd, false) == 0)
            {
                this.Session["MemberInfo"] = member.Account;

                Response.Redirect("/SystemMember/Member.aspx");
            }
            else
            {
                ltlMsg.Text = "登入失敗,請確認帳號密碼是否正確輸入";
                return;
            }
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            var account = txtAccount.Text;
            var pwd = txtPWD.Text;

            if (string.IsNullOrWhiteSpace(account) ||
                string.IsNullOrWhiteSpace(pwd))
            {
                ltlMsg.Text = "帳號密碼不能為空";
                return;
            }


            var admin = AdminManager.GetAdminInfoByAccount(account);


            if (admin == null)
            {
                ltlMsg.Text = "帳號不存在或輸入錯誤";
                return;
            }


            if (string.Compare(admin.AdminAccount, account, true) == 0 && string.Compare(admin.AdminPWD, pwd, false) == 0)
            {
                this.Session["AdminInfo"] = admin.AdminAccount;

                Response.Redirect("/SystemAdmin/Admin.aspx");
            }
            else
            {
                ltlMsg.Text = "登入失敗,請確認帳號密碼是否正確輸入";
                return;
            }
        }

        protected void btnForgetPWD_Click(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SignUp.aspx");
        }
    }
}