using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using EntitiesLayer;

namespace WcfServiceAgenda.Business
{
    [DataContract]
    public class EvenementWS
    {

        /// <summary>
        /// Artistes participant à l'evenement.
        /// </summary>
        protected IList<ArtistWS> _artistes;
        [DataMember]
        public IList<ArtistWS> Artistes
        {
            get { return _artistes; }
            set { _artistes = value; }
        }

        /// <summary>
        /// Description de l'evenement.
        /// </summary>
        protected string _description;
        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Guid de l'evenement.
        /// </summary>
        protected System.Guid _guid;
        [DataMember]
        public System.Guid Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        /// <summary>
        /// Tarif  de l'evenement.
        /// </summary>
        protected float _tarif;
        [DataMember]
        public float Tarif
        {
            get { return _tarif; }
            set { _tarif = value; }
        }

        /// <summary>
        /// Titre de l'evenement.
        /// </summary>
        protected string _titre;
        [DataMember]
        public string Titre
        {
            get { return _titre; }
            set { _titre = value; }
        }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="artistes">artistes praticipant à l'evenement</param>
        /// <param name="desc">description de l'evenement.</param>
        /// <param name="guid">guid de l'evenement.</param>
        /// <param name="tarif">tarif</param>
        /// <param name="titre">titre</param>
        public EvenementWS(IList<ArtistWS> artistes, string desc, System.Guid guid, float tarif, string titre)
        {
            _artistes = artistes;
            _description = desc;
            _guid = guid;
            _tarif = tarif;
            _titre = titre;
        }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="desc">description de l'evenement.</param>
        /// <param name="guid">guid de l'evenement.</param>
        /// <param name="tarif">tarif</param>
        /// <param name="titre">titre</param>
        public EvenementWS(string desc, System.Guid guid, float tarif, string titre)
        {
            _description = desc;
            _guid = guid;
            _tarif = tarif;
            _titre = titre;
        }

        public static Evenement Convert(EvenementWS ev)
        {
            return new Concert(ev.Description, ev.Guid, ev.Tarif, ev.Titre);
        }

        public static EvenementWS Convert(Evenement ev)
        {
            return new EvenementWS(ev.Description, ev.Guid, ev.Tarif, ev.Titre);
        }
    }
}