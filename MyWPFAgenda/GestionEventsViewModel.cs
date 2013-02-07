using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWPFAgenda.ViewModel;
using System.Windows.Input;
using EntitiesLayer;


namespace MyWPFAgenda
{
    public class GestionEventsViewModel : ViewModelBase
    {

        //Commande Supprimer
        private ICommand _removeCommand;
        public ICommand SupprimerCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new RelayCommand(SupprimerExecute, CanExecuteSupprimerCommand);
                }
                return _removeCommand;
            }
        }

        private bool CanExecuteSupprimerCommand()
        {
            return (_currentPlanning != null);
        }

        public void SupprimerExecute()
        {
            _tempList.Remove(_currentPlanning);
            _currentPlanning = null;
            EventControl.Update(_tempList.OrderBy(m => m.DateDebut).ToList());
        }




        //Command Ajouter
        private ICommand _addCommand;
        public ICommand AjouterCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(AjouterExecute, CanExecuteAjouterCommand);
                }

                return _addCommand;
            }
        }

        private bool CanExecuteAjouterCommand()
        {
            return true;
        }

        public void AjouterExecute()
        {
            _currentPlanning = new PlanningElement();
            _tempList.Add(_currentPlanning);
            EventControl.Update(_tempList.OrderBy(m => m.DateDebut).ToList());
        }

        public GestionEventsViewModel(EventsbydateControl EventControl, List<PlanningElement> list)
        {
            this.EventControl = EventControl;
            TempList = list;
        }
        
        private PlanningElement _currentPlanning;
        public PlanningElement CurrentPlanning
        {
            get
            {
                return _currentPlanning;
            }
            set
            {
                _currentPlanning = value;
            }
        }


        private EventsbydateControl EventControl;
        private IList<PlanningElement> _tempList;
        public IList<PlanningElement> TempList
        {
            get
            {
                return _tempList;
            }
            set
            {
                _tempList = value;
            }
        }

    }
}
