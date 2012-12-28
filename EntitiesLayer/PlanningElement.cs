using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class PlanningElement
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
        private DateTime _dateFin;

        public DateTime DateFin
        {
            get { return _dateFin; }
            set { _dateFin = value; }
        }

        /// <summary>
        /// Guid de l'element.
        /// </summary>
        private int _guid;

        public int Guid
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
        public PlanningElement(DateTime dateDebut, DateTime dateFin, int guid, Evenement evenement, Lieu lieu, int nbPlacesRes)
        {
            _dateDebut = dateDebut;
            _dateFin = dateFin;
            _guid = guid;
            _monEvement = evenement;
            _monLieu = lieu;
            _nbPlacesReservees = nbPlacesRes;
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
    }

}
