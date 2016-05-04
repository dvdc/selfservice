using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for selfserv
/// </summary>
public class selfserv
{
	public selfserv()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static bool Authenticate(string userName, string password)
    {
        bool authentic = false;
        System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/SelfService");
        System.Configuration.KeyValueConfigurationElement path = rootWebConfig.AppSettings.Settings["path"];
        System.Configuration.KeyValueConfigurationElement domain = rootWebConfig.AppSettings.Settings["domain"];
        string dpath = path.Value;
        string ddomain = domain.Value;

        DirectoryEntry searchEntry = new DirectoryEntry("LDAP://"+ddomain+"/"+dpath, userName, password);

        DirectorySearcher search = new DirectorySearcher(searchEntry);
        search.Filter = "(&(objectclass=user)(objectCategory=person)" +
          "(sAMAccountName=" + userName + "))";

        if (search != null)
        {
            search.PropertiesToLoad.Add("sAMAccountName");
            search.PropertiesToLoad.Add("cn");
            search.PropertiesToLoad.Add("distinguishedName");

            // log.Info("Searching for attributes");

            // find first result
            SearchResult searchResult = null;
            using (SearchResultCollection src = search.FindAll())
            {
                if (src.Count > 0)
                    searchResult = src[0];
            }

            if (searchResult != null)
            {
                // Get DN here
                string DN = searchResult.Properties["distinguishedName"][0].ToString();
                authentic = true;
            }

        }
        return authentic;
    }

    public static void ChangePassword(string userName, string OldPassword, string NewPassword)
    {

        System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/SelfService");
        System.Configuration.KeyValueConfigurationElement path = rootWebConfig.AppSettings.Settings["path"];
        System.Configuration.KeyValueConfigurationElement domain = rootWebConfig.AppSettings.Settings["domain"];
        string dpath = path.Value;
        string ddomain = domain.Value;
        PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, ddomain, dpath);

        //Response.Write(domainContext.ValidateCredentials(userName, OldPassword, ContextOptions.Negotiate));
        UserPrincipal user = UserPrincipal.FindByIdentity(domainContext, userName);
        user.ChangePassword(OldPassword, NewPassword);
        user.Save();

    }
    public static bool PassValidate(string pass1)
    {
        bool pass = false;

        var total = 0;
        var letters = 0;
        var digits = 0;
        var uppers = 0;
        var lowers = 0;
        var symbols = 0;
        foreach (var ch in pass1)
        {
            if (char.IsLetter(ch)) letters++;
            if (char.IsDigit(ch)) digits++;
            if (char.IsUpper(ch)) uppers++;
            if (char.IsLower(ch)) lowers++;
            if (char.IsSymbol(ch)) symbols++;

            if (uppers > 0)
            {
                total++;
            }
            if (lowers > 0)
            {
                total++;
            }
            if (digits > 0)
            {
                total++;
            }
            if (symbols > 0)
            {
                total++;
            }
            if (total > 2)
            {
                pass = true;
                return pass;

            }



        }
        return pass;

    }
}