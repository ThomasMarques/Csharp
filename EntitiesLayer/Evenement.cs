using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public abstract class Evenement : IEquatable<Evenement>
    {
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
        protected System.Guid _guid;

        public System.Guid Guid
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
        public Evenement(IList<Artiste> artistes, string desc, System.Guid guid, float tarif, string titre)
        {
            _artistes = artistes;
            _description = desc;
            _guid = guid;
            _tarif = tarif;
            _titre = titre;
        }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="desc">description de l'evenement.</param>
        /// <param name="guid">guid de l'evenement.</param>
        /// <param name="tarif">tarif</param>
        /// <param name="titre">titre</param>
        public Evenement(string desc, System.Guid guid, float tarif, string titre)
        {
            _description = desc;
            _guid = guid;
            _tarif = tarif;
            _titre = titre;
        }

        /// <summary>
        /// Constructeur par copie
        /// </summary>
        /// <param name="e">L'Evenement à copier</param>
        public Evenement(Evenement e)
        {
            _guid = System.Guid.NewGuid();
            _artistes = e.Artistes;
            _description = e.Description;
            _tarif = e.Tarif;
            _titre = e.Titre;
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Evenement()
        {
            _guid = System.Guid.NewGuid();
            _artistes = new List<Artiste>();
            _artistes.Add(new Artiste());
            _description = "Description par défaut";
            _titre = "Titre par défaut";
        }

        public bool Equals(Evenement obj)
        {
            return obj.Guid.Equals(this.Guid);
        }

        /// <summary>
        /// Permet de récupérer une string représentant un evenement.
        /// </summary>
        /// <returns>La string représentant l'evenement.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_titre);
            sb.Append(" - ").Append(_description);

            return sb.ToString();
        }

    }
}
