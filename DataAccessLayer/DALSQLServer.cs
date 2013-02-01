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

        public static String mdp;

        public DALSQLServer(String connectionString)
        {
            _connectionString = connectionString;
            try
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();

                //SqlCommand command = new SqlCommand("DELETE FROM Users where login='invite'; INSERT INTO Users VALUES('invite','"+mdp+"','Invi','té');",_connection);
                //command.ExecuteNonQuery();
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
        public IList<Artiste> GetAllArtistes()
        {
            IList<Artiste> artistes = new List<Artiste>();
            int guid;
            DateTime birthDate;
            String name;

            foreach (DataRow row in GetArtiste().Rows)
            {
                guid = int.Parse(row[GetArtiste().Columns[0].ColumnName].ToString());
                birthDate = DateTime.Parse(row[GetArtiste().Columns[1].ColumnName].ToString());
                name = row[GetArtiste().Columns[2].ColumnName].ToString();
                artistes.Add(new Artiste(guid, birthDate, name, ""));
            }

            return artistes;
        }

        /// <summary>
        /// Retourne la liste des evenement.
        /// </summary>
        /// <returns>La liste des evenement.</returns>
        public IList<Evenement> GetAllEvenements()
        {
            return null;
        }

        /// <summary>
        /// Retourne la liste des evenement par lieu.
        /// </summary>
        /// <returns>La liste des evenement.</returns>
        public IList<Evenement> GetEvenementsByLieu()
        {
            return null;
        }

        /// <summary>
        /// Retourne la liste des lieux.
        /// </summary>
        /// <returns>La liste des lieux.</returns>
        public IList<Lieu> GetAllLieux()
        {
            return null;
        }

        /// <summary>
        /// Retourne la liste des planningElement. 
        /// </summary>
        /// <returns>La liste des planningElement.</returns>
        public IList<PlanningElement> GetAllPlanningElement()
        {
            return null;
        }

        /// <summary>
        /// Retourne l'utilisateur correspondant au login passé en paramètre.
        /// </summary>
        /// <param name="login">Login de l'utilisateur recherché.</param>
        /// <returns>L'utilisateur recherché.</returns>
        public Utilisateur GetUtilisateurByLogin(String login)
        {
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select * from Users "
                                                + "Where login = '"+login.Trim()+"'",
                                                     _connection);
            Utilisateur user = null;

            myReader = myCommand.ExecuteReader();
            if(myReader.Read())
            {
                user = new Utilisateur(myReader["Nom"].ToString(),
                myReader["Prenom"].ToString(),
                myReader["login"].ToString(),
                myReader["password"].ToString());
            }

            return user;
        }

        
        /// <summary>
        /// Permet de mettre à jour la base.
        /// </summary>
        public void Update()
        {
        }

        /// <summary>
        /// Permet de récupérer la liste des artistes sous forme de DataTable.
        /// </summary>
        /// <returns>la liste des artistes sous forme de DataTable.</returns>
        private DataTable GetArtiste()
        {
            DataTable ret = new DataTable();

            SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Artists", _connection);
            a.Fill(ret);
            

            return ret;
        }

        /// <summary>
        /// Permet de récupérer la liste des lieux sous forme de DataTable.
        /// </summary>
        /// <returns>la liste des lieux sous forme de DataTable.</returns>
        private DataTable GetLieu()
        {
            DataTable ret = new DataTable();

            using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Places", _connection))
            {
                a.Fill(ret);
            }

            return ret;
        }

        /// <summary>
        /// Permet de récupérer la liste des Evenements sous forme de DataTable.
        /// </summary>
        /// <returns>la liste des Evenements sous forme de DataTable.</returns>
        private DataTable GetEvents()
        {
            DataTable ret = new DataTable();

            using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Event", _connection))
            {
                a.Fill(ret);
            }

            return ret;
        }

        /// <summary>
        /// Permet de récupérer la liste des Artistes sous forme de DataTable.
        /// </summary>
        /// <returns>la liste des Artistes sous forme de DataTable.</returns>
        private DataTable GetArtists()
        {
            DataTable ret = new DataTable();

            using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Artists", _connection))
            {
                a.Fill(ret);
            }

            return ret;
        }

        
    }
}
