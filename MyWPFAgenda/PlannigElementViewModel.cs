using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWPFAgenda.ViewModel;
using EntitiesLayer;

namespace MyWPFAgenda
{
    class PlannigElementViewModel : ViewModelBase
    {
        private PlanningElement _planningEvent;

        public PlannigElementViewModel(PlanningElement p)
        {
            _planningEvent = p;
        }

        public DateTime DateDebut
        {
            get { return _planningEvent.DateDebut; }
            set 
            {
                if (_planningEvent.DateDebut == value) return;
                _planningEvent.DateDebut = value;
                base.OnPropertyChanged("DateDebut");
            }
        }

        public DateTime DateFin
        {
            get { return _planningEvent.DateFin; }
            set 
            {
                if (_planningEvent.DateFin == value) return;
                _planningEvent.DateFin = value;
                base.OnPropertyChanged("DateFin");
            }
        }

        public int Guid
        {
            get { return _planningEvent.Guid; }
            set 
            {
                if (_planningEvent.Guid == value) return;
                _planningEvent.Guid = value;
                base.OnPropertyChanged("Guid");
            }
        }

        public Evenement MonEvement
        {
            get { return _planningEvent.MonEvement; }
            set
            {
                if (_planningEvent.MonEvement == value) return;
                _planningEvent.MonEvement = value;
                base.OnPropertyChanged("MonEvenement");
            }
        }

        public Lieu MonLieu
        {
            get { return _planningEvent.MonLieu; }
            set 
            {
                if (_planningEvent.MonLieu == value) return;
                _planningEvent.MonLieu = value;
                base.OnPropertyChanged("MonLieu");
            }
        }

        public int NbPlacesReservees
        {
            get { return _planningEvent.NbPlacesReservees; }
            set
            {
                if (_planningEvent.NbPlacesReservees == value) return;
                _planningEvent.NbPlacesReservees = value;
                base.OnPropertyChanged("NbPlacesReservees");
            }
        }


    }
}
