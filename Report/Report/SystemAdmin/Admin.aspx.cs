using Project.Auth;
using Project.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report.SystemAdmin
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["AdminInfo"] == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            string account = this.Session["AdminInfo"].ToString();

            var Admin = AdminManager.GetAdminInfoByAccount(account);

            AdminInfoModel model = new AdminInfoModel();

            model.AdminID = Admin.AdminID;
            model.AdminAccount = Admin.AdminAccount;
            model.AdminName = Admin.AdminName;


            var AdminList = AdminManager.GetAdminList(Admin.AdminID);

            if (AdminList.Count > 0)
            {
                this.gvAdminList.DataSource = AdminList;
                this.gvAdminList.DataBind();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            this.Session["AdminInfo"] = null;
            Response.Redirect("/Default.aspx");

        }
    }
}