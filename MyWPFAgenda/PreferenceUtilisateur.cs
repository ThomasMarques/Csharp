using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWPFAgenda
{
    public class PreferenceUtilisateur
    {
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }


        private double widthMainWindow;
        public double WidthMainWindow
        {
            get { return widthMainWindow; }
            set { widthMainWindow = value; }
        }


        private double heightMainWindow;
        public double HeightMainWindow
        {
            get { return heightMainWindow; }
            set { heightMainWindow = value; }
        }

        private double posX;
        public double PosX
        {
            get { return posX; }
            set { posX = value; }
        }

        private double posY;
        public double PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        /// <summary>
        /// Constructeur sans arguments
        /// </summary>
        public PreferenceUtilisateur()
        {
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="login"></param>
        public PreferenceUtilisateur(String login)
        {
            this.login = login;
        }

        /// <summary>
        /// Charge le fichier XML
        /// </summary>
        /// <param name="login"></param>
        public bool Load(string login)
        {
            XMLAgenda xml = new XMLAgenda(login);
            PreferenceUtilisateur tmp = new PreferenceUtilisateur();
            bool ret=xml.Load(ref tmp);
            if (ret)
            {
                login = tmp.Login;
                HeightMainWindow = tmp.HeightMainWindow;
                WidthMainWindow = tmp.WidthMainWindow;
                PosX = tmp.PosX;
                PosY = tmp.PosY;
            }
            return ret;
        }

        public bool Load()
        {
            return this.Load(this.login);
        }

        /// <summary>
        /// Sauve les données préférences utilisateurs dans un fichier XML
        /// </summary>
        /// <param name="login"></param>
        public void Save(string login)
        {
            XMLAgenda xml = new XMLAgenda(login);
            xml.Save(this);
        }

        public void Save()
        {
            this.Save(this.login);
        }
    }
}
