using Project.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report.SystemAdmin
{
    public partial class MemberList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["AdminInfo"] != null)
            {
                this.gvMemberList.DataSource = MemberManager.GetAllMemberList();
                this.gvMemberList.DataBind();
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/Admin.aspx");
        }
    }
}