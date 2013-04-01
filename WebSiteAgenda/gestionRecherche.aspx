<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestionRecherche.aspx.cs" Inherits="WebSiteAgenda.gestionRecherche" %>

<%
    WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient service = new WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient();
    
    if (Request.QueryString.AllKeys.Contains("artiste"))
    {
        Response.Write("<option value=\"null\"></option>");
        if (!Request.QueryString["artiste"].Equals("null"))
        {
            WebSiteAgenda.WcfServiceAgenda.EvenementWS[] events = service.GetAllEventsByArtiste(Session["UserLogin"].ToString(), Session["UserPass"].ToString(), System.Guid.Parse(Request.QueryString["artiste"]));
            foreach (WebSiteAgenda.WcfServiceAgenda.EvenementWS e in events)
            {
                Response.Write("<option value=" + e.Guid + ">" + e.Titre + "</option>");
            }
        }
    }

    if(Request.QueryString.AllKeys.Contains("event"))
    {
        Response.Write("<option value=\"null\"></option>");
        if (!Request.QueryString["event"].Equals("null"))
        {
            WebSiteAgenda.WcfServiceAgenda.PlanningElementWS[] planning = service.GetAllPlanningElementsByEvent(Session["UserLogin"].ToString(), Session["UserPass"].ToString(), System.Guid.Parse(Request.QueryString["event"])).Distinct().ToArray();
            foreach (WebSiteAgenda.WcfServiceAgenda.LieuWS lieu in ((from p in planning select p.MonLieu).ToList().Distinct()))
            {
                Response.Write("<option value=" + lieu.Guid + ">" + lieu.Nom + "</option>");
            }
        }
    }
    
%>
