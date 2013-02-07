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
        PlanningElement _planning;

        public PlanningElement Planning
        {
            set { _planning = value; this.DataContext =new PlannigElementViewModel(_planning); }
        }

        public PlanningElementView()
        {
            InitializeComponent();
        }
    }
}
