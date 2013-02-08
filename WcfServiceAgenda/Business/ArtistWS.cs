using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfServiceAgenda.Business
{
    [DataContract]
    public class ArtistWS
    {
        /// <summary>
        /// Date de naissance de l'artiste.
        /// </summary>
        private DateTime? _dateDeNaissance;

        /// <summary>
        /// seealso _dateDeNaissance
        /// </summary>
        [DataMember]
        public DateTime? DateDeNaissance
        {
            get { return _dateDeNaissance; }
            set { _dateDeNaissance = value; }
        }

        /// <summary>
        /// Identifiant unique de l'artiste.
        /// </summary>
        private System.Guid _giud;

        /// <summary>
        /// seealso _guid
        /// </summary>
        [DataMember]
        public System.Guid Giud
        {
            get { return _giud; }
        }

        /// <summary>
        /// Nom de l'artiste
        /// </summary>
        private string _nom;

        /// <summary>
        /// seealso _nom
        /// </summary>
        [DataMember]
        public string Nom
        {
          get { return _nom; }
          set { _nom = value; }
        }

        /// <summary>
        /// Prénom de l'artiste.
        /// </summary>
        private string _prenom;

        /// <summary>
        /// seealso _prenom
        /// </summary>
        [DataMember]
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        /// <summary>
        /// Constructeur de la classe Artiste.
        /// </summary>
        /// <param name="dateDeNaissance">Date de naissance de l'artiste.</param>
        /// <param name="nom">Nom de l'artiste.</param>
        /// <param name="prenom">Prenom de l'artiste.</param>
        public ArtistWS(System.Guid guid, DateTime? dateDeNaissance, string nom, string prenom)
        {
            _giud = guid;
            DateDeNaissance = dateDeNaissance;
            Nom = nom;
            Prenom = prenom;
        }
    }
}