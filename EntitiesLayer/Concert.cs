using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class Concert : Evenement
    {
        /// <summary>
        /// flag de disposition
        /// </summary>
        private bool _dispoParticuliere;

        public bool DispoParticuliere
        {
            get { return _dispoParticuliere; }
            set { _dispoParticuliere = value; }
        }

        /// <summary>
        /// La durée du concert en min
        /// </summary>
        private int _dureeEnMinute;

        public int DureeEnMinute
        {
            get { return _dureeEnMinute; }
            set { _dureeEnMinute = value; }
        }


        /// <summary>
        /// Le nombre de loges
        /// </summary>
        private int _nbLoges;

        public int NbLoges
        {
            get { return _nbLoges; }
            set { _nbLoges = value; }
        }

        /// <summary>
        /// Calcule le tarif d'un concert
        /// </summary>
        /// <param name="nbPlaces">le nombre de places demandée</param>
        /// <returns>le tarif calculé</returns>
        public override float CalculerTarif(uint nbPlaces)
        {
            return nbPlaces * _tarif * _dureeEnMinute;
        }

        /// <summary>
        /// Constructeur Concert
        /// </summary>
        /// <param name="artistes">artistes praticipant à l'evenement</param>
        /// <param name="desc">description de l'evenement.</param>
        /// <param name="guid">guid de l'evenement.</param>
        /// <param name="tarif">tarif</param>
        /// <param name="titre">titre</param>
        public Concert(IList<Artiste> artistes, string desc, System.Guid guid, float tarif, string titre)
            : base(artistes, desc, guid, tarif, titre)
        {
        }

        /// <summary>
        /// Constructeur Concert
        /// </summary>
        /// <param name="desc">description de l'evenement.</param>
        /// <param name="guid">guid de l'evenement.</param>
        /// <param name="tarif">tarif</param>
        /// <param name="titre">titre</param>
        public Concert(string desc, System.Guid guid, float tarif, string titre)
            : base(desc, guid, tarif, titre)
        {
        }

        /// <summary>
        /// Permet d'afficher un Concert
        /// </summary>
        /// <returns>Une string décrivant le concert</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.Append(" - Type : Concert");
            return sb.ToString();
        }

    }
}
