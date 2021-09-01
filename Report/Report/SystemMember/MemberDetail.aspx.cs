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
    public partial class MemberDetail : System.Web.UI.Page
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
                this.txtName.Text = memberInfo.MemberName;
                this.txtEmail.Text = memberInfo.Email;
                this.txtPhone.Text = memberInfo.MobilePhone;
                this.txtAdress.Text = memberInfo.Adress;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            var account = this.Session["MemberInfo"].ToString();

            var member = MemberManager.GetMemberInfoByAccount(account);

            MemberInfo memberInfo = new MemberInfo()
            {
                MemberID = member.MemberID,
                MemberName = this.txtName.Text,
                Email = this.txtEmail.Text,
                MobilePhone = this.txtPhone.Text,
                Adress = this.txtAdress.Text,
                PWD = member.PWD
            };
            MemberManager.UpdateMember(memberInfo);

            if (string.IsNullOrEmpty(this.txtName.Text) || string.IsNullOrEmpty(this.txtEmail.Text) || string.IsNullOrEmpty(this.txtPhone.Text) || string.IsNullOrEmpty(this.txtAdress.Text))
            {
                this.ltlMsg.Text = "輸入項目不能為空";
                return;
            }

            Response.Redirect("/SystemMember/Member.aspx");
        }

        protected void btnChangePWD_Click(object sender, EventArgs e)
        {
            var account = this.Session["MemberInfo"].ToString();

            var memberInfo = MemberManager.GetMemberInfoByAccount(account);

            var userID = memberInfo.UserID;

            Response.Redirect("/SystemMember/MemberPWD.aspx?UserID=" + userID);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemMember/Member.aspx");
        }
    }
}