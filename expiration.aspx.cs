using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices.ActiveDirectory;

public partial class expiration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        string uName = UserName.Text;
        string uPass = OldPass.Text;


        System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/SelfService");
        System.Configuration.KeyValueConfigurationElement path = rootWebConfig.AppSettings.Settings["path"];
        System.Configuration.KeyValueConfigurationElement domain = rootWebConfig.AppSettings.Settings["domain"];
        string dpath = path.Value;
        string ddomain = domain.Value;
        DirectoryEntry entry = new DirectoryEntry("LDAP://"+ddomain+"/"+dpath, uName, uPass);

        Response.Write(GetExpiration(entry));


    }

    public DateTime GetExpiration(DirectoryEntry user)
    {
        //Int64 flags =
        //(Int64)user.Properties["userAccountControl"][0];

        long ticks = GetInt64(user, "pwdLastSet");
        long ticks2 = GetInt64(user, "maxPwdAge");
        //user must change password at next login
        if (ticks == 0)
            return DateTime.MinValue;
        //password has never been set
        if (ticks == -1)
        {
            throw new InvalidOperationException(
            "User does not have a password"
            );
        }
            //get when the user last set their password;
            DateTime pwdLastSet = DateTime.FromFileTime(
            ticks
            );
            TimeSpan maxPwdAge = TimeSpan.FromTicks(
                ticks2
                );
            //use our policy class to determine when
            //it will expire
            return pwdLastSet.Add(maxPwdAge);
        
    }

    private Int64 GetInt64(DirectoryEntry entry, string attr)
    {
        //we will use the marshaling behavior of
        //the searcher
        DirectorySearcher ds = new DirectorySearcher(
        entry,
        String.Format("({0}=*)", attr),
        new string[] { attr },
        SearchScope.Base
        );
        SearchResult sr = ds.FindOne();
        if (sr != null)
        {
            if (sr.Properties.Contains(attr))
            {
                return (Int64)sr.Properties[attr][0];
            }
        }
        return -1;
    }

   
}