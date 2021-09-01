using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgBtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            if (this.Session["AdminInfo"] != null)
            {
                Response.Redirect("/SystemAdmin/Admin.aspx");
            }

            if (this.Session["MemberInfo"] != null)
            {
                Response.Redirect("/SystemMember/Member.aspx");
            }

            Response.Redirect("/Login.aspx");
        }

        protected void imgBtnLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }
    }
}