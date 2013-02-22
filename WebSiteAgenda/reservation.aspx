<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="reservation.aspx.cs" Inherits="WebSiteAgenda.reservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> Page de réservation </h1>

    <%
        String idEvent = Request.QueryString["idEvent"];
        String idLieu = Request.QueryString["idLieu"];
        if(idEvent != null || idLieu != null)
        {
            Response.Redirect("/error.aspx?message=Identifiants%20non%20précisés", false);
        }
    %>

</asp:Content>
