using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Global
/// </summary>
public class Global:System.Web.HttpApplication
{
	public Global()
	{

	}
    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.IsSecureConnection.Equals(false) && HttpContext.Current.Request.IsLocal.Equals(false))
        {
            Response.Redirect("https://" + Request.ServerVariables["HTTP_HOST"]
        + HttpContext.Current.Request.RawUrl);
        }
    }
}