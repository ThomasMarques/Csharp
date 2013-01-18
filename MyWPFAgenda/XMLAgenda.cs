using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyWPFAgenda
{
    public class XMLAgenda
    {
        private string login;
        private const string url="../../../Files/";

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        /// <summary>
        /// Constructeur principal
        /// </summary>
        /// <param name="login">Le login de l'utilisateur</param>
        public XMLAgenda(string login)
        {
            this.login = login;
        }

        /// <summary>
        /// Charge le fichier XML
        /// </summary>
        public bool Load(ref PreferenceUtilisateur inPf)
        {
            StreamReader sr = null;
            bool ret = true;
            try
            {
                sr = new StreamReader(url + login + ".xml");
                XmlSerializer serializer = new XmlSerializer(typeof(PreferenceUtilisateur));
                inPf=serializer.Deserialize(sr) as PreferenceUtilisateur;
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                if(sr != null)
                    sr.Close();
            }
            return ret;
        }

        /// <summary>
        /// Sérialize l'objet dans un fichier XML
        /// </summary>
        public void Save(PreferenceUtilisateur inPf)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(url + login + ".xml");
                XmlSerializer serializer = new XmlSerializer(typeof(PreferenceUtilisateur));
                serializer.Serialize(sw, inPf);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }
    }
}
