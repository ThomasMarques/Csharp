using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DALSQLServer : IDAL
    {
        private String _connectionString;

        private SqlConnection _connection;

        public DALSQLServer(String connectionString)
        {
            _connectionString = connectionString;
            try
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void close()
        {
            _connection.Close();
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

        /// <summary>
        /// Permet de récupérer la liste des artistes sous forme de DataTable.
        /// </summary>
        /// <returns>la liste des artistes sous forme de DataTable.</returns>
        private DataTable getArtiste()
        {
            DataTable ret = new DataTable();

            using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Artists", _connection))
            {
                a.Fill(ret);
            }

            return ret;
        }

        /// <summary>
        /// Permet de récupérer la liste des lieux sous forme de DataTable.
        /// </summary>
        /// <returns>la liste des lieux sous forme de DataTable.</returns>
        private DataTable getLieu()
        {
            DataTable ret = new DataTable();

            using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Places", _connection))
            {
                a.Fill(ret);
            }

            return ret;
        }

        
    }
}
