using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using EntitiesLayer;

namespace WcfServiceAgenda.Business
{
    [DataContract]
    public class ArtistWS
    {
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
            set { _giud = value; }
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
        public ArtistWS(System.Guid guid, string nom, string prenom)
        {
            _giud = guid;
            Nom = nom;
            Prenom = prenom;
        }

        public static Artiste Convert(ArtistWS artiste)
        {
            return new Artiste(artiste.Giud, null, artiste.Nom, artiste.Prenom);
        }

        public static ArtistWS Convert(Artiste artiste)
        {
            return new ArtistWS(artiste.Giud, artiste.Nom, artiste.Prenom);
        }
    }
}