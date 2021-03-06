﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfServiceAgenda.Business;
using BusinessLayer;

namespace WcfServiceAgenda
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceAgenda
    {
        // TODO: ajoutez vos opérations de service ici
        [OperationContract]
        IList<ArtistWS> GetAllArtistes(String login, String passwd);

        [OperationContract]
        IList<EvenementWS> GetAllEvents(String login, String passwd);

        [OperationContract]
        IList<EvenementWS> GetAllEventsByArtiste(String login, String passwd, System.Guid guidArtiste);

        [OperationContract]
        IList<LieuWS> GetAllLieux(String login, String passwd);

        [OperationContract]
        IList<PlanningElementWS> GetAllPlanningElements(String login, String passwd);

        [OperationContract]
        IList<PlanningElementWS> GetAllPlanningElementsByEvent(String login, String passwd, System.Guid guidEvent);

        [OperationContract]
        IList<UtilisateurWS> GetAllUsers(String login, String passwd);

        [OperationContract]
        Boolean CreateUser(String yourLogin, String yourPass, String login, String passwd, String nom, String prenom);

        [OperationContract]
        IList<Business.PlanningElementWS> GetAllPlanningElementByLieu(String login, String passwd, System.Guid guidLieu);

        [OperationContract]
        IList<Business.PlanningElementWS> GetAllPlanningElementByLieuAndEvent(String login, String passwd, System.Guid guidLieu, System.Guid guidEv);

        [OperationContract]
        int GetNbPlacesAvailable(String login, String passwd, System.Guid pe);

        [OperationContract]
        Boolean AnnulationReservation(String login, String passwd, System.Guid guidResa);
        
        [OperationContract]
        ReservationWS GetReservation(String login, String passwd, System.Guid guidResa);
        
        [OperationContract]
        ReservationWS ReserverPlaces(String login, String passwd, System.Guid planning, int nbPlaces);
    }
}
