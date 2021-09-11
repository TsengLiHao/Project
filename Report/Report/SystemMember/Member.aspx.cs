using Project.Auth;
using Project.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report.SystemMember
{
    public partial class Member : System.Web.UI.Page
    {
        private const string _orderName = "orderKey";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["MemberInfo"] == null)
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }

                string account = this.Session["MemberInfo"].ToString();

                var Member = MemberManager.GetMemberInfoByAccount(account);

                var memberList = MemberManager.GetMemberList(Member.MemberID);

                if (memberList.Count > 0)
                {
                    this.gvMemberList.DataSource = memberList;
                    this.gvMemberList.DataBind();
                }
                else
                    ltlMsg.Text = "沒有訂單紀錄";
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var account = this.Session["MemberInfo"].ToString();

            var memberInfo = MemberManager.GetMemberInfoByAccount(account);

            var userID = memberInfo.UserID;

            Response.Redirect("/SystemMember/MemberDetail.aspx?UserID=" + userID);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            this.Session["MemberInfo"] = null;
           
            Response.Redirect("/Default.aspx");
        }

    }
}