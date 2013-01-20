using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesLayer;

namespace SubDataAccessLayer
{
    public class DalManager
    {
        /// <summary>
        /// Liste des artistes présent dans la base de données.
        /// </summary>
        IList<Artiste> _artistes;

        /// <summary>
        /// Liste des events présent dans la base de données.
        /// </summary>
        IList<Evenement> _events;

        /// <summary>
        /// Liste des lieux présent dans la base de données.
        /// </summary>
        IList<Lieu> _lieux;

        /// <summary>
        /// Liste des planningElement présent dans la base de données.
        /// </summary>
        IList<PlanningElement> _pe;


        public DalManager()
        {
            // Création artistes
            _artistes = new List<Artiste>();

            _artistes.Add(new Artiste(0, new DateTime(1999, 12, 25), "Man", "Iron"));
            _artistes.Add(new Artiste(1, new DateTime(1998, 7, 6), "Zidane", "Zinedine"));
            _artistes.Add(new Artiste(2, new DateTime(1920, 2, 2), "Wayne", "Bruce"));
            _artistes.Add(new Artiste(3, new DateTime(1945, 6, 14), "Parker", "Peter"));
            _artistes.Add(new Artiste(4, new DateTime(1982, 3, 12), "Abar", "Ben"));
            _artistes.Add(new Artiste(5, new DateTime(1958, 11, 24), "Chabat", "Alain"));
            _artistes.Add(new Artiste(6, new DateTime(1957, 3, 23), "Lauby", "Chantal"));

            // Création evenements
            _events = new List<Evenement>();

            IList<Artiste> artistesTmp = ((List<Artiste>)_artistes).GetRange(0, 4);

            _events.Add(new Exposition(artistesTmp, "La ligues des justiciers", 0, 8.50f, "The avengers", 50));
            _events.Add(new Exposition(artistesTmp, "Le retour des supers héros", 1, 8.50f, "Le retour des supers héros", 50));
            _events.Add(new Exposition(artistesTmp, "La suite du film \"Le retour des supers héros\"", 2, 8.50f, "Le re-retour des supers héros", 50));

            artistesTmp = ((List<Artiste>)_artistes).GetRange(4, 1);
            _events.Add(new Concert(artistesTmp, "Concert de Benabar", 3, 1.5f, "Benabar", false, 200, 10));

            artistesTmp = ((List<Artiste>)_artistes).GetRange(5, 2);
            _events.Add(new Exposition(artistesTmp, "La cité de la peur, le retour.", 4, 16f, "La cité de la peur 2", 20));

            // Création des lieux
            _lieux = new List<Lieu>();

            _lieux.Add(new Lieu(0, "Liberty Island", "53000", "Statue de liberté", 50, "USA", 22f, "06 06 06 06 06", "New York city"));
            _lieux.Add(new Lieu(1, "à droite du champs", "26823", "Prairie", 2, "France", 0f, "06 06 06 06 06", "Rochefourchat "));
            _lieux.Add(new Lieu(2, "3 rue du capitole", "75005", "Boucherie", 200, "France", 12.5f, "06 06 06 06 06", "Paris"));

            // Création des PlanningElements
            IList<PlanningElement> pe = new List<PlanningElement>();

            pe.Add(new PlanningElement(new DateTime(2012, 12, 21, 0, 0, 0), new DateTime(2012, 12, 21, 23, 59, 59), 0,
                _events.ElementAt(0),_lieux.ElementAt(0),0));

            pe.Add(new PlanningElement(new DateTime(2013, 1, 21, 0, 0, 0), new DateTime(2013, 1, 21, 23, 59, 59), 0,
                _events.ElementAt(1), _lieux.ElementAt(0), 0));

            pe.Add(new PlanningElement(new DateTime(2013, 2, 21, 0, 0, 0), new DateTime(2013, 2, 21, 23, 59, 59), 0,
                _events.ElementAt(2), _lieux.ElementAt(0), 0));

            pe.Add(new PlanningElement(new DateTime(2013, 1, 15, 21, 0, 0), new DateTime(2013, 1, 15, 23, 30, 0), 1,
                _events.ElementAt(3), _lieux.ElementAt(1), 0));

            pe.Add(new PlanningElement(new DateTime(2013, 2, 3, 21, 0, 0), new DateTime(2013, 2, 3, 23, 30, 0), 2,
                _events.ElementAt(4), _lieux.ElementAt(2), 0));
        }

        /// <summary>
        /// Retourne la liste des artistes.
        /// </summary>
        /// <returns>La liste des Artistes.</returns>
        public IList<Artiste> getArtistes()
        {
            return _artistes;
        }

        /// <summary>
        /// Retourne la liste des evenement.
        /// </summary>
        /// <returns>La liste des evenement.</returns>
        public IList<Evenement> getEvenement()
        {
            return _events;
        }

        /// <summary>
        /// Retourne la liste des lieux.
        /// </summary>
        /// <returns>La liste des lieux.</returns>
        public IList<Lieu> getLieux()
        {
            return _lieux;
        }

        /// <summary>
        /// Retourne la liste des planningElement. 
        /// </summary>
        /// <returns>La liste des planningElement.</returns>
        public IList<PlanningElement> getPlanningElement()
        {
            return _pe;
        }

        /// <summary>
        /// Retourne l'utilisateur correspondant au login passé en paramètre.
        /// </summary>
        /// <param name="login">Login de l'utilisateur recherché.</param>
        /// <returns>L'utilisateur recherché.</returns>
        public static Utilisateur getUtilisateurByLogin(String login)
        {
            // Création des Utilisateurs
            IList<Utilisateur> users = new List<Utilisateur>();

            users.Add(new Utilisateur("Eyheramono", "Gaëtan", "eyhega", "pass"));
            users.Add(new Utilisateur("Marques", "Thomas", "marquest", "mdp"));
            users.Add(new Utilisateur("Un", "invité", "invite", "invite"));


            // Recherche
            Utilisateur search = null;
            foreach (Utilisateur user in users)
            {
                if (user.Login.Equals(login)) 
                {
                    search = user;
                    break;
                }
            }
            return search;
        }
    }
}
