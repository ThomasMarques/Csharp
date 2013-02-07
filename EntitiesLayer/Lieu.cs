using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesLayer
{
    public class Lieu
    {
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
        private System.Guid _guid;

        /// <summary>
        /// seealso _guid
        /// </summary>
        public System.Guid Guid
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
        private Decimal? _pourcentageCommission;

        public Decimal? PourcentageCommission
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
        public Lieu(System.Guid guid, string adresse, string nom, int nbPlacesTotal, Decimal? prctCom)
        {
            _guid = guid;
            _adresse = adresse;
            _nom = nom;
            _nombrePlacesTotal = nbPlacesTotal;
            _pourcentageCommission = prctCom;
        }

        public Lieu()
        {
            _guid =System.Guid.NewGuid();
            _adresse = "Adresse par défaut";
            _codePostal = "00000";
            _nom = "Nom Lieu";
            _nombrePlacesTotal = 0;
            _pourcentageCommission = 0;
            _telephone = "0000000000";
            _ville = "Ma Ville";
        }


        /// <summary>
        /// Constructeur par copie
        /// </summary>
        /// <param name="lieu">Le lieu sur lequel se baser</param>
        public Lieu(Lieu lieu)
        {
            _guid = System.Guid.NewGuid();
            _adresse = lieu.Adresse;
            _codePostal = lieu.CodePostal;
            _nom = lieu.Nom;
            _nombrePlacesTotal = lieu.NombrePlacesTotal;
            _pays = lieu.Pays;
            _pourcentageCommission = lieu.PourcentageCommission;
            _telephone = lieu.Telephone;
            _ville = lieu.Ville;
        }

        /// <summary>
        /// Permet de récupérer une string représentant un Lieu
        /// </summary>
        /// <returns>La string représentant le Lieu</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(_nom);
            if(_adresse != null)
                sb.Append(", ").Append(_adresse);

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

        /// <summary>
        /// Retourne le HashCode de l'objet.
        /// </summary>
        /// <returns>Le HashCode de l'objet</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
