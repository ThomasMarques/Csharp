<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestionReservation.aspx.cs" Inherits="WebSiteAgenda.gestionReservation" %>

<%
    WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient service = new WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient();
    
    if (!Request.QueryString["planning"].Equals("null"))
    {
        Response.Write(service.GetNbPlacesAvailable(Session["UserLogin"].ToString(), Session["UserPass"].ToString(), System.Guid.Parse(Request.QueryString["planning"])));
    }
%> 