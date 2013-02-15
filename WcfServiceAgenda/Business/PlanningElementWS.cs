using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using EntitiesLayer;

namespace WcfServiceAgenda.Business
{
    [DataContract]
    public class PlanningElementWS
    {
        /// <summary>
        /// Date de début de l'element.
        /// </summary>
        private DateTime _dateDebut;
        [DataMember]
        public DateTime DateDebut
        {
            get { return _dateDebut; }
            set { _dateDebut = value; }
        }

        /// <summary>
        /// Date de fin de l'element.
        /// </summary>
        private DateTime? _dateFin;
        [DataMember]
        public DateTime? DateFin
        {
            get { return _dateFin; }
            set { _dateFin = value; }
        }

        /// <summary>
        /// Evenement de l'element.
        /// </summary>
        private EvenementWS _monEvement;
        [DataMember]
        public EvenementWS MonEvement
        {
            get { return _monEvement; }
            set { _monEvement = value; }
        }

        /// <summary>
        /// Guid de l'element.
        /// </summary>
        private System.Guid _guid;
        [DataMember]
        public System.Guid Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        /// <summary>
        /// Lieu de l'evenemet.
        /// </summary>
        private LieuWS _monLieu;
        [DataMember]
        public LieuWS MonLieu
        {
            get { return _monLieu; }
            set { _monLieu = value; }
        }

        /// <summary>
        /// Nombre de places réservées.
        /// </summary>
        private int _nbPlacesReservees;
        [DataMember]
        public int NbPlacesReservees
        {
            get { return _nbPlacesReservees; }
            set { _nbPlacesReservees = value; }
        }

        /// <summary>
        /// Construit un element du planning.
        /// </summary>
        /// <param name="dateDebut">Date de début de l'evenement.</param>
        /// <param name="dateFin">Date de fin de l'evenement</param>
        /// <param name="guid">Guid de l'evenement</param>
        /// <param name="evenement">Evenment</param>
        /// <param name="lieu">Lieu de l'evenement</param>
        /// <param name="nbPlacesRes">Nombre de places réservées.</param>
        public PlanningElementWS(DateTime dateDebut, DateTime? dateFin, System.Guid guid, EvenementWS evenement, LieuWS lieu, int nbPlacesRes)
        {
            _dateDebut = dateDebut;
            _dateFin = dateFin;
            _guid = guid;
            _monEvement = evenement;
            _monLieu = lieu;
            _nbPlacesReservees = nbPlacesRes;
        }


        public static PlanningElement Convert(PlanningElementWS pe)
        {
            return new PlanningElement(pe.DateDebut, pe.DateFin, pe.Guid,
                EvenementWS.Convert(pe.MonEvement),
                LieuWS.Convert(pe.MonLieu),
                pe.NbPlacesReservees);
        }


        public static PlanningElementWS Convert(PlanningElement pe)
        {
            return new PlanningElementWS(pe.DateDebut, pe.DateFin, pe.Guid,
                EvenementWS.Convert(pe.MonEvement),
                LieuWS.Convert(pe.MonLieu),
                pe.NbPlacesReservees);
        }
    }
}