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
                Session["UserPass"] = pwd;
                firstConnect = true;
            }
            
        }
        
        if(Session["UserName"] == null)
        {
        
         %>
    <form method="post" action="connexion.aspx">
        <center>
            <table id="table-rech">
                <tr><td>Login </td><td><input style="text-align: center" name="login" type="text" onblur="verify(this.value,'text-login')"/></td><td id="text-login"></td></tr>
                <tr><td>Password</td><td ><input style="text-align: center" name="pwd" type="password" onblur="verify(this.value,'text-pwd')" /></td><td id="text-pwd"></td></tr>
                <tr><td></td><td style="text-align: center" ><input type="submit" value="     Connexion     " /></td></tr>
            </table>
        </center>
    </form>
    <% }
       else
       {
            if(firstConnect)
                Response.Write("<center><h2>Vous êtes maintenant connecté.<h2></center>");    
            else
                Response.Write("<center><h2>Vous êtes déjà connecté.<h2></center>");    
        } %>
</asp:Content>