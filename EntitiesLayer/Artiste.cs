﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class Artiste : IEquatable<Artiste>
    {
        /// <summary>
        /// Date de naissance de l'artiste.
        /// </summary>
        private DateTime? _dateDeNaissance;

        /// <summary>
        /// seealso _dateDeNaissance
        /// </summary>
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
        public Artiste(System.Guid guid, DateTime? dateDeNaissance, string nom, string prenom)
        {
            _giud = guid;
            DateDeNaissance = dateDeNaissance;
            Nom = nom;
            Prenom = prenom;
        }

        /// <summary>
        /// Constructeur sans argument de la classe Artiste.
        /// </summary>
        public Artiste()
        {
            _giud = System.Guid.NewGuid();
            _nom = "Mon Nom";
            _prenom = "Mon Prenom";
            _dateDeNaissance = new DateTime(2999, 12, 12);
        }

        /// <summary>
        /// Retourne une chaine de charactère contenant les différents attributs de l'objet.
        /// </summary>
        /// <returns>Une chaine de charactère contenant les différents attributs de l'objet.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_prenom).Append(" ").Append(_nom);
            if(_dateDeNaissance != null)
                sb.Append(" née le  ").Append(((DateTime)_dateDeNaissance).ToString("dd / MM / yyyy"));
            return sb.ToString();
        }

        /// <summary>
        /// Permet de comparer deux Artistes selon leurs noms.
        /// </summary>
        /// <param name="a1">1er artiste.</param>
        /// <param name="a2">2ème artiste</param>
        /// <returns>L'entier de comparaison des deux noms</returns>
        public static int compareName(Artiste a1, Artiste a2)
        {
            return a1.Nom.CompareTo(a2.Nom);
        }

        public bool Equals(Artiste other)
        {
            bool ret = false;
            if (other != null)
            {
                ret = (_giud == other._giud);
            }
            return ret;
        }
    
    }
}
