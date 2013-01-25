using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class DALManager : IDAL
    {
        private IDAL _dal;

        public IDAL DataAccessLayer
        {
            get { return _dal; }
        }

        private static DALManager _theUniqueInsatnce;

        private DALManager(DALProvider provider)
        {
            if (provider == DALProvider.SQLSERVER)
            {
                _dal = new DALSQLServer("Data Source=(LocalDB)/v11.0;AttachDbFilename=D:/Projet/Csharp/DataAccessLayer/EventsAgenda.mdf;Integrated Security=True");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        public static DALManager GetInstance(DALProvider provider)
        {
            if(_theUniqueInsatnce == null)
                _theUniqueInsatnce = new DALManager(provider);
            return _theUniqueInsatnce;
        }


        /// <summary>
        /// Retourne la liste des artistes.
        /// </summary>
        /// <returns>La liste des Artistes.</returns>
        public IList<Artiste> GetAllArtistes();

        /// <summary>
        /// Retourne la liste des evenement.
        /// </summary>
        /// <returns>La liste des evenement.</returns>
        public IList<Evenement> GetAllEvenements();

        /// <summary>
        /// Retourne la liste des evenement par lieu.
        /// </summary>
        /// <returns>La liste des evenement.</returns>
        public IList<Evenement> GetEvenementsByLieu();

        /// <summary>
        /// Retourne la liste des lieux.
        /// </summary>
        /// <returns>La liste des lieux.</returns>
        public IList<Lieu> GetAllLieux();

        /// <summary>
        /// Retourne la liste des planningElement. 
        /// </summary>
        /// <returns>La liste des planningElement.</returns>
        public IList<PlanningElement> GetAllPlanningElement();

        /// <summary>
        /// Retourne l'utilisateur correspondant au login passé en paramètre.
        /// </summary>
        /// <param name="login">Login de l'utilisateur recherché.</param>
        /// <returns>L'utilisateur recherché.</returns>
        public Utilisateur GetUtilisateurByLogin(String login);


        /// <summary>
        /// Permet de mettre à jour la base.
        /// </summary>
        public void Update();



    }
}
