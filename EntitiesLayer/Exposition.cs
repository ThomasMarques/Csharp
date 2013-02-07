using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class Exposition : Evenement
    {
        /// <summary>
        /// Le nombre d'oeuvres exposées
        /// </summary>
        private int _nombreOeuvreExposees;

        public int NombreOeuvreExposees
        {
            get { return _nombreOeuvreExposees; }
            set { _nombreOeuvreExposees = value; }
        }

        /// <summary>
        /// Constructeur Exposition
        /// </summary>
        /// <param name="artistes">artistes praticipant à l'evenement</param>
        /// <param name="desc">description de l'evenement.</param>
        /// <param name="guid">guid de l'evenement.</param>
        /// <param name="tarif">tarif</param>
        /// <param name="titre">titre</param>
        public Exposition(IList<Artiste> artistes, string desc, System.Guid guid, float tarif, string titre)
            : base(artistes, desc, guid, tarif, titre)
        {
        }

        /// <summary>
        /// Constructeur sans argurment de la classe Exposition
        /// </summary>
        public Exposition()
            : base()
        {
            _nombreOeuvreExposees = 0;
        }

        /// <summary>
        /// Constructeur par copie de Exposition
        /// </summary>
        /// <param name="exp"></param>
        public Exposition(Exposition exp)
            : base(exp as Evenement)
        {
            _nombreOeuvreExposees = exp.NombreOeuvreExposees;
        }

        /// <summary>
        /// Constructeur Exposition
        /// </summary>
        /// <param name="desc">description de l'evenement.</param>
        /// <param name="guid">guid de l'evenement.</param>
        /// <param name="tarif">tarif</param>
        /// <param name="titre">titre</param>
        public Exposition(string desc, System.Guid guid, float tarif, string titre)
            : base(desc, guid, tarif, titre)
        {
        }

        /// <summary>
        /// Permet de calculer le tarif
        /// </summary>
        /// <param name="nbPlaces">le nombre de places demandées</param>
        /// <returns>le tarif calculé</returns>
        public override float CalculerTarif(uint nbPlaces)
        {
            return nbPlaces*_tarif*_nombreOeuvreExposees;
        }

        /// <summary>
        /// Permet d'afficher une exposition
        /// </summary>
        /// <returns>Une string décrivant l'expostion</returns>
        public override string ToString()
        {
            StringBuilder sb=new StringBuilder(base.ToString());
            sb.Append(" - Type : Expo");
            return sb.ToString();
        }

    }
}
