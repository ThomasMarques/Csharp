using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using EntitiesLayer;

namespace WcfServiceAgenda.Business
{
    [DataContract]
    public class UtilisateurWS
    {
        /// <summary>
        /// Nom de l'utilisateur
        /// </summary>
        private String _nom;
        [DataMember]
        public String Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        /// <summary>
        /// Prenom de l'utilisateur
        /// </summary>
        private String _prenom;
        [DataMember]
        public String Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        /// <summary>
        /// Identifiant unique de l'utilisateur
        /// </summary>
        private String _login;
        [DataMember]
        public String Login
        {
            get { return _login; }
            set { _login = value; }
        }

        /// <summary>
        /// Constructeur public de la classe
        /// </summary>
        /// <param name="nom">Nom de l'utilisateur</param>
        /// <param name="prenom">Prenom de l'utilisateur</param>
        /// <param name="login">Identifiant unique de l'utilisateur</param>
        /// <param name="password">Mot de passe de l'utilisateur</param>
        public UtilisateurWS(String nom, String prenom, String login)
        {
            Nom = nom;
            Prenom = prenom;
            Login = login;
        }

        public static Utilisateur Convert(UtilisateurWS user)
        {
            return new Utilisateur(user.Nom, user.Prenom, user.Login, "");
        }

        public static UtilisateurWS Convert(Utilisateur user)
        {
            return new UtilisateurWS(user.Nom, user.Prenom, user.Login);
        }
    }
}