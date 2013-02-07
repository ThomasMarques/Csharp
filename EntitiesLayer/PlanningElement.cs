using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class PlanningElement : IEquatable<PlanningElement>
    {
        /// <summary>
        /// Date de début de l'element.
        /// </summary>
        private DateTime _dateDebut;

        public DateTime DateDebut
        {
            get { return _dateDebut; }
            set { _dateDebut = value; }
        }

        /// <summary>
        /// Date de fin de l'element.
        /// </summary>
        private DateTime? _dateFin;

        public DateTime? DateFin
        {
            get { return _dateFin; }
            set { _dateFin = value; }
        }

        /// <summary>
        /// Guid de l'element.
        /// </summary>
        private System.Guid _guid;

        public System.Guid Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        /// <summary>
        /// Evenement de l'element.
        /// </summary>
        private Evenement _monEvement;

        public Evenement MonEvement
        {
            get { return _monEvement; }
            set { _monEvement = value; }
        }

        /// <summary>
        /// Lieu de l'evenemet.
        /// </summary>
        private Lieu _monLieu;

        public Lieu MonLieu
        {
            get { return _monLieu; }
            set { _monLieu = value; }
        }

        /// <summary>
        /// Nombre de places réservées.
        /// </summary>
        private int _nbPlacesReservees;

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
        public PlanningElement(DateTime dateDebut, DateTime? dateFin, System.Guid guid, Evenement evenement, Lieu lieu, int nbPlacesRes)
        {
            _dateDebut = dateDebut;
            _dateFin = dateFin;
            _guid = guid;
            _monEvement = evenement;
            _monLieu = lieu;
            _nbPlacesReservees = nbPlacesRes;
        }

        /// <summary>
        /// Constructeur sans argument de la classe Planning element.
        /// </summary>
        public PlanningElement()
        {
            _guid = System.Guid.NewGuid();
            _dateDebut = new DateTime(2999, 01, 01);
            _dateFin = null;
            _monEvement = new Exposition();
            _monLieu = new Lieu();
            _nbPlacesReservees = 0;
        }

        /// <summary>
        /// Compare deux planningElement selon la date de début.
        /// </summary>
        /// <param name="pe1">1er planningElement</param>
        /// <param name="pe2">2eme planningElement</param>
        /// <returns>L'entier de comparaison des deux dates.</returns>
        public static int CompareDate(PlanningElement pe1, PlanningElement pe2)
        {
            return pe1.DateDebut.CompareTo(pe2.DateDebut);
        }

        public bool Equals(PlanningElement obj)
        {
            bool ret = false;
            if (obj != null)
            {
                ret = this._dateDebut.Equals(obj._dateDebut)
                    && this._monEvement.Equals(obj.MonEvement)
                    && this.MonLieu.Equals(obj.MonLieu);
            }

            return ret;
        }

        public bool Equals(Object obj)
        {
            bool ret = false;
            if (obj != null)
            {
                if(obj.GetType() == this.GetType())
                    ret = Equals((PlanningElement) obj);
            }

            return ret;
        }
    }

}
