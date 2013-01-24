using EntitiesLayer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLayer;

namespace MyWPFAgenda
{
    /// <summary>
    /// Logique d'interaction pour PlanningElementView.xaml
    /// </summary>
    public partial class PlanningElementView : UserControl
    {
        public PlanningElementView()
        {
            InitializeComponent();
            Loaded += PlanningElementView_Loaded;
        }


        void PlanningElementView_Loaded(object sender, RoutedEventArgs e)
        {
            BusinessManager bm = new BusinessManager();
            PlanningElement p = bm.getPlanningElements().ElementAt(0);
            PlannigElementViewModel pe = new PlannigElementViewModel(p);
            this.DataContext = pe;
        }

    }
}
