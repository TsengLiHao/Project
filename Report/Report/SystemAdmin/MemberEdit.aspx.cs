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
    public partial class MemberEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (this.Session["AdminInfo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }


                var userIDText = Request.QueryString["UserID"];

                if (userIDText == null)
                {
                    Response.Redirect("/SystemAdmin/MemberList.aspx");
                    return;
                }

                int.TryParse(userIDText, out int id);

                var currentUser = MemberManager.GetMemberInfoByUserID(id);

                this.txtAccount.Text = currentUser.Account;
                this.txtName.Text = currentUser.MemberName;
                this.txtEmail.Text = currentUser.Email;
                this.txtPhone.Text = currentUser.MobilePhone;
                this.txtAdress.Text = currentUser.Adress;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            var userIDText = Request.QueryString["UserID"];

            int.TryParse(userIDText, out int id);

            var currentUser = MemberManager.GetMemberInfoByUserID(id);

            MemberInfo memberInfo = new MemberInfo()
            {
                MemberID = currentUser.MemberID,
                MemberName = currentUser.MemberName,
                PWD = this.txtPWD.Text,
                Email = this.txtEmail.Text,
                MobilePhone = this.txtPhone.Text,
                Adress = this.txtAdress.Text
            };

            if (string.IsNullOrEmpty(this.txtPWD.Text) || string.IsNullOrEmpty(this.txtEmail.Text) || string.IsNullOrEmpty(this.txtPhone.Text) || string.IsNullOrEmpty(this.txtAdress.Text))
            {
                this.ltlMsg.Text = "輸入項目不能為空";
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

            var emailList = MemberManager.GetMemberEmail();

            if (emailList.Contains(this.txtEmail.Text))
            {
                this.ltlMsg.Text = "Email名稱已重複,請重新輸入";
                return;
            }

            var phoneList = MemberManager.GetMemberPhone();

            if (phoneList.Contains(this.txtPhone.Text))
            {
                this.ltlMsg.Text = "手機號碼已重複,請重新輸入";
                return;
            }

            MemberManager.UpdateMember(memberInfo);

            Response.Redirect("/SystemAdmin/MemberList.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/MemberList.aspx");
        }
    }
}