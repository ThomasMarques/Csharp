using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BusinessLayer;
using EntitiesLayer;

namespace WcfServiceAgenda
{
    public class Service1 : IServiceAgenda
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public IList<Business.ArtistWS> GetAllArtistes()
        {
            IList<Artiste> artistes = new BusinessManager().getArtistesTypeSortByName();
            IList<Business.ArtistWS> ret = new List<Business.ArtistWS>();

            foreach(Artiste a in artistes)
            {
                ret.Add(Business.ArtistWS.Convert(a));
            }

            return ret;
        }

        public IList<Business.EvenementWS> GetAllEvents()
        {
            IList<Evenement> events = new BusinessManager().getEvenements();
            IList<Business.EvenementWS> ret = new List<Business.EvenementWS>();

            foreach (Evenement e in events)
            {
                ret.Add(Business.EvenementWS.Convert(e));
            }

            return ret;
        }

        public IList<Business.LieuWS> GetAllLieux()
        {
            IList<Lieu> lieux = new BusinessManager().getLieux();
            IList<Business.LieuWS> ret = new List<Business.LieuWS>();

            foreach (Lieu l in lieux)
            {
                ret.Add(Business.LieuWS.Convert(l));
            }

            return ret;
        }

        public IList<Business.PlanningElementWS> GetAllPlanningElements()
        {
            IList<PlanningElement> pe = new BusinessManager().getPlanningElements();
            IList<Business.PlanningElementWS> ret = new List<Business.PlanningElementWS>();

            foreach (PlanningElement p in pe)
            {
                ret.Add(Business.PlanningElementWS.Convert(p));
            }

            return ret;
        }

        public IList<Business.UtilisateurWS> GetAllUsers()
        {
            IList<Utilisateur> users = new BusinessManager().GetUsers();
            IList<Business.UtilisateurWS> ret = new List<Business.UtilisateurWS>();

            foreach (Utilisateur u in users)
            {
                ret.Add(Business.UtilisateurWS.Convert(u));
            }

            return ret;
        }
    }
}
