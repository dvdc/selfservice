<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="change.aspx.cs" Inherits="_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h3>Change your password:</h3>
        <table  style="text-align: right">
            <tr>
                <th>Username:</th>
                <th><asp:TextBox ID="UserName" runat="server" TextMode="SingleLine"></asp:TextBox></th>
                <th style="text-align: left"><asp:RequiredFieldValidator ID="FVUser" runat="server" ControlToValidate="UserName" ErrorMessage="Username cannot be blank."></asp:RequiredFieldValidator></th>
            </tr>
            <tr>
                <th>Current Password:</th>
                <th><asp:TextBox ID="OldPass" runat="server" TextMode="Password"></asp:TextBox></th>
                <th style="text-align: left"><asp:RequiredFieldValidator ID="FVOldPass" runat="server" ControlToValidate="OldPass" ErrorMessage="Current password cannot be blank."></asp:RequiredFieldValidator></th>
            </tr>
            <tr>
                <th>New Password:</th>
                <th><asp:TextBox ID="NewPass1" runat="server" TextMode="Password"></asp:TextBox></th>
                <th style="text-align: left"><asp:RequiredFieldValidator ID="FVNewPass1" runat="server" ControlToValidate="NewPass1" ErrorMessage="New password cannot be blank."></asp:RequiredFieldValidator></th>
            </tr>
            <tr>
                <th>Confirm New Password:</th>
                <th><asp:TextBox ID="NewPass2" runat="server" TextMode="Password"></asp:TextBox></th>
                <th style="text-align: left"><asp:RequiredFieldValidator ID="FVNewPass2" runat="server" ControlToValidate="NewPass2" ErrorMessage="New password confirmation cannot be blank."></asp:RequiredFieldValidator></th>
            </tr>
            <tr>
                <th></th>
                <th><asp:Button ID="Submit" Text="Submit" runat="server" OnClick="Submit_Click" /></th>
                <%--<th style="text-align: left"><asp:RegularExpressionValidator ID="RegExPass" runat="server" ForeColor="Red" ControlToValidate="NewPass1" ValidationExpression="^(?=(.*\d){1})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{8,}$" ErrorMessage="Password does not meet the strenght requirements."></asp:RegularExpressionValidator></th>--%>
            </tr>
        </table>
        <asp:Label ID="ErrorLable" runat="server" Visible="false"></asp:Label>

        <br />
        <p>The password policy in place requires passwords to be changed every 180 days and also requires certain strength and complexity requirements. These requirements are:
        </p>
        <ul>
            <li>Password Length: 8-16 characters</li>
            <li>Password History: Cannot be the same as any of the past 5 passwords.</li>
            <li>Password Strength (Must contain three of four):
                <ul>
                    <li>Lowercase letters</li>
                    <li>Uppercase letters</li>
                    <li>Numbers</li>
                    <li>Special characters ! @ # $ % ^ & * - _ + = [ ] { } | \ : ‘ , . ? / ` ~ “ < > ( ) ;</li>
                </ul>
            </li>
        </ul>
        <p><b>Locked out?</b> If so, your account will automatically unlock after 30 minutes.</p>
    </div>
</asp:Content>