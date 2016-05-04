<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="expiration.aspx.cs" Inherits="expiration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <h3>Check Your Password Expiration:</h3>
        <table style="text-align: right">
            <tr>
                <th>Username:</th>
                <th><asp:TextBox ID="UserName" runat="server" TextMode="SingleLine"></asp:TextBox></th>
                <th style="text-align: left"><asp:RequiredFieldValidator ID="FVUser" runat="server" ControlToValidate="UserName" ErrorMessage="Username cannot be blank." ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator></th>
            </tr>
            <tr>
                <th>Current Password: </th>
                <th><asp:TextBox ID="OldPass" runat="server" TextMode="Password"></asp:TextBox></th>
                <th style="text-align: left"><asp:RequiredFieldValidator ID="FVOldPass" runat="server" ControlToValidate="OldPass" ErrorMessage="Password cannot be blank." ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator></th>
            </tr>
            <tr>
                <th></th>
                <th><asp:Button ID="Submit" Text="Submit" runat="server" OnClick="Submit_Click" /></th>
            </tr>
        </table>
        <asp:Label ID="verifyLable" runat="server" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
</asp:Content>

