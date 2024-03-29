﻿using Project.Auth;
using Project.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Report.SystemOrder
{
    public partial class OrderRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Session["MemberInfo"] == null && this.Session["AdminInfo"] == null)
            {
                this.ltlMsg.Text = "沒有訂單紀錄";
                return;
            }

            if (this.Session["MemberInfo"] != null)
            {
                var currentAccount = this.Session["MemberInfo"].ToString();

                var OrderInfo = OrderManager.GetOrderListByAccount(currentAccount);

                if (OrderInfo.Count > 0)
                {
                    this.gvOrderList.DataSource = OrderInfo;
                    this.gvOrderList.DataBind();
                }
                else
                {
                    this.ltlMsg.Text = "沒有訂單紀錄";
                    return;
                }
            }
            else
            {
                this.ltlMsg.Text = "會員個人訂單紀錄頁面";
                return;
            }


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }
    }
}