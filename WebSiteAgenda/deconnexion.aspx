<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="deconnexion.aspx.cs" Inherits="WebSiteAgenda.error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Session["UserLogin"] = null;
        Session["UserName"] = null;
        Session["UserSurname"] = null;
        Response.Redirect("~/connexion.aspx");
         %>

</asp:Content>