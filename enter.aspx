<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="enter.aspx.cs" Inherits="enter" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>Are you human?</h3>
    <p>For security purpsoses, you must first complete the CAPTCHA.</p>
    <recaptcha:RecaptchaControl
             ID="recaptcha"
             runat="server"
    />
    <asp:Button runat="server" ID="captchaBtn" Text="Submit" OnClick="captchaBtn_Click" /> <br />
    <asp:Label runat="server" ID="captchaLbl" Text="Incorrect CAPTCHA. Please try again." Visible="false" ForeColor="red" Font-Bold="true"></asp:Label>
</asp:Content> 

