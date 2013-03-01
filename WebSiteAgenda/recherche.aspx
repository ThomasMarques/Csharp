<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="recherche.aspx.cs" Inherits="WebSiteAgenda.recherche" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="formEvent">
        Liste des artises:
        <select id="artiste">
            <%
            
            WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient service = new WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient();
            WebSiteAgenda.WcfServiceAgenda.ArtistWS selectedArt=service.GetAllArtistes("toto", "12299170891009567410982971131211871132061153230").First();
            foreach (WebSiteAgenda.WcfServiceAgenda.ArtistWS art in service.GetAllArtistes("toto", "12299170891009567410982971131211871132061153230"))
            {
                Response.Write("<option>"+ art.Nom +"<option/>");
            }    
            %>
        </select>
        Liste des evènement:
        <select id="event">
            <%
               /* WebSiteAgenda.WcfServiceAgenda.EvenementWS[] events = service.GetAllEvents("toto", "12299170891009567410982971131211871132061153230")
                    .Where(e => e.Artistes.Select(m => m.Giud).Contains(selectedArt.Giud)).ToArray();*/
                foreach (WebSiteAgenda.WcfServiceAgenda.EvenementWS e in service.GetAllEvents("toto", "12299170891009567410982971131211871132061153230"))
                {
                    Response.Write("<option>" + e.Titre + "</option>");
                }              
            %>
        </select>
        
    </p>
</asp:Content>
