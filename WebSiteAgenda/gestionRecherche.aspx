<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestionRecherche.aspx.cs" Inherits="WebSiteAgenda.gestionRecherche" %>

<%
    WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient service = new WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient();
    
    if (Request.QueryString.AllKeys.Contains("artiste"))
    {
        WebSiteAgenda.WcfServiceAgenda.EvenementWS[] events = service.GetAllEventsByArtiste("toto", "12299170891009567410982971131211871132061153230",System.Guid.Parse(Request.QueryString["artiste"]));
        foreach (WebSiteAgenda.WcfServiceAgenda.EvenementWS e in events)
        {
            Response.Write("<option value=" + e.Guid + ">" + e.Titre + "</option>");
        }
    }

    if(Request.QueryString.AllKeys.Contains("event"))
    {
        WebSiteAgenda.WcfServiceAgenda.PlanningElementWS[] planning = service.GetAllPlanningElementsByEvent("toto", "12299170891009567410982971131211871132061153230", System.Guid.Parse(Request.QueryString["event"])).Distinct().ToArray();
        foreach (WebSiteAgenda.WcfServiceAgenda.PlanningElementWS pe in planning)
        {
            Response.Write("<option value=" + pe.Guid + ">" + pe.MonLieu.Nom + "</option>");
        }
    }
    
%>
