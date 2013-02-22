<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="WebSiteAgenda.error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="error" >
        <img src="fatality.jpg" alt="Error" />
        <% 
            if (Request.QueryString["message"] != null)
                Response.Write("<h2>" + Request.QueryString["message"] + "</h2>");
        %>
    </div>
</asp:Content>
