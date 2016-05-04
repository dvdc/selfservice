using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void captchaBtn_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            HttpCookie capCookie = new HttpCookie("CapCookie");
            capCookie["Human"] = "yes";
            capCookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(capCookie);
            Response.Redirect("change.aspx");
        }
        else
        {
            captchaLbl.Visible = true;
        }
    }
    protected void humanBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("unhuman.aspx");
    }
}