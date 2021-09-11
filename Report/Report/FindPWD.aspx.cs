using Project.ORM;
using Project.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report.SystemMember
{
    public partial class FindPWD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.txtAccount.Text) || string.IsNullOrEmpty(this.txtName.Text) || string.IsNullOrEmpty(this.txtPhone.Text) || string.IsNullOrEmpty(this.txtEmail.Text) || string.IsNullOrEmpty(this.txtAdress.Text))
            {
                this.ltlMsg.Text = "輸入項目不可為空";
                return;
            }

            var account = MemberManager.GetMemberInfoAccount(this.txtAccount.Text);

            if(account == null)
            {
                this.ltlMsg.Text = "帳號不存在,請重新輸入";
                return;
            }

            var memberInfo = MemberManager.GetMemberInfoByAccount(account);

            if (this.txtName.Text != memberInfo.MemberName)
            {
                this.ltlMsg.Text = "會員名稱不相符,請重新輸入";
                return;
            }


            if (this.txtEmail.Text != memberInfo.Email)
            {
                this.ltlMsg.Text = "Email不相符,請重新輸入";
                return;
            }

            if (this.txtPhone.Text != memberInfo.MobilePhone)
            {
                this.ltlMsg.Text = "手機號碼不相符,請重新輸入";
                return;
            }

            if (this.txtAdress.Text != memberInfo.Adress)
            {
                this.ltlMsg.Text = "地址資訊不相符,請重新輸入";
                return;
            }

            Response.Write("<script>alert('請前往信箱確認郵件')</script>");

            Email($"<h3>Password is {memberInfo.PWD}.<h3>");
            
            Response.Write("<script type='text/javascript'>location.href='Login.aspx'</script>");
        }
        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }

        public void Email(string htmlString)
        {
            var account = MemberManager.GetMemberInfoAccount(this.txtAccount.Text);
            var memberInfo = MemberManager.GetMemberInfoByAccount(account);
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("x95175399@gmail.com");
                message.To.Add(new MailAddress($"{memberInfo.Email}"));
                message.Subject = "Send PWD Mail";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("x95175399@gmail.com", "jj895589");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return;
            }
        }
    }
}