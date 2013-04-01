<%@ Page Title="Validation" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="validation.aspx.cs" Inherits="WebSiteAgenda.validation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%
    String idPlanning = Request.QueryString["selectDate"];
    String nbPlaces = Request.QueryString["nbPlaces"];
    string identifiant = Session["UserLogin"].ToString();
    string mdp = Session["UserPass"].ToString();
    if (idPlanning != null && nbPlaces != null)
    {

        Guid uidPlanning = new Guid(idPlanning);
        int nb = 0;
        int.TryParse(nbPlaces, out nb);
        
        if(nb > 0)
        {
            WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient service = new WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient();

            WebSiteAgenda.WcfServiceAgenda.ReservationWS resa = service.ReserverPlaces(identifiant, mdp, uidPlanning, nb);
            if (Session["panier"] == null)
            {
                Session["panier"] = new List<System.Guid>();
            }

            (Session["panier"] as List<System.Guid>).Add(resa.Guid);
            Response.Redirect("validation.aspx");
        }
    }
            
    if (Session["panier"] == null)
    {
        Response.Write("<h2>Votre panier est vide.</h2>");
    }
    else
    {
        List<System.Guid> panier = (Session["panier"] as List<System.Guid>);
        if(panier.Count == 0)
            Response.Write("<h2>Votre panier est vide.</h2>");
        else
        {
            Response.Write("<h2>Contenu de votre panier.</h2><br/>");
            WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient service = new WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient();
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
                Response.Write("<br/><br/>");
                            
            }
            
            %>
            <a href="recapitulatif.aspx"><input type="button" value="Valider" /></a>
            <%
                    
        }
    }            
    %>

</asp:Content>


