using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class Utilisateur
    {
        /// <summary>
        /// Nom de l'utilisateur
        /// </summary>
        private String _nom;

        public String Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        /// <summary>
        /// Prenom de l'utilisateur
        /// </summary>
        private String _prenom;

        public String Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        /// <summary>
        /// Identifiant unique de l'utilisateur
        /// </summary>
        private String _login;

        public String Login
        {
            get { return _login; }
            set { _login = value; }
        }

        /// <summary>
        /// Mot de passe de l'utilisateur
        /// </summary>
        private String _password;

        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// Constructeur public de la classe
        /// </summary>
        /// <param name="nom">Nom de l'utilisateur</param>
        /// <param name="prenom">Prenom de l'utilisateur</param>
        /// <param name="login">Identifiant unique de l'utilisateur</param>
        /// <param name="password">Mot de passe de l'utilisateur</param>
        public Utilisateur(String nom, String prenom, String login, String password)
        {
            Nom = nom;
            Prenom = prenom;
            Login = login;
            Password = password;
        }
    }
}
