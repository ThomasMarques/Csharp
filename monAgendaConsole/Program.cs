using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using EntitiesLayer;

namespace monAgendaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessManager bm = new BusinessManager();
            int choix = 0;

            while (choix != 5)
            {
                Console.Clear();
                Console.WriteLine("1) Afficher la liste des évenements classés par date.");
                Console.WriteLine("2) Afficher la liste des artistes par ordre alphabétiques.");
                Console.WriteLine("3) Afficher la liste des lieux pour lesquels au moins un evenements est programmé.");
                Console.WriteLine("4) Pour un lieu donné, afficher la liste associés triés par date.");
                Console.WriteLine("5) Quitter.");
                Console.WriteLine();
                Console.WriteLine("Que voulez vous faire ?");
                int.TryParse(Console.ReadLine(), out choix);

                Console.Clear();
                IList<string> str;

                switch (choix)
                {
                    case 1: str = bm.getEvenementsSortByDate();
                        break;

                    case 2: str = bm.getArtistesSortByName();
                        break;

                    case 3: str = bm.getLieuxWithEvents();
                        break;

                    case 4: int lieuChoisi = -1;
                        while(lieuChoisi < 0 || lieuChoisi >= bm.getLieux().Count)
                        {
                            int i = 0;
                            Console.Clear();
                            foreach(Lieu l in bm.getLieux())
                            {
                                Console.WriteLine(i++.ToString() + "\\ " + l.ToString());
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                            Console.WriteLine("Que voulez vous faire ?");
                            int.TryParse(Console.ReadLine(), out lieuChoisi);
                        }

                        str = bm.getEvenementsSortByDate(bm.getLieux().ElementAt(lieuChoisi));
                        break;

                    case 5: str = new List<string>(); 
                        break;

                    default: str = new List<string>();
                        str.Add("Votre choix ne correspond à aucun numéro du menu.");
                        break;
                }

                foreach(string s in str)
                {
                    Console.WriteLine(s);
                    Console.WriteLine();
                }

                if (choix != 5)
                {
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }
    }
}
