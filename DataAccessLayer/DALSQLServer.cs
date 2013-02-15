using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DataAccessLayer
{
    public class DALSQLServer : IDAL
    {
        /// <summary>
        /// Chaine permettant la connexion à la base de donées.
        /// </summary>
        private String _connectionString;

        /// <summary>
        /// Instance connecté à la base de données.
        /// </summary>
        private SqlConnection _connection;

        /// <summary>
        /// Listes des artistes chargés depuis la BDD.
        /// </summary>
        private IList<Artiste> _artistes = null;
        /// <summary>
        /// Listes des evenements chargés depuis la BDD.
        /// </summary>
        private IList<Evenement> _events = null;
        /// <summary>
        /// Listes des lieux chargés depuis la BDD.
        /// </summary>
        private IList<Lieu> _lieux = null;
        /// <summary>
        /// Listes des planning element chargés depuis la BDD.
        /// </summary>
        private IList<PlanningElement> _pelmt = null;

        public static String mdp;

        /// <summary>
        /// Conctructeur de la classe DALSQLServer.
        /// </summary>
        /// <param name="connectionString">Chaine permettant la connexion à la base de donées.</param>
        public DALSQLServer(String connectionString)
        {
            _connectionString = connectionString;
            try
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open(); 
                SqlCommand command = new SqlCommand("DELETE FROM Users where login='invite'; INSERT INTO Users VALUES('invite','" + mdp + "','Invi','té');", _connection);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// On ferme la connection à la BDD.
        /// </summary>
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
            /// Pour éviter de recharger la Base de données alrs que rien n'a été modifié.
            if (_artistes == null)
            {
                _artistes = new List<Artiste>();
                System.Guid guid;
                DateTime? birthDate;
                String name;

                DataTable art = GetArtists();

                foreach (DataRow row in art.Rows)
                {
                    guid = (System.Guid)(row[art.Columns[0].ColumnName]);

                    name = row[art.Columns[1].ColumnName].ToString();

                    if (!row[art.Columns[2].ColumnName].Equals(System.DBNull.Value))
                        birthDate = (DateTime?)row[art.Columns[2].ColumnName];
                    else
                        birthDate = null;

                    _artistes.Add(new Artiste(guid, birthDate, name, ""));
                }
            }
            return _artistes;
        }

        /// <summary>
        /// Retourne la liste des evenement.
        /// </summary>
        /// <returns>La liste des evenement.</returns>
        public IList<Evenement> GetAllEvenements()
        {
            /// Pour éviter de recharger la Base de données alrs que rien n'a été modifié.
            if (_events == null)
            {
                _events = new List<Evenement>();

                System.Guid guid;
                String title;
                String desc;
                float price;
                System.Guid eventType;
                DateTime? birthDate;
                String name;

                DataTable even = GetEvents();

                foreach (DataRow row in even.Rows)
                {
                    guid = (System.Guid)(row[even.Columns[0].ColumnName]);

                    if (!row[even.Columns[1].ColumnName].Equals(System.DBNull.Value))
                        title = row[even.Columns[1].ColumnName].ToString();
                    else
                        title = row[even.Columns[1].ColumnName].ToString();

                    if (!row[even.Columns[2].ColumnName].Equals(System.DBNull.Value))
                        desc = row[even.Columns[2].ColumnName].ToString();
                    else
                        desc = null;

                    price = (float)(row[even.Columns[3].ColumnName]);

                    eventType = (System.Guid)row[even.Columns[4].ColumnName];

                    String str = eventType.ToString();

                    Evenement evenement = new Concert(desc, guid, price, title);

                    /// On récupère les artistes associés à l'evenement.
                    IList<Artiste> artistes = new List<Artiste>();

                    DataTable artists = GetArtists(evenement.Guid);

                    foreach (DataRow rowArt in artists.Rows)
                    {
                        guid = (System.Guid)(rowArt[artists.Columns[0].ColumnName]);

                        name = rowArt[artists.Columns[1].ColumnName].ToString();

                        if (!rowArt[artists.Columns[2].ColumnName].Equals(System.DBNull.Value))
                            birthDate = (DateTime?)rowArt[artists.Columns[2].ColumnName];
                        else
                            birthDate = null;

                        artistes.Add(new Artiste(guid, birthDate, name, ""));
                    }

                    evenement.Artistes = artistes;

                    _events.Add(evenement);
                }
            }
            return _events;
        }

        /// <summary>
        /// Retourne la liste des lieux.
        /// </summary>
        /// <returns>La liste des lieux.</returns>
        public IList<Lieu> GetAllLieux()
        {
            if (_lieux == null)
            {
                _lieux = new List<Lieu>();

                System.Guid guid;
                String name;
                String adress;
                float nbPlaces;
                Decimal? pourcent;

                DataTable art = GetLieux();

                foreach (DataRow row in art.Rows)
                {
                    guid = (System.Guid)(row[art.Columns[0].ColumnName]);

                    name = row[art.Columns[1].ColumnName].ToString();

                    if (!row[art.Columns[2].ColumnName].Equals(System.DBNull.Value))
                        adress = row[art.Columns[2].ColumnName].ToString();
                    else
                        adress = null;

                    nbPlaces = (float)row[art.Columns[4].ColumnName];

                    if (!row[art.Columns[6].ColumnName].Equals(System.DBNull.Value))
                        pourcent = (Decimal)(row[art.Columns[6].ColumnName]);
                    else
                        pourcent = null;

                    _lieux.Add(new Lieu(guid, adress, name, (int)nbPlaces, pourcent));
                }
            }
            return _lieux;
        }

        /// <summary>
        /// Retourne la liste des planningElement. 
        /// </summary>
        /// <returns>La liste des planningElement.</returns>
        public IList<PlanningElement> GetAllPlanningElement()
        {
            if (_pelmt == null)
            {
                IList<Evenement> events = GetAllEvenements();
                IList<Lieu> lieux = GetAllLieux();
                _pelmt = new List<PlanningElement>();

                SqlDataReader myReader = null;
                int nbPlaces;
                DateTime? dateEnd;
                DateTime dateBegin;
                System.Guid guid;

                foreach (Evenement e in events)
                {
                    foreach (Lieu l in lieux)
                    {
                        SqlCommand myCommand = new SqlCommand("select * from EVENT_DATE_PLACE"
                                                            + " Where EVENT_GUID = '" + e.Guid.ToString() + "'"
                                                            + " AND PLACE_GUID = '" + l.Guid.ToString() + "'",
                                                                 _connection);

                        myReader = myCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            //guid = new Guid();
                            guid = Guid.NewGuid();
                            dateBegin = (DateTime)myReader["DATE_BEGIN"];

                            Type t = myReader["DATE_END"].GetType();
                            String str = myReader["DATE_END"].ToString();

                            if (myReader["DATE_END"].ToString().Length > 0)
                                dateEnd = (DateTime)myReader["DATE_END"];
                            else
                                dateEnd = null;

                            if (myReader["RESERVED_PLACES"].ToString().Length > 0)
                                nbPlaces = (int)myReader["RESERVED_PLACES"];
                            else
                                nbPlaces = 0;

                            _pelmt.Add(new PlanningElement(dateBegin, dateEnd, guid, e, l, nbPlaces));
                        }
                        myReader.Close();
                    }
                }
            }
            return _pelmt;
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
                                                + "Where login = '" + login.Trim() + "'",
                                                     _connection);
            Utilisateur user = null;

            myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                user = new Utilisateur(myReader["Nom"].ToString(),
                myReader["Prenom"].ToString(),
                myReader["login"].ToString(),
                myReader["password"].ToString());
            }
            myReader.Close();

            return user;
        }


        /// <summary>
        /// Permet de mettre à jour la base.
        /// </summary>
        public void Update(IList<PlanningElement> newList)
        {
            IList<PlanningElement> oldList = GetAllPlanningElement();
            PlanningElement current = null;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < newList.Count; ++i)
            {
                sb.Clear();
                if (oldList.Contains(newList.ElementAt(i)))
                {
                    current = newList.ElementAt(i);
                    oldList.Remove(current);

                    /// MAJ BDD
                    sb.Append("UPDATE Event_Date_Place SET reserved_places = '")
                        .Append(current.NbPlacesReservees).Append("', date_end = ");

                    if (current.DateFin == null)
                    {
                        sb.Append("null ");
                    }
                    else
                    {
                        sb.Append("@DateEnd ");
                    }


                    sb.Append("WHERE event_guid = '").Append(current.MonEvement.Guid.ToString())
                        .Append("' AND place_guid = '").Append(current.MonLieu.Guid.ToString())
                        .Append("' AND date_begin = @DateDeb;");

                    SqlCommand command = new SqlCommand(sb.ToString(), _connection);
                    if (current.DateFin != null)
                        command.Parameters.Add("@DateEnd", SqlDbType.DateTime).Value = current.DateFin;
                    command.Parameters.Add("@DateDeb", SqlDbType.DateTime).Value = current.DateDebut;
                    command.ExecuteNonQuery();
                }
                else
                {
                    current = newList.ElementAt(i);
                    //Insertion de l'evenement

                    //Récupération du guid du type de l'event
                    System.Guid guidType=System.Guid.NewGuid();
                    sb.Append("SELECT GUID FROM EVENT_TYPES WHERE DESCRIPTION='");
                    if (current.MonEvement is Exposition)
                        sb.Append("Exposition'");
                    else
                        sb.Append("Concert'");

                    SqlCommand selectCommand = new SqlCommand(sb.ToString(), _connection);
                    SqlDataReader selectType= selectCommand.ExecuteReader();
                    if (selectType.Read())
                    {
                        guidType= System.Guid.Parse(selectType["GUID"].ToString());
                    }
                    sb.Clear();
                    selectType.Close();

                    sb.Append("INSERT INTO EVENTS VALUES(@Guid,'").Append(current.MonEvement.Titre.ToString())
                        .Append("','").Append(current.MonEvement.Description).Append("',@Price,@Type)");

                    SqlCommand insertEvent = new SqlCommand(sb.ToString(), _connection);
                    insertEvent.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = current.MonEvement.Guid;
                    insertEvent.Parameters.Add("@Price", SqlDbType.Real).Value = current.MonEvement.Tarif;
                    insertEvent.Parameters.Add("@Type", SqlDbType.UniqueIdentifier).Value = guidType;
                    insertEvent.ExecuteNonQuery();
                    sb.Clear();

                    /// Insertion du planning Elemnt
                    sb.Append("INSERT INTO Event_Date_Place VALUES (");
                    /*sb.Append("'").Append(current.MonEvement.Guid.ToString())
                        .Append("','").Append(current.MonLieu.Guid.ToString())
                        .Append("',@DateDeb");*/

                    sb.Append("@Guid, @GuidLieu, @DateDeb");

                    if (current.DateFin == null)
                        sb.Append(",null, '");
                    else
                        sb.Append(",@DateEnd,'");

                    sb.Append(current.NbPlacesReservees).Append("')");

                    SqlCommand command = new SqlCommand(sb.ToString(), _connection);
                    command.Parameters.Add("@Guid", SqlDbType.UniqueIdentifier).Value = current.MonEvement.Guid;
                    command.Parameters.Add("@GuidLieu", SqlDbType.UniqueIdentifier).Value = current.MonLieu.Guid;

                    if (current.DateFin != null)
                        command.Parameters.Add("@DateEnd", SqlDbType.DateTime).Value = current.DateFin;
                    command.Parameters.Add("@DateDeb", SqlDbType.DateTime).Value = current.DateDebut;
                    command.ExecuteNonQuery();


                    sb.Clear();
                    sb.Append("INSERT INTO EVENTS_ARTISTS VALUES (@EventGuid,@ArtistGuid)");
                    SqlCommand artistCommand = new SqlCommand(sb.ToString(), _connection);
                    artistCommand.Parameters.Add("@EventGuid", SqlDbType.UniqueIdentifier).Value = current.MonEvement.Guid;
                     artistCommand.Parameters.Add("@ArtistGuid", SqlDbType.UniqueIdentifier);
                    foreach (Artiste art in current.MonEvement.Artistes)
                    {
                        artistCommand.Parameters["@ArtistGuid"].Value = art.Giud;
                        artistCommand.ExecuteNonQuery();
                    }
                }
            }

            foreach (PlanningElement pe in oldList)
            {
                sb.Clear();
                /// Suppression

                sb.Append("DELETE FROM Event_Date_Place ");
                sb.Append("WHERE event_guid = '").Append(pe.MonEvement.Guid.ToString())
                        .Append("' AND place_guid = '").Append(pe.MonLieu.Guid.ToString()).Append("';");

                SqlCommand command = new SqlCommand(sb.ToString(), _connection);
                command.Parameters.Add("@DateDeb", SqlDbType.DateTime).Value = current.DateDebut;
                command.ExecuteNonQuery();
            }

            /// Pour que les lists soit rechargées après un appel.
            _pelmt = null;
        }

        /// <summary>
        /// Permet de récupérer la liste des lieux sous forme de DataTable.
        /// </summary>
        /// <returns>la liste des lieux sous forme de DataTable.</returns>
        private DataTable GetLieux()
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

            using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Events", _connection))
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

        /// <summary>
        /// Permet de récupérer la liste des Artistes associé à l'évenement en paramètre sous forme de DataTable.
        /// </summary>
        /// <param name="guidEvent">Evenement associé aux artistes</param>
        /// <returns>la liste des Artistes sous forme de DataTable.</returns>
        private DataTable GetArtists(Guid guidEvent)
        {
            DataTable ret = new DataTable();

            StringBuilder whereClause = new StringBuilder();

            /// On récupere la liste des artistes associés à l'événement passé en paramètre.
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select ARTISTS_GUID from Events_Artists "
                                                + "Where EVENTS_GUID = '" + guidEvent.ToString() + "'",
                                                     _connection);

            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                if (whereClause.Length > 0)
                    whereClause.Append(" OR guid='");
                else
                    whereClause.Append(" WHERE guid='");
                whereClause.Append(myReader["ARTISTS_GUID"].ToString()).Append("'");
            }
            myReader.Close();


            using (SqlDataAdapter a = new SqlDataAdapter("SELECT * FROM Artists" + whereClause.ToString(), _connection))
            {
                a.Fill(ret);
            }

            return ret;
        }

        public IList<Utilisateur> GetAllUsers()
        {
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select * from Users",
                                                     _connection);
            IList<Utilisateur> users = new List<Utilisateur>();

            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                users.Add(new Utilisateur(myReader["Nom"].ToString(),
                myReader["Prenom"].ToString(),
                myReader["login"].ToString(),
                myReader["password"].ToString()));
            }
            myReader.Close();

            return users;
        }

    }
}
