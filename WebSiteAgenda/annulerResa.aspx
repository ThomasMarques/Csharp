<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="annulerResa.aspx.cs" Inherits="WebSiteAgenda.annulerResa" %>

<%
    String uidResa = Request.QueryString["uidResa"];
    if (uidResa != null)
    {
        Guid uid = new Guid(uidResa);
        WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient service = new WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient();
        
        string identifiant = Session["UserLogin"].ToString();
        string mdp = Session["UserPass"].ToString();

        service.AnnulationReservation(identifiant, mdp, uid);
        
        List<Guid> panier = (Session["panier"] as List<Guid>);

        for (int i = 0; i < panier.Count; ++i)
        {
            if (panier.ElementAt(i).Equals(uid))
                panier.RemoveAt(i);
        }
    }

    Response.Redirect("validation.aspx");
%>
