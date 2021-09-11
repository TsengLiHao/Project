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
    public partial class MemberList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["AdminInfo"] != null)
            {
                var allMemberList = MemberManager.GetAllMemberList();

                if (allMemberList.Count > 0)
                {
                    var pagedList = this.GetPagedDataTable(allMemberList);

                    this.gvMemberList.DataSource = pagedList;
                    this.gvMemberList.DataBind();
                    
                    this.ucPager.TotalSize = allMemberList.Count;
                    this.ucPager.Bind();
                }
                else
                {
                    this.ucPager.Visible = false;
                    return;
                }
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        private int GetCurrentPage()
        {
            string pageText = Request.QueryString["Page"];

            if (string.IsNullOrWhiteSpace(pageText))
                return 1;
            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;
            if (intPage <= 0)
                return 1;
            return intPage;
        }

        private List<MemberInfo> GetPagedDataTable(List<MemberInfo> list)
        {
            int startIndex = (this.GetCurrentPage() - 1) * 10;
            return list.Skip(startIndex).Take(10).ToList();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }
    }
}