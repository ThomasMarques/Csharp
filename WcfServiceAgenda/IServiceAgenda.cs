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
        IList<LieuWS> GetAllLieux(String login, String passwd);

        [OperationContract]
        IList<PlanningElementWS> GetAllPlanningElements(String login, String passwd);

        [OperationContract]
        IList<UtilisateurWS> GetAllUsers(String login, String passwd);

        [OperationContract]
        Boolean CreateUser(String yourLogin, String yourPass, String login, String passwd, String nom, String prenom);

        [OperationContract]
        IList<Business.PlanningElementWS> GetPlanningElementByLieu(String login, String passwd, String guidLieu);

        [OperationContract]
        IList<Business.PlanningElementWS> GetPlanningElementByEvent(string login, string passwd, String guidEv);

        [OperationContract]
        int GetNbPlacesAvailable(String login, String passwd, EntitiesLayer.PlanningElement pe);

        [OperationContract]
        Boolean AnnulationReservation(System.Guid guidResa);
        
        [OperationContract]
        ReservationWS GetReservation(System.Guid guidResa);
        
        [OperationContract]
        bool ReserverPlaces(EntitiesLayer.PlanningElement planning, int nbPlaces);
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
