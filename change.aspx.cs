using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.IO;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ErrorLable.ForeColor = System.Drawing.Color.Red;
        ErrorLable.Font.Bold = true;
        FVNewPass1.ForeColor = System.Drawing.Color.Red;
        FVNewPass1.Font.Bold = true;
        FVNewPass2.ForeColor = System.Drawing.Color.Red;
        FVNewPass2.Font.Bold = true;
        FVOldPass.ForeColor = System.Drawing.Color.Red;
        FVOldPass.Font.Bold = true;
        FVUser.ForeColor = System.Drawing.Color.Red;
        FVUser.Font.Bold = true;
        
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
            string uName = UserName.Text;
            string oPass = OldPass.Text;
            string nPass1 = NewPass1.Text;
            string nPass2 = NewPass2.Text;
            bool val = selfserv.PassValidate(nPass1);
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/SelfService");
            System.Configuration.KeyValueConfigurationElement lpath = rootWebConfig.AppSettings.Settings["logpath"];
            string logpath = lpath.Value;
            if (nPass1 == oPass)
            {
                ErrorLable.Text = "New password cannot be the same as the old password.";
                ErrorLable.Visible = true;
            }

            else if (nPass1 != nPass2)
            {
                ErrorLable.Text = "New password does not match the confirm password.";
                ErrorLable.Visible = true;
            }
            else if (nPass1.Length > 16 | nPass1.Length < 8)
            {
                ErrorLable.Text = "The new password does not meet the length requirements.";
                ErrorLable.Visible = true;
            }
            else if (val != true)
            {
                ErrorLable.Text = "Password does not meet the strength requirements.";
                ErrorLable.Visible = true;
            }
            else
            {

                try
                {
                    selfserv.ChangePassword(uName, oPass, nPass1);
                    using (StreamWriter writeChange = new StreamWriter(logpath+"change.txt", true))
                    {
                        writeChange.WriteLine(uName + " changed password successfully at " + DateTime.Now.ToString());
                    }
                    Response.Redirect("success.aspx");
                }
                catch (Exception E) //(System.DirectoryServices.DirectoryServicesCOMException E)
                {
                    ErrorLable.Text = "Either your username and password is incorrect, or your new password does not meet the requirements. Please try again.";
                    ErrorLable.Visible = true;
                    using (StreamWriter writeError = new StreamWriter(logpath+"error.txt", true))
                    {
                        writeError.WriteLine(uName + " failed to change password with the Error: " + E.Message.ToString() + " at " + DateTime.Now.ToString());
                    }
                }

            }

    }

}