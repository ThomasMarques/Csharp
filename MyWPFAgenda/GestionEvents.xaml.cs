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
using BusinessLayer;

namespace MyWPFAgenda
{
    /// <summary>
    /// Logique d'interaction pour GestionEvents.xaml
    /// </summary>
    public partial class GestionEvents : Window
    {
        public GestionEvents()
        {
            InitializeComponent();

            BusinessManager bm = new BusinessManager();

            IList<String> events = bm.getEvenementsSortByDate();

            foreach (String s in events)
            {
                TextBlock tb = new TextBlock();
                tb.Text = s;
                stackPanel.Items.Add(tb);
            }      
        }
    }
}
