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
using MyWPFAgenda.ViewModel;

namespace MyWPFAgenda
{
    /// <summary>
    /// Logique d'interaction pour EventsbydateControl.xaml
    /// </summary>
    public partial class EventsbydateControl : UserControl
    {

        public EventsbydateControl()
        {
            InitializeComponent();
        }


        public void Update(IList<EntitiesLayer.PlanningElement> list)
        {
            stackPanel.Items.Clear();
            foreach(EntitiesLayer.PlanningElement pe in list)
            {
                TextBlock tb = new TextBlock();
                tb.Text = pe.MonEvement.ToString();
                stackPanel.Items.Add(tb);
            }
        }
    }
}
