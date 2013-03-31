using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using EntitiesLayer;
using System.Security.Cryptography;

namespace BusinessLayer
{
    public class BusinessManager
    {
        /// <summary>
        /// Data Access Layer permettant la communication avec la couche persistance.
        /// </summary>
        private IDAL _dal;

        /// <summary>
        /// Constructeur de la classe.
        /// Crée une instance de DalManager.
        /// </summary>
        public BusinessManager()
        {
            _dal = DALManager.GetInstance(DALProvider.SQLSERVER).DataAccessLayer;
        }

        /// <summary>
        /// Permet de récupérer les lieux stocké dans la DAL.
        /// </summary>
        /// <returns>Les lieux stocké dans la DAL.</returns>
        public IList<Lieu> getLieux()
        {
            return _dal.GetAllLieux();
        }

        /// <summary>
        /// Permet de retourner la liste des evenements prevus classés par date.
        /// </summary>
        /// <returns>La liste des evenements prevus classés par date.</returns>
        public IList<String> getEvenementsSortByDate()
        {
            IList<String> events = (from p in _dal.GetAllPlanningElement() 
                                    orderby p.DateDebut
                                    select p.MonEvement.ToString())
                                    .ToList();

            return events;
        }

        /// <summary>
        /// Permets de récupérer la liste des artistes triés par date.
        /// </summary>
        /// <returns>La liste des artistes triés par date.</returns>
        public IList<String> getArtistesSortByName()
        {
            IList<String> artistes = (from a in _dal.GetAllArtistes()
                                      orderby a.Nom
                                      select a.ToString())
                                    .ToList();

            return artistes;
        }

        /// <summary>
        /// Permet de récupérer la liste de tous les Artistes
        /// </summary>
        /// <returns>La liste des artistes</returns>
        public IList<Artiste> getArtistesTypeSortByName()
        {
            IList<Artiste> artistes = _dal.GetAllArtistes().OrderBy(a => a.Nom).ToList();

            return artistes;
        }

        /// <summary>
        /// Permet de récupérer la liste des lieux associés à un evenement.
        /// </summary>
        /// <returns>La liste des lieux associés à un evenement.</returns>
        public IList<String> getLieuxWithEvents()
        {
            IList<String> lieux = (from p in _dal.GetAllPlanningElement()
                                   orderby p.DateDebut
                                   select p.MonLieu.ToString())
                                    .Distinct().ToList();

            return lieux;
        }


        /// <summary>
        /// Permets de récupérer les evenements associés à un lieu triés par date.
        /// </summary>
        /// <param name="inLieu">Le lieu associé aux evenements.</param>
        /// <returns>La liste des evenements associés à un lieu triés par date.</returns>
        public IList<String> getEvenementsSortByDate(Lieu inLieu)
        {
            IList<String> events = (from p in _dal.GetAllPlanningElement()
                                    orderby p.DateDebut
                                    where p.MonLieu.Equals(inLieu)
                                    select p.MonEvement.ToString())
                                    .ToList();

            return events;
        }

        /// <summary>
        /// Permets de vérifier le couple login, mot de passe.
        /// </summary>
        /// <param name="login">Le login de l'utilisateur.</param>
        /// <param name="password">Le mot de passe de l'utilisateur.</param>
        /// <returns>true si la connexion est possible, false sinon.</returns>
        public static Boolean CheckConnectionUser(String login, String password)
        {
            //return true;
            bool connected = false;

            //DALSQLServer.mdp = CalculateSHA1(password);

            Utilisateur user = DALManager.GetInstance(DALProvider.SQLSERVER).DataAccessLayer.GetUtilisateurByLogin(login);

            password = CalculateSHA1(password);

            if (user != null)
            {
                if (password.Equals(user.Password))
                    connected = true;
            }

            return connected;
        }

        /// <summary>
        /// Permets de vérifier le couple login, mot de passe.
        /// </summary>
        /// <param name="login">Le login de l'utilisateur.</param>
        /// <returns>L'utilisateur si le login existe, null sinon.</returns>
        public Utilisateur GetUserByLogin(String login)
        {
            return DALManager.GetInstance(DALProvider.SQLSERVER).DataAccessLayer.GetUtilisateurByLogin(login);
        }

        /// <summary>
        /// Permet de calculer la string hashée en SHA-1.
        /// </summary>
        /// <param name="text">La string à encoder</param>
        /// <param name="enc"></param>
        /// <returns></returns>
        public static string CalculateSHA1(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "").ToLower();
        }


        /// <summary>
        /// Récupère les planning Elements
        /// </summary>
        /// <returns></returns>
        public IList<PlanningElement> getPlanningElements()
        {
            return _dal.GetAllPlanningElement();
        }

        /// <summary>
        /// Récupère les Evenements.
        /// </summary>
        /// <returns></returns>
        public IList<Evenement> getEvenements()
        {
            return _dal.GetAllEvenements();
        }

        /// <summary>
        /// Récupère les Utilisateurs.
        /// </summary>
        /// <returns></returns>
        public IList<Utilisateur> GetUsers()
        {
            return _dal.GetAllUsers();
        }

        public void Update(IList<PlanningElement> list)
        {
            _dal.Update(list);
        }


        public void CreateUser(string login, string passwd, string nom, string prenom)
        {
            _dal.CreateUser(login, passwd, nom, prenom);
        }


        public int GetNbPlacesAvailable(PlanningElement planning)
        {
            return _dal.GetNbPlacesAvailable(planning);
        }

        public Boolean AnnulationReservation(System.Guid guidResa)
        {
            return _dal.AnnulationReservation(guidResa);
        }

        public Reservation GetReservation(System.Guid guidResa)
        {
            return _dal.GetReservation(guidResa);
        }

        public bool ReserverPlaces(PlanningElement planning, int nbPlaces)
        {
            return _dal.ReserverPlaces(planning,nbPlaces);
        }
    }
}
