<%@ Page Title="Recherche" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="recherche.aspx.cs" Inherits="WebSiteAgenda.recherche" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="Javascript/oXHR.js"></script>
    <script type="text/javascript" src="Javascript/jquery-1.9.1.min.js" ></script>
    <script type="text/javascript">
        <!-- 

    function request(callback,index) {
        var xhr = getXMLHttpRequest();
     
        xhr.onreadystatechange = function() {
            if (xhr.readyState == 4 && (xhr.status == 200 || xhr.status == 0)) {
                callback(xhr.responseText);
            }
        };
 
        var artiste = encodeURIComponent(document.getElementById("artiste").value);
        var event = encodeURIComponent($('select[name="idEvent"]').val());
        var lieux = encodeURIComponent($('select[name="idLieu"]').val());

        var query;
        switch (index) {
            case 0: query = "artiste=" + artiste;break;
            case 1 : query = "event=" + event; break;
        }

        xhr.open("GET", "gestionRecherche.aspx?"+ query, true);
        xhr.send(null);
        
    }

    function majEvent(sData) {
            $('#lieuSection').hide();
            $('select[name="idEvent"]').html(sData);
            $('#eventSection').show();
        }

    function majLieux(sData) {
        $('select[name="idLieu"]').html(sData);
        $('#lieuSection').show();
    }
        //-->
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="formEvent">
        <form method="get" action="reservation.aspx" >
            <table id="table-rech">
                <tr>
                    <td>
                        <label>Liste des artises:</label>
                    </td>
                    <td>
                        <select id="artiste" onchange="request(majEvent,0)">
                            <option value="null" ></option>
                    <%
            
                    WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient service = new WebSiteAgenda.WcfServiceAgenda.ServiceAgendaClient();
                    WebSiteAgenda.WcfServiceAgenda.ArtistWS[] artistes = service.GetAllArtistes(Session["UserLogin"].ToString(), Session["UserPass"].ToString());
                    foreach (WebSiteAgenda.WcfServiceAgenda.ArtistWS art in artistes)
                    {
                        Response.Write("<option value="+art.Giud+">"+ art.Nom +"</option>");
                    }    
                    %>
                </select>
                    </td>
                </tr>
                <tr id="eventSection" style="display:none">
                    <td>
                        <label>Liste des evènements:</label>
                    </td>
                    <td>
                        <select name="idEvent" onchange="request(majLieux,1)">
                        </select>
                    </td>
                </tr>
                <tr id="lieuSection" style="display:none">
                    <td>
                        <label>Liste des lieux:</label>
                    </td>
                    <td>
                        <select name="idLieu">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <input type="submit" value="Réserver" />
                    </td>
                </tr>
            </table>
        </form>
    </p>
</asp:Content>
