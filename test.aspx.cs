using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/SelfService");
       // Response.Write(rootWebConfig.AppSettings.Settings.Count);
       // Response.Write(rootWebConfig.FilePath.ToString());
        System.Configuration.KeyValueConfigurationElement path =
                    rootWebConfig.AppSettings.Settings["path"];
        if (path != null)
            Response.Write(
                path.Value);
        System.Configuration.KeyValueConfigurationElement domain = rootWebConfig.AppSettings.Settings["domain"];
        if (domain != null)
            Response.Write(domain.Value);
    }
}