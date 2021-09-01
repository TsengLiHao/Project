using Project.ORM;
using Project.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report
{
    public partial class SignUp : System.Web.UI.Page
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

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            MemberInfo memberInfo = new MemberInfo()
            {
                MemberName = this.txtName.Text,
                Account = this.txtAccount.Text,
                PWD = this.txtPWD.Text,
                Email = this.txtEmail.Text,
                MobilePhone = this.txtPhone.Text,
                Adress = this.txtAdress.Text
            };

            if (string.IsNullOrEmpty(txtAccount.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPWD.Text) || string.IsNullOrEmpty(txtDoubleCheck.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtAdress.Text))
            {
                ltlMsg.Text = "輸入項目不能為空白";
                return;
            }

            if (!new System.Text.RegularExpressions.Regex("^[A-Za-z0-9]+$").IsMatch(this.txtAccount.Text))
            {
                this.ltlMsg.Text = "帳號須為英數字所組成";
                return;
            }

            if (this.txtPWD.Text.Length < 8 || this.txtPWD.Text.Length > 16)
            {
                ltlMsg.Text = "密碼長度須為8～16";
                return;
            }

            if (string.Compare(txtDoubleCheck.Text, txtPWD.Text, false) != 0)
            {
                ltlMsg.Text = "請再次確認密碼";
                return;
            }

            MemberManager.CreateMember(memberInfo);

            var member = MemberManager.GetMemberInfoByAccount(memberInfo.Account);

            this.Session["MemberInfo"] = member.Account;

            Response.Redirect("/SystemMember/MemberInfo.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtAccount.Text = string.Empty;
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAdress.Text = string.Empty;
        }
    }
}