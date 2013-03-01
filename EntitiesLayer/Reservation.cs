using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class Reservation
    {
        /// <summary>
        /// PlanningElement concernées par la réservation.
        /// </summary>
        private PlanningElement _planning;

        public PlanningElement Planning
        {
            get { return _planning; }
            set { _planning = value; }
        }

        /// <summary>
        /// Nombres de places réservées.
        /// </summary>
        private int _nbPlaces;

        public int NbPlaces
        {
            get { return _nbPlaces; }
            set { _nbPlaces = value; }
        }

        /// <summary>
        /// Id de la réservation.
        /// </summary>
        private System.Guid _guid;

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
        public Reservation(PlanningElement pe, int nbPlaces, System.Guid guid)
        {
            _planning = pe;
            _nbPlaces = nbPlaces;
            _guid = guid;
        }

        /// <summary>
        /// Constructeur vide de la classe.
        /// </summary>
        public Reservation()
        {
        }
    }
}
