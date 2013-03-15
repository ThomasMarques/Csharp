<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="reservation.aspx.cs" Inherits="WebSiteAgenda.reservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        String idEvent = Request.QueryString["idEvent"];
        String idLieu = Request.QueryString["idLieu"];
        if(idEvent == null || idLieu == null)
        {
            Response.Redirect("error.aspx?message=Identifiants%20non%20précisés", false);
        }
        
        string identifiant = "toto";
        string mdp = "12299170891009567410982971131211871132061153230";

        WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient service = new WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient();
        IList<WebSiteAgenda.WcfServiceAgenda.PlanningElementWS> planningLieu = service.GetPlanningElementByLieu(identifiant, mdp, idLieu);
        IList<WebSiteAgenda.WcfServiceAgenda.PlanningElementWS> plannings;
            
        plannings = planningLieu.Intersect(service.GetPlanningElementByEvent(identifiant, mdp, idEvent)).ToList();

    %>

    <script type="text/javascript">
        incPlace()
        {
            var place = document.getElementById("nbPlaces");
            var placeDispos = document.getElementById("nbPlacesDispos");

            if (parseInt(place.value) < parseInt(placeDispos.innerHTML))
            {
                place.value = "" + (parseInt(place.value) + 1);
            }
        }

        decPlace()
        {
            var place = document.getElementById("nbPlaces");

            if (parseInt(place.value) > 1) {
                place.value = "" + (parseInt(place.value) - 1);
            }
        }

        verif()
        {
            var place = document.getElementById("nbPlaces");
            var placeDispos = document.getElementById("nbPlacesDispos");

            if (parseInt(place.value) < 1) {
                place.value = "0";
            }

            if (parseInt(place.value) < parseInt(placeDispos.innerHTML)) {
                place.value = parseInt(placeDispos.innerHTML);
            }
        }

    </script>

    <div id="ResumeArtist">
        <h3>Listes des Artistes présents :</h3>

        <ul id="listArtists">
        <% 
            StringBuilder sb = new StringBuilder();
            
                
            foreach(WebSiteAgenda.WcfServiceAgenda.ArtistWS artiste in plannings.First().MonEvement.Artistes)
            {
                sb.Append(artiste.Prenom).Append(" ").Append(artiste.Nom);
                    
                Response.Write("<li>"+ sb.ToString() +"</li>\n");
                sb.Clear();
            }
        %>
        </ul>

        StringBuilder sb = new StringBuilder();
        sb.Append(_prenom).Append(" ").Append(_nom);
        if(_dateDeNaissance != null)
            sb.Append(" née le  ").Append(((DateTime)_dateDeNaissance).ToString("dd / MM / yyyy"));

    </div>
    
    <div id="ResumeEvent" >
        <h3><% Response.Write(plannings.First().MonEvement.Titre); %></h3>

        Description : <br />
        <% Response.Write(plannings.First().MonEvement.Description); %>
    </div>   
    
    <div id="ResumeLieu" >
        <h3><% Response.Write(plannings.First().MonLieu.Nom); %></h3>

        Adresse :  <br />
        <% Response.Write(plannings.First().MonLieu.Adresse); %> <br />
        <br />
        Nombre de places totales : <% Response.Write(plannings.First().MonLieu.NombrePlacesTotal); %>
    </div>   
    
    <div id="choixDate" >
        <h3>Quand voulez vous assistez au spectable ?</h3>

        Veuillez selectionner un date :  <br />
        <select name="selectDate" onchange="" >
            <option value="null" > </option>

            <%
            foreach (WebSiteAgenda.WcfServiceAgenda.PlanningElementWS p in plannings)
            {
                Response.Write("<option>" + p.DateDebut.ToString("dddd, dd MMMM yyyy") + "<option/>");
            }    
            %>

        </select>
        <br />
        <br />
        <form action="validation.aspx" autocomplete="on" >

            Il ne reste plus que <span id="nbPlacesDispos">10</span> disponibles. 

            Nombre de places à reserver : <br />
            <input type="text" id="nbPlaces" size="2" value="1" onchange="verif()" />
            <button value="+" onclick="incPlace()" />
            <button value="-" onclick="decPlace()" />
            <br />

            <input type="submit" value="Réserver" />

        </form>


    </div>
    
     
    <%   
        
        
    %>
</asp:Content>
