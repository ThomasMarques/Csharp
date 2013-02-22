<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="WebSiteAgenda.error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="imgError">
        <img src="images/wtf.png" alt="image erreur" />
    </div>
    <h2>
    <%
        if (Request.QueryString["message"] != null)
            Response.Write(Request.QueryString["message"]);
    %>
    </h2>
</asp:Content>
