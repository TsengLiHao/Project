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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["MemberInfo"] == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            string account = this.Session["MemberInfo"].ToString();

            var Member = MemberManager.GetMemberInfoByAccount(account);

            MemberInfoModel model = new MemberInfoModel();

            model.MemberID = Member.MemberID;
            model.Account = Member.Account;
            model.MemberName = Member.MemberName;
            model.Email = Member.Email;
            model.MobilePhone = Member.MobilePhone;
            model.Adress = Member.Adress;

            if (this.Session["MemberInfo"] != null)
            {
                var memberList = MemberManager.GetMemberList(model.MemberID);

                if (memberList.Count > 0)
                {
                    this.gvMemberList.DataSource = memberList;
                    this.gvMemberList.DataBind();
                }
                else
                    ltlMsg.Text = "NO DATA";
            }
            else if (this.Session["AdminInfo"] != null)
            {
                var allMemberList = MemberManager.GetAllMemberList();

                if (allMemberList.Count > 0)
                {
                    this.gvMemberList.DataSource = allMemberList;
                    this.gvMemberList.DataBind();
                }
                else
                    ltlMsg.Text = "NO DATA";
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