<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Self Service Portal</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="captchaBtn">
    <div>
    <div>
        <img src="img/logo.png" />
        <h1 class="header">Self Service Portal</h1>
    </div>
    <h3>Are you human? <asp:Button runat="server" ID="humanBtn" Text="No" OnClick="humanBtn_Click" /></h3>
    <p>For security purpsoses, you must first complete the CAPTCHA before you can change your password.</p>
    <recaptcha:RecaptchaControl
             ID="recaptcha"
             runat="server"
    />
    <asp:Button runat="server" ID="captchaBtn" Text="Continue" OnClick="captchaBtn_Click" />
    <asp:Label runat="server" ID="captchaLbl" Text="Incorrect CAPTCHA. Please try again." Visible="false" ForeColor="red" Font-Bold="true"></asp:Label>
    </div>
    </form>
</body>
</html>
