using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using MyWPFAgenda.ViewModel;
using EntitiesLayer;

namespace MyWPFAgenda
{
    /// <summary>
    /// Logique d'interaction pour GestionEvents.xaml
    /// </summary>
    public partial class GestionEventsView : Window
    {
        //ObservableCollection<PlannigElementViewModel> obs;
        BusinessLayer.BusinessManager bm;

        private GestionEventsViewModel _gestionEvent;
        public GestionEventsViewModel GestionEventModel
        {
            set { _gestionEvent = value; this.DataContext = value; }
        }

        public GestionEventsView()
        {
            bm = new BusinessLayer.BusinessManager();

            InitializeComponent();
            this.EventControl.stackPanel.SelectionChanged += new SelectionChangedEventHandler(stackPanel_SelectionChanged);
            GestionEventModel = new GestionEventsViewModel(EventControl,bm.getPlanningElements().OrderBy(m => m.DateDebut).ToList());
            EventControl.Update(_gestionEvent.TempList.OrderBy(m => m.DateDebut).ToList());
        }



        void stackPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.EventControl.stackPanel.SelectedIndex != -1)
            {
                this.EventGestion.Planning = _gestionEvent.TempList.OrderBy(m => m.DateDebut).ElementAt(this.EventControl.stackPanel.SelectedIndex);
                _gestionEvent.CurrentPlanning = _gestionEvent.TempList.OrderBy(m => m.DateDebut).ElementAt(this.EventControl.stackPanel.SelectedIndex);
                this.buttonMoins.IsEnabled = true;
                this.buttonPlus.IsEnabled = true;

            }
            else
            {
                _gestionEvent.CurrentPlanning = null;
                this.EventGestion.Planning = null;
                this.buttonMoins.IsEnabled = false;
                this.buttonPlus.IsEnabled = false;
            }
        }


        /// <summary>
        /// Click bouton -
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMoins_Click(object sender, RoutedEventArgs e)
        {
            _gestionEvent.CurrentPlanning.MonEvement.Artistes.RemoveAt(this.EventGestion.Artistes.SelectedIndex);
            this.EventGestion.Artistes.Items.Refresh();
        }

        /// <summary>
        /// Click bouton +
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
            AddArtist winAr = new AddArtist();
            winAr.ShowDialog();
            if (winAr.Artiste != null && !_gestionEvent.CurrentPlanning.MonEvement.Artistes.Contains(winAr.Artiste)) //Ajout du nouvel artiste
            {
                _gestionEvent.CurrentPlanning.MonEvement.Artistes.Add(winAr.Artiste);
                this.EventGestion.Artistes.Items.Refresh();
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            bm.Update(_gestionEvent.TempList);
            this.Close();
        }
    }
}
