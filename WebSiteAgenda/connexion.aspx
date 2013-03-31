<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="WebSiteAgenda.error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="Javascript/jquery-1.9.1.min.js" ></script>
    <script type="text/javascript">
        <!-- 

        function verify(val,idStr) {
            if (val == null || val == "")
                $("#" + idStr).html("<img src='images/redCross.png' width='20' height='20' alt='Ce champ ne peut être vide' />");
            else
                $("#" + idStr).html("");
        }
    //-->
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        bool firstConnect = false;
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
                firstConnect = true;
            }
            
        }
        
        if(Session["UserName"] == null)
        {
        
         %>
    <form method="post" action="connexion.aspx">
        <table>
            <tr><td>Login: </td><td><input name="login" type="text" onblur="verify(this.value,'text-login')"/></td><td id="text-login"></td></tr>
            <tr><td>Password:</td><td><input name="pwd" type="password" onblur="verify(this.value,'text-pwd')" /></td><td id="text-pwd"></td></tr>
            <tr><td colspan="3"><input type="submit" value="Connexion" /></td></tr>
        </table>
    </form>
    <% }
       else
       {
            if(firstConnect)
                Response.Write("Vous êtes maintenant connecté.");    
            else   
                Response.Write("Vous êtes déjà connecté.");    
        } %>
</asp:Content>