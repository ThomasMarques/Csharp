using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesLayer;
using SubDataAccessLayer;

namespace BusinessLayer
{
    public class BusinessManager
    {
        /// <summary>
        /// Data Access Layer permettant la communication avec la couche persistance.
        /// </summary>
        private DalManager _dal;

        /// <summary>
        /// Constructeur de la classe.
        /// Crée une instance de DalManager.
        /// </summary>
        public BusinessManager()
        {
            _dal = new DalManager();
        }

        /// <summary>
        /// Permet de récupérer les lieux stocké dans la DAL.
        /// </summary>
        /// <returns>Les lieux stocké dans la DAL.</returns>
        public IList<Lieu> getLieux()
        {
            return _dal.getLieux();
        }

        /// <summary>
        /// Permet de retourner la liste des evenements prevus classés par date.
        /// </summary>
        /// <returns>La liste des evenements prevus classés par date.</returns>
        public IList<string> getEvenementsSortByDate()
        {
            IList<string> events = (from p in _dal.getPlanningElement() 
                                    orderby p.DateDebut
                                    select p.MonEvement.ToString())
                                    .ToList();

            return events;
        }

        /// <summary>
        /// Permets de récupérer la liste des artistes triés par date.
        /// </summary>
        /// <returns>La liste des artistes triés par date.</returns>
        public IList<string> getArtistesSortByName()
        {
            IList<string> artistes = (from a in _dal.getArtistes()
                                      orderby a.Nom
                                      select a.ToString())
                                    .ToList();

            return artistes;
        }

        /// <summary>
        /// Permet de récupérer la liste des lieux associés à un evenement.
        /// </summary>
        /// <returns>La liste des lieux associés à un evenement.</returns>
        public IList<string> getLieuxWithEvents()
        {
            IList<string> lieux = (from p in _dal.getPlanningElement()
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
        public IList<string> getEvenementsSortByDate(Lieu inLieu)
        {
            IList<string> events = (from p in _dal.getPlanningElement()
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
            return (login.Length > 0)?login.Equals(password):false;
        }
    }
}
