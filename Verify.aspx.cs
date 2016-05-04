using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

public partial class Verify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        string uName = UserName.Text;
        string oPass = OldPass.Text;


        try
        {
            bool verify = selfserv.Authenticate(uName, oPass); 
            if (verify == true)
            {
                verifyLable.Text = "Valid username and password!";
                verifyLable.Visible = true;
            }
            else
            {
                verifyLable.Text = "Username and password combination is not valid.";
                verifyLable.Visible = true;
            }
        }
        catch (System.DirectoryServices.DirectoryServicesCOMException E)
        {
            //Response.Write(E.Message.ToString());
            verifyLable.Text = E.Message.ToString();
            verifyLable.Visible = true;
        }

    }
    
}