using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BusinessLayer;
using EntitiesLayer;
using WcfServiceAgenda.Business;

namespace WcfServiceAgenda
{
    public class ServiceAgenda : IServiceAgenda
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


        public IList<Business.ArtistWS> GetAllArtistes(String login, String passwd)
        {
            IList<Business.ArtistWS> ret = null;
            if (CheckUser(login, passwd))
            {
                IList<Artiste> artistes = new BusinessManager().getArtistesTypeSortByName();
                ret = new List<Business.ArtistWS>();

                foreach (Artiste a in artistes)
                {
                    ret.Add(Business.ArtistWS.Convert(a));
                }
            }

            return ret;
        }

        public IList<Business.EvenementWS> GetAllEvents(String login, String passwd)
        {
            IList<Business.EvenementWS> ret = null;
            if (CheckUser(login, passwd))
            {
                IList<Evenement> events = new BusinessManager().getEvenements();
                ret = new List<Business.EvenementWS>();

                foreach (Evenement e in events)
                {
                    ret.Add(Business.EvenementWS.Convert(e));
                }
            }

            return ret;
        }

        public IList<Business.LieuWS> GetAllLieux(String login, String passwd)
        {
            IList<Business.LieuWS> ret = null;
            if (CheckUser(login, passwd))
            {
                IList<Lieu> lieux = new BusinessManager().getLieux();
                ret = new List<Business.LieuWS>();

                foreach (Lieu l in lieux)
                {
                    ret.Add(Business.LieuWS.Convert(l));
                }
            }

            return ret;
        }

        public IList<Business.PlanningElementWS> GetAllPlanningElements(String login, String passwd)
        { 
            IList<Business.PlanningElementWS> ret = null;
            
            if(CheckUser(login,passwd))
            {
                IList<PlanningElement> pe = new BusinessManager().getPlanningElements();
                ret = new List<Business.PlanningElementWS>();

                foreach (PlanningElement p in pe)
                {
                    ret.Add(Business.PlanningElementWS.Convert(p));
                }
            }

            return ret;
        }

        public IList<Business.PlanningElementWS> GetAllPlanningElementsByEvent(String login, String passwd, System.Guid guidEvent)
        {
            IList<Business.PlanningElementWS> ret = null;

            if (CheckUser(login, passwd))
            {
                IList<PlanningElement> pe = new BusinessManager().getPlanningElements().Where(a => a.MonEvement.Guid == guidEvent).ToList();
                ret = new List<Business.PlanningElementWS>();

                foreach (PlanningElement p in pe)
                {
                    ret.Add(Business.PlanningElementWS.Convert(p));
                }
            }

            return ret;
        }

        public IList<Business.UtilisateurWS> GetAllUsers(String login, String passwd)
        {
            IList<Business.UtilisateurWS> ret = null;

            if(CheckUser(login,passwd))
            {
                IList<Utilisateur> users = new BusinessManager().GetUsers();
                ret = new List<Business.UtilisateurWS>();

                foreach (Utilisateur u in users)
                {
                    ret.Add(Business.UtilisateurWS.Convert(u));
                }
            }
            return ret;
        }

        public IList<Business.EvenementWS> GetAllEventsByArtiste(String login, String passwd, System.Guid guidArtiste)
        {
            IList<Business.EvenementWS> ret = null;

            if (CheckUser(login, passwd))
            {
                IList<Evenement> pe = new BusinessManager().getEvenements().Where(e => e.Artistes.Select(a => a.Giud).Contains(guidArtiste)).ToList();
                ret = new List<Business.EvenementWS>();

                foreach (Evenement p in pe)
                {
                    ret.Add(Business.EvenementWS.Convert(p));
                }
            }

            return ret;
        }


        private Boolean CheckUser(String login, String passwd)
        {
            Boolean ret = false;

            Utilisateur user = new BusinessManager().GetUserByLogin(login);

            if (user != null)
            {
                ret = passwd.Equals(user.Password);
            }

            return ret;
        }


        public Boolean CreateUser(String yourLogin, String yourPass, String login, String passwd, String nom, String prenom)
        {
            Boolean ret = false;
            if(CheckUser(yourLogin,yourPass))
            {
                Utilisateur user = new Utilisateur(login,passwd,nom,prenom);

                new BusinessManager().CreateUser(login, passwd, nom, prenom);
            }
            return ret;
        }

        public IList<Business.PlanningElementWS> GetPlanningElementByLieu(string login, string passwd, String guidLieu)
        {
            IList<Business.PlanningElementWS> plannings = (from p in new BusinessManager().getPlanningElements()
                                                           where guidLieu.Equals(p.MonLieu.Guid)
                                                           select Business.PlanningElementWS.Convert(p)).ToList();

            return plannings;
        }

        public IList<Business.PlanningElementWS> GetPlanningElementByEvent(string login, string passwd, String guidEv)
        {
            IList<Business.PlanningElementWS> plannings = (from p in new BusinessManager().getPlanningElements()
                                                           where guidEv.Equals(p.MonEvement.Guid)
                                                           select Business.PlanningElementWS.Convert(p)).ToList();

            return plannings;
        }

        public int GetNbPlacesAvailable(String login, String passwd, EntitiesLayer.PlanningElement pe)
        {
            return new BusinessManager().GetNbPlacesAvailable(pe);
        }

        public Boolean AnnulationReservation(System.Guid guidResa)
        {
            return new BusinessManager().AnnulationReservation(guidResa);
        }

        public WcfServiceAgenda.Business.ReservationWS GetReservation(System.Guid guidResa)
        {
            return ReservationWS.Convert(new BusinessManager().GetReservation(guidResa));
        }

        public bool ReserverPlaces(EntitiesLayer.PlanningElement planning, int nbPlaces)
        {
            return new BusinessManager().ReserverPlaces(planning, nbPlaces);
        }
    }
}
