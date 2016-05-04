<%@ Page Language="C#" AutoEventWireup="true" CodeFile="unhuman.aspx.cs" Inherits="unhuman" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Self Service Portal</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
        <img src="img/logo.png" />
        <h1 class="header">Self Service Portal</h1>
    </div>
    <h3>Unearthly Password Changes:</h3>
    <p>For all intergalactic requests, please click <a href="mailto:takemetoyourleader@company.com">here.</a></p>
    <img src="img/scared.jpg" />
    <p class="space"><asp:Button ID="backBtn" runat="server" Text="Take me back to Earth!" OnClick="backBtn_Click" /></p>
  </div>
    </form>
</body>
</html>

