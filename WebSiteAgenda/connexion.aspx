<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="WebSiteAgenda.error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        if (Request["login"] != null && Request["pwd"] != null)
        {
            WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient service = new WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient();
            string login=WebSiteAgenda.Sanitizer.Sanitize(Request["login"]);
            string pwd = WebSiteAgenda.Sanitizer.CalculateSHA1(WebSiteAgenda.Sanitizer.Sanitize(Request["pwd"]));
            WebSiteAgenda.WcfServiceAgenda.UtilisateurWS[] users = service.GetAllUsers(login, pwd);
            if (users != null && users.Count() == 1)
            {
                Session["UserLogin"] = login;
                Session["UserName"] = users.Single().Nom;
                Session["UserSurname"] = users.Single().Prenom;
            }
            Response.Write(Session["UserName"]);

        }
        
        if(Session["UserName"] == null)
        {
        
         %>
    <form method="post" action="connexion.aspx">
        <table>
            <tr><td>Login: </td><td><input name="login" type="text" /></td></tr>
            <tr><td>Password:</td><td><input name="pwd" type="password" /></td></tr>
            <tr><td colspan="2"><input type="submit" value="Connexion" /></td></tr>
        </table>
    </form>
    <% } %>
</asp:Content>