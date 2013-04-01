<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recapitulatif.aspx.cs" Inherits="WebSiteAgenda.recapitulatif" %>

<center>
    <h2>Récapitulatif de votre commande :</h2>

    <%
    WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient service = new WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient();

    string identifiant = Session["UserLogin"].ToString();
    string mdp = Session["UserPass"].ToString();
    
    List<System.Guid> panier = (Session["panier"] as List<System.Guid>);
    
    foreach (System.Guid uid in panier)
    {
        WebSiteAgenda.WcfServiceAgenda.ReservationWS resa = service.GetReservation(identifiant, mdp, uid);

        Response.Write("Réservation n° ");
        Response.Write(uid.ToString());
        Response.Write("<br/>" + resa.NbPlaces);
        if (resa.NbPlaces == 1)
            Response.Write(" place réservé");
        else
            Response.Write(" places réservés");
        Response.Write("<br/>");
        Response.Write(resa.Planning.MonEvement.Titre);
        Response.Write("<br/>");
        Response.Write(resa.Planning.MonLieu.Nom);
        Response.Write("<br/>");
        Response.Write(resa.Planning.DateDebut.ToString("dddd, dd MMMM yyyy"));
        Response.Write("<br/><a href=\"annulerResa.aspx?uidResa=" + resa.Guid.ToString() + "\" ><img src=\"images/redCross.png\" alt=\"supprimer\" /></a><br/><br/>");
                            
    } %>
</center>
