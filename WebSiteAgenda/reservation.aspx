<%@ Page Title="Réservation" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="reservation.aspx.cs" Inherits="WebSiteAgenda.reservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        String idEvent = Request.QueryString["idEvent"];
        String idLieu = Request.QueryString["idLieu"];
        if(idEvent == null || idLieu == null)
        {
            Response.Redirect("error.aspx?message=Identifiants%20lieu%20et%20event%20non%20précisés", false);
        }
        else
        {
        
        
            string identifiant = "toto";
            string mdp = "12299170891009567410982971131211871132061153230";

            WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient service = new WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient();

            Guid uidL = new Guid(idLieu);
            Guid uidEv = new Guid(idEvent);

            IList<WebSiteAgenda.WcfServiceAgenda.PlanningElementWS> plannings = service.GetAllPlanningElementByLieuAndEvent(identifiant, mdp, uidL, uidEv);

            if(plannings.Count > 0)
            {
    %>
    
    <script type="text/javascript">
        function incPlace()
        {
            var place = document.getElementById("nbPlaces");
            var placeDispos = document.getElementById("nbPlacesDispos");

            if (parseInt(place.value) < parseInt(placeDispos.innerHTML))
            {
                place.value = "" + (parseInt(place.value) + 1);
            }
        }

        function decPlace()
        {
            var place = document.getElementById("nbPlaces");

            if (parseInt(place.value) > 1) {
                place.value = "" + (parseInt(place.value) - 1);
            }
        }

        function verif()
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
    <div id="reservation">

        <div id="ResumeArtist">
            <% 
                Response.Write("<h3>Listes des Artistes présents :</h3>\n");
                Response.Write("<ul id=\"listArtists\">\n");
        
                StringBuilder sb = new StringBuilder();
            
                
                foreach(WebSiteAgenda.WcfServiceAgenda.ArtistWS artiste in plannings.First().MonEvement.Artistes)
                {
                    sb.Append(artiste.Prenom).Append(" ").Append(artiste.Nom);
                    
                    Response.Write("<li>"+ sb.ToString() +"</li>\n");
                    sb.Clear();
                }
                Response.Write("</ul>");
            %>

        </div>
    
        <div id="ResumeEvent" >
            <h3><% Response.Write(plannings.First().MonEvement.Titre); %></h3>

            Description : <br />
            <% 
                String desc = plannings.First().MonEvement.Description;
                if (desc == null || desc.Trim().Length == 0)
                {
                    desc = "Aucune description disponible";
                }
                Response.Write(desc);
            %>
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
            <select name="selectDate" id="selectDate" onchange="" >
                <option value="null" > </option>

                <%
                foreach (WebSiteAgenda.WcfServiceAgenda.PlanningElementWS p in plannings)
                {
                    Response.Write("<option>" + p.DateDebut.ToString("dddd, dd MMMM yyyy") + "</option>");
                }    
                %>

            </select>
            <br />
            <br />
            <form action="validation.aspx" method="get" id="formValidation" >

                Il ne reste plus que <span id="nbPlacesDispos">10</span> disponibles. 

                Nombre de places à reserver : <br />
                <table>
                    <tr>
                        <td>
                            <input type="text" name="nbPlaces" id="nbPlaces" size="2" value="1" onchange="verif()" />
                        </td>
                        <td>
                            <a href="#inc" onclick="incPlace()" ><img src="images/plus.png" alt="+" /></a><br />
                            <a href="#dec" onclick="decPlace()" ><img src="images/moins.png" alt="-" /></a>
                        </td>
                    </tr>
                </table>
                <br />

                <input type="submit" value="Réserver" />

            </form>


        </div>
    </div>


    <%      }
            else
            {
                %>
                <h3>Aucune date disponible pour cette évènement et ce lieu</h3>
                <form method="get" action="recherche.aspx" >
                    <input type="submit" value="&larr; Retour à la recherche" />
                </form>
                <%
            }
        
        } %>
</asp:Content>
