<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="WebSiteAgenda.error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form method="post" action="connexion.aspx">
        <table>
            <tr><td>Login: </td><td><input name="login" type="text" /></td></tr>
            <tr><td>Password:</td><td><input name="pwd" type="password" /></td></tr>
            <tr><td colspan="2"><button type="submit" value="Log in" /></td></tr>
        </table>
    </form>
</asp:Content>