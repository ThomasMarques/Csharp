using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace DataAccessLayer
{
    public enum DALProvider
    {
        ORACLE,
        SQLSERVER
    }


    public interface IDAL
    {
        /// <summary>
        /// Retourne la liste des artistes.
        /// </summary>
        /// <returns>La liste des Artistes.</returns>
        IList<Artiste> GetAllArtistes();

        /// <summary>
        /// Retourne la liste des evenement.
        /// </summary>
        /// <returns>La liste des evenement.</returns>
        IList<Evenement> GetAllEvenements();

        /// <summary>
        /// Retourne la liste des lieux.
        /// </summary>
        /// <returns>La liste des lieux.</returns>
        IList<Lieu> GetAllLieux();

        /// <summary>
        /// Retourne la liste des planningElement. 
        /// </summary>
        /// <returns>La liste des planningElement.</returns>
        IList<PlanningElement> GetAllPlanningElement();

        /// <summary>
        /// Retourne l'utilisateur correspondant au login passé en paramètre.
        /// </summary>
        /// <param name="login">Login de l'utilisateur recherché.</param>
        /// <returns>L'utilisateur recherché.</returns>
        Utilisateur GetUtilisateurByLogin(String login);


        /// <summary>
        /// Permet de mettre à jour la base.
        /// </summary>
        void Update(IList<PlanningElement> list);

        IList<Utilisateur> GetAllUsers();
    }
}
