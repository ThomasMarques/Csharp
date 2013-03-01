using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfServiceAgenda.Business
{
    public class ReservationWS
    {
        /// <summary>
        /// PlanningElement concernées par la réservation.
        /// </summary>
        private PlanningElementWS _planning;
        [DataMember]
        public PlanningElementWS Planning
        {
            get { return _planning; }
            set { _planning = value; }
        }

        /// <summary>
        /// Nombres de places réservées.
        /// </summary>
        private int _nbPlaces;
        [DataMember]
        public int NbPlaces
        {
            get { return _nbPlaces; }
            set { _nbPlaces = value; }
        }

        /// <summary>
        /// Id de la réservation.
        /// </summary>
        private System.Guid _guid;
        [DataMember]
        public System.Guid Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        /// <summary>
        /// Constructeur principal de la classe.
        /// </summary>
        /// <param name="pe"><see cref="_planning"/></param>
        /// <param name="nbPlaces"><see cref="_nbPlaces"/></param>
        /// <param name="guid"><see cref="_guid"/></param>
        public ReservationWS(PlanningElementWS pe, int nbPlaces, System.Guid guid)
        {
            _planning = pe;
            _nbPlaces = nbPlaces;
            _guid = guid;
        }

        /// <summary>
        /// Constructeur vide de la classe.
        /// </summary>
        public ReservationWS()
        {
        }

        public static EntitiesLayer.Reservation Convert(ReservationWS res)
        {
            return new EntitiesLayer.Reservation(
                PlanningElementWS.Convert(res.Planning),
                res.NbPlaces,
                res.Guid);
        }


        public static ReservationWS Convert(EntitiesLayer.Reservation res)
        {
            return new ReservationWS(
                PlanningElementWS.Convert(res.Planning),
                res.NbPlaces,
                res.Guid);
        }
    }
}