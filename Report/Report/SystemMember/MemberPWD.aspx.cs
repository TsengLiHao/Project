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
    public partial class MemberPWD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["MemberInfo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

                var account = this.Session["MemberInfo"].ToString();

                var memberInfo = MemberManager.GetMemberInfoByAccount(account);

                this.txtAccount.Text = memberInfo.Account;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            var account = this.Session["MemberInfo"].ToString();

            var member = MemberManager.GetMemberInfoByAccount(account);

            MemberInfo memberInfo = new MemberInfo()
            {
                MemberID = member.MemberID,
                MemberName = member.MemberName,
                Email = member.Email,
                MobilePhone = member.MobilePhone,
                Adress = member.Adress,
                PWD = this.txtNewPWD.Text
            };

            if (string.IsNullOrEmpty(this.txtPWD.Text) || string.IsNullOrEmpty(this.txtNewPWD.Text) || string.IsNullOrEmpty(this.txtDoubleCheck.Text))
            {
                this.ltlMsg.Text = "輸入項目不能為空";
                return;
            }

            if (!new System.Text.RegularExpressions.Regex("^[A-Za-z0-9]+$").IsMatch(this.txtNewPWD.Text))
            {
                this.ltlMsg.Text = "密碼須為英數字所組成";
                return;
            }

            if (string.Compare(this.txtPWD.Text, member.PWD, false) != 0)
            {
                this.ltlMsg.Text = "請確認舊密碼是否輸入錯誤";
                return;
            }

            if (this.txtNewPWD.Text.Length < 8 || this.txtNewPWD.Text.Length > 16)
            {
                this.ltlMsg.Text = "密碼長度須為8～16";
                return;
            }

            if (string.Compare(this.txtNewPWD.Text, this.txtDoubleCheck.Text, false) != 0)
            {
                this.ltlMsg.Text = "新密碼的確認有誤 , 請重新輸入";
                return;
            }

            MemberManager.UpdateMember(memberInfo);

            Response.Redirect("/SystemMember/Member.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemMember/MemberDetail.aspx");
        }
    }
}