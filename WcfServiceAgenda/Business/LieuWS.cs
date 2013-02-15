using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using EntitiesLayer;

namespace WcfServiceAgenda.Business
{
    [DataContract]
    public class LieuWS
    {
        /// <summary>
        /// L'adresse du lieu
        /// </summary>
        private string _adresse;
        [DataMember]
        public string Adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }


        /// <summary>
        /// Identifiant unique du lieu.
        /// </summary>
        private System.Guid _guid;

        /// <summary>
        /// seealso _guid
        /// </summary>
        [DataMember]
        public System.Guid Guid
        {
            get { return _guid; }
        }


        /// <summary>
        /// Nom du lieu
        /// </summary>
        private string _nom;
        [DataMember]
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        /// <summary>
        /// le nombre de places total
        /// </summary>
        private int _nombrePlacesTotal;
        [DataMember]
        public int NombrePlacesTotal
        {
            get { return _nombrePlacesTotal; }
            set { _nombrePlacesTotal = value; }
        }

        /// <summary>
        /// Le pourcentange de commission
        /// </summary>
        [DataMember]
        private Decimal? _pourcentageCommission;

        public Decimal? PourcentageCommission
        {
            get { return _pourcentageCommission; }
            set { _pourcentageCommission = value; }
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
        public LieuWS(System.Guid guid, string adresse, string nom, int nbPlacesTotal, Decimal? prctCom)
        {
            _guid = guid;
            _adresse = adresse;
            _nom = nom;
            _nombrePlacesTotal = nbPlacesTotal;
            _pourcentageCommission = prctCom;
        }


        public static Lieu Convert(LieuWS lieu)
        {
            return new Lieu(lieu.Guid, lieu.Adresse, lieu.Nom, lieu.NombrePlacesTotal, lieu.PourcentageCommission);
        }

        public static LieuWS Convert(Lieu lieu)
        {
            return new LieuWS(lieu.Guid, lieu.Adresse, lieu.Nom, lieu.NombrePlacesTotal, lieu.PourcentageCommission);
        }
    }
}