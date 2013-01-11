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
        /// Retourne la liste des artistes.
        /// </summary>
        /// <returns>La liste des Artistes.</returns>
        public IList<Artiste> getArtistes()
        {
            IList<Artiste> artistes = new List<Artiste>();

            artistes.Add(new Artiste(0, new DateTime(1999, 12, 25), "Man", "Iron"));
            artistes.Add(new Artiste(1, new DateTime(1998, 7, 6), "Zidane", "Zinedine"));
            artistes.Add(new Artiste(2, new DateTime(1920, 2, 2), "Wayne", "Bruce"));
            artistes.Add(new Artiste(3, new DateTime(1945, 6, 14), "Parker", "Peter"));
            artistes.Add(new Artiste(4, new DateTime(1982, 3, 12), "Abar", "Ben"));
            artistes.Add(new Artiste(5, new DateTime(1958, 11, 24), "Chabat", "Alain"));
            artistes.Add(new Artiste(6, new DateTime(1957, 3, 23), "Lauby", "Chantal"));

            return artistes;
        }

        /// <summary>
        /// Retourne la liste des evenement.
        /// </summary>
        /// <returns>La liste des evenement.</returns>
        public IList<Evenement> getEvenement()
        {
            IList<Artiste> artistes = new List<Artiste>();
            artistes.Add(new Artiste(0, new DateTime(1999, 12, 25), "Man", "Iron"));
            artistes.Add(new Artiste(1, new DateTime(1998, 8, 6), "Zidane", "Zinedine"));
            artistes.Add(new Artiste(2, new DateTime(1920, 2, 2), "Wayne", "Bruce"));
            artistes.Add(new Artiste(3, new DateTime(1945, 6, 14), "Parker", "Peter"));

            IList<Evenement> events = new List<Evenement>();

            events.Add(new Exposition(artistes, "La ligues des justiciers", 0, 8.50f, "The avengers",50));

            artistes = new List<Artiste>();
            artistes.Add(new Artiste(4, new DateTime(1982, 3, 12), "Abar", "Ben"));
            events.Add(new Concert(artistes, "Concert de Benabar", 1, 1.5f, "Benabar",false,200,10));

            artistes = new List<Artiste>();
            artistes.Add(new Artiste(5, new DateTime(1958, 11, 24), "Chabat", "Alain"));
            artistes.Add(new Artiste(6, new DateTime(1957, 3, 23), "Lauby", "Chantal"));
            events.Add(new Exposition(artistes, "La cité de la peur, le retour.", 1, 16f, "La cité de la peur 2",20));

            return events;
        }

        /// <summary>
        /// Retourne la liste des lieux.
        /// </summary>
        /// <returns>La liste des lieux.</returns>
        public IList<Lieu> getLieux()
        {
            IList<Lieu> lieux = new List<Lieu>();

            lieux.Add(new Lieu(0, "Liberty Island", "53000", "Statue de liberté", 50, "USA", 22f, "06 06 06 06 06", "New York city"));
            lieux.Add(new Lieu(1, "à droite du champs", "26823", "Prairie", 2, "France", 0f, "06 06 06 06 06", "Rochefourchat "));
            lieux.Add(new Lieu(2, "3 rue du capitole", "75005", "Boucherie", 200, "France", 12.5f, "06 06 06 06 06", "Paris"));

            return lieux;
        }


        public IList<PlanningElement> getPlanningElement()
        {
            IList<PlanningElement> pe = new List<PlanningElement>();
            
            IList<Artiste> artistes = new List<Artiste>();
            artistes.Add(new Artiste(0, new DateTime(1999, 12, 25), "Man", "Iron"));
            artistes.Add(new Artiste(1, new DateTime(1998, 8, 6), "Zidane", "Zinedine"));
            artistes.Add(new Artiste(2, new DateTime(1920, 2, 2), "Wayne", "Bruce"));
            artistes.Add(new Artiste(3, new DateTime(1945, 6, 14), "Parker", "Peter"));

            pe.Add(new PlanningElement(new DateTime(2012,12,21,0,0,0),new DateTime(2012,12,21,23,59,59),0,
                new Exposition(artistes, "La ligues des justiciers", 0, 8.50f, "The avengers",50),
                new Lieu(0, "Liberty Island", "53000", "Statue de liberté", 50, "USA", 22f, "06 06 06 06 06", "New York city"), 0));

            artistes = new List<Artiste>();
            artistes.Add(new Artiste(4, new DateTime(1982, 3, 12), "Abar", "Ben"));
            pe.Add(new PlanningElement(new DateTime(2013, 1, 15, 21, 0, 0), new DateTime(2013, 1, 15, 23, 30, 0), 1,
                new Concert(artistes, "Concert de Benabar", 1, 1.5f, "Benabar", false, 200, 10),
                new Lieu(1, "à droite du champs", "26823", "Prairie", 2, "France", 0f, "06 06 06 06 06", "Rochefourchat "), 10));

            artistes = new List<Artiste>();
            artistes.Add(new Artiste(5, new DateTime(1958, 11, 24), "Chabat", "Alain"));
            artistes.Add(new Artiste(6, new DateTime(1957, 3, 23), "Lauby", "Chantal"));
            pe.Add(new PlanningElement(new DateTime(2013, 2, 3, 21, 0, 0), new DateTime(2013, 2, 3, 23, 30, 0), 2,
                new Exposition(artistes, "La cité de la peur, le retour.", 1, 16f, "La cité de la peur 2", 20),
                new Lieu(2, "3 rue du capitole", "75005", "Boucherie", 200, "France", 12.5f, "06 06 06 06 06", "Paris"), 0));
            
            return pe;
        }
    }
}
