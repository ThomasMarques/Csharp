using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public abstract class Evenement
    {
        /// <summary>
        /// Nombre d'évenment crée.
        /// </summary>
        private int _nbEvent = 0;

        /// <summary>
        /// Artistes participant à l'evenement.
        /// </summary>
        protected IList<Artiste> _artistes;

        public IList<Artiste> Artistes
        {
            get { return _artistes; }
            set { _artistes = value; }
        }
        
        /// <summary>
        /// Description de l'evenement.
        /// </summary>
        protected string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Guid de l'evenement.
        /// </summary>
        protected int _guid;

        public int Guid
        {
            get { return _guid; }
        }

        /// <summary>
        /// Tarif  de l'evenement.
        /// </summary>
        protected float _tarif;

        public float Tarif
        {
            get { return _tarif; }
            set { _tarif = value; }
        }

        /// <summary>
        /// Titre de l'evenement.
        /// </summary>
        protected string _titre;

        public string Titre
        {
            get { return _titre; }
            set { _titre = value; }
        }

        /// <summary>
        /// (Abstract) Permet de calculer le tarif de l'evenement.
        /// </summary>
        /// <param name="nbPlaces">nombre de places</param>
        /// <returns>Le tarif</returns>
        public abstract float CalculerTarif(uint nbPlaces);

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="artistes">artistes praticipant à l'evenement</param>
        /// <param name="desc">description de l'evenement.</param>
        /// <param name="guid">guid de l'evenement.</param>
        /// <param name="tarif">tarif</param>
        /// <param name="titre">titre</param>
        public Evenement(IList<Artiste> artistes, string desc, int guid, float tarif, string titre)
        {
            ++_nbEvent;
            _artistes = artistes;
            _description = desc;
            _guid = guid;
            _tarif = tarif;
            _titre = titre;
        }

        /// <summary>
        /// Permet de récupérer une string représentant un evenement.
        /// </summary>
        /// <returns>La string représentant l'evenement.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Artistes :");
            foreach(Artiste a in _artistes)
            {
                sb.Append(a.ToString()).Append("\n");
            }
            sb.Append("Titre : ").Append(_titre);
            sb.Append("\nDescription : ").Append(_description);
            sb.Append("\ntarif : ").Append(_tarif);

            return sb.ToString();
        }

    }
}
