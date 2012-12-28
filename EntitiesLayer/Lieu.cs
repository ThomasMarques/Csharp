using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class Lieu
    {

        private static int _nbLieu = 0;

        /// <summary>
        /// L'adresse du lieu
        /// </summary>
        private string _adresse;

        public string Adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }


        /// <summary>
        /// Le code postal
        /// </summary>
        private string _codePostal;
        public string CodePostal
        {
            get { return _codePostal; }
            set { _codePostal = value; }
        }


        /// <summary>
        /// Identifiant unique du lieu.
        /// </summary>
        private int _guid;

        /// <summary>
        /// seealso _guid
        /// </summary>
        public int Guid
        {
            get { return _guid; }
        }


        /// <summary>
        /// Nom du lieu
        /// </summary>
        private string _nom;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        /// <summary>
        /// le nombre de places total
        /// </summary>
        private int _nombrePlacesTotal;

        public int NombrePlacesTotal
        {
            get { return _nombrePlacesTotal; }
            set { _nombrePlacesTotal = value; }
        }


        /// <summary>
        /// Le pays
        /// </summary>
        private string _pays;

        public string Pays
        {
            get { return _pays; }
            set { _pays = value; }
        }

        /// <summary>
        /// Le pourcentange de commission
        /// </summary>
        private float _pourcentageCommission;

        public float PourcentageCommission
        {
            get { return _pourcentageCommission; }
            set { _pourcentageCommission = value; }
        }


        /// <summary>
        /// Le numéro de téléphone
        /// </summary>
        private string _telephone;

        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /// <summary>
        /// La ville
        /// </summary>
        private string _ville;

        public string Ville
        {
            get { return _ville; }
            set { _ville = value; }
        }


        /// <summary>
        /// Constructeur de lieu
        /// </summary>
        /// <param name="adresse">adresse</param>
        /// <param name="codePostal">codePostal</param>
        /// <param name="nom">nom</param>
        /// <param name="nbPlacesTotal">nbPlacesTotal</param>
        /// <param name="pays">pays</param>
        /// <param name="prctCom">pourcentage de commission</param>
        /// <param name="tel">numéro de téléphone</param>
        /// <param name="ville">Ville</param>
        public Lieu(int guid, string adresse, string codePostal, string nom, int nbPlacesTotal, string pays, float prctCom, string tel, string ville)
        {
            ++_nbLieu;
            _guid = guid;
            _adresse = adresse;
            _codePostal = codePostal;
            _nom = nom;
            _nombrePlacesTotal = nbPlacesTotal;
            _pays = pays;
            _pourcentageCommission = prctCom;
            _telephone = tel;
            _ville = ville;
        }

        /// <summary>
        /// Permet de récupérer une string représentant un Lieu
        /// </summary>
        /// <returns>La string représentant le Lieu</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Guid : ").Append(_guid).Append(" Adresse: ").Append(_adresse);
            sb.Append(" Ville : ").Append(_ville).Append(" Nom : ").Append(_nom);
            sb.Append(" Telephone : ").Append(_telephone).Append(" Nb Places: ").Append(_nombrePlacesTotal);
            return sb.ToString();
        }

        /// <summary>
        /// Permet de savoir si l'objet en paramètre est identique à this.
        /// </summary>
        /// <param name="obj">Objet à comparer.</param>
        /// <returns>True si les deux objets sont identiques, false sinon.</returns>
        public override bool Equals(object obj)
        {
            bool ret = false;

            if (obj.GetType() == this.GetType())
                ret = ((Lieu)obj).Guid.Equals(this.Guid);

            return ret;
        }

    }
}
