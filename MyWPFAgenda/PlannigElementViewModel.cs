using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWPFAgenda.ViewModel;
using EntitiesLayer;

namespace MyWPFAgenda
{
    public class PlannigElementViewModel : ViewModelBase
    {
        private PlanningElement _planningEvent;

        public PlannigElementViewModel(PlanningElement p)
        {
            _planningEvent = p;
        }

        public DateTime DateDebut
        {
            get {
                if (_planningEvent != null)
                    return _planningEvent.DateDebut;
                return new DateTime();
                }
            set 
            {
                if (_planningEvent.DateDebut == value) return;
                _planningEvent.DateDebut = value;
                base.OnPropertyChanged("DateDebut");
            }
        }

        public DateTime? DateFin
        {
            get { 
                if (_planningEvent != null)
                    return _planningEvent.DateFin;
                return null;
                }
            set 
            {
                if (_planningEvent.DateFin == value) return;
                _planningEvent.DateFin = value;
                base.OnPropertyChanged("DateFin");
            }
        }

        public System.Guid Guid
        {
            get {
                if (_planningEvent != null)
                    return _planningEvent.Guid;
                return Guid.Empty;
                }
            set 
            {
                if (_planningEvent.Guid == value) return;
                _planningEvent.Guid = value;
                base.OnPropertyChanged("Guid");
            }
        }

        public Evenement MonEvement
        {
            get
            {
                if (_planningEvent != null)
                    return _planningEvent.MonEvement;
                return null; 
            }
            set
            {
                if (_planningEvent.MonEvement == value) return;
                _planningEvent.MonEvement = value;
                base.OnPropertyChanged("MonEvenement");
            }
        }

        public Lieu MonLieu
        {
            get {
                if(_planningEvent != null)
                    return _planningEvent.MonLieu;
                return null;
            }
            set 
            {
                if (_planningEvent.MonLieu == value) return;
                _planningEvent.MonLieu = value;
                base.OnPropertyChanged("MonLieu");
            }
        }

        public IList<Lieu> LieuxPossible
        {
            get {return new BusinessLayer.BusinessManager().getLieux();}
        }

        public int NbPlacesReservees
        {
            get { 
                if (_planningEvent != null)
                    return _planningEvent.NbPlacesReservees;
                return 0;
                }
            set
            {
                if (_planningEvent.NbPlacesReservees == value) return;
                _planningEvent.NbPlacesReservees = value;
                base.OnPropertyChanged("NbPlacesReservees");
            }
        }


    }
}
