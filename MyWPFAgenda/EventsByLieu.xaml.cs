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
using EntitiesLayer;

namespace MyWPFAgenda
{
    /// <summary>
    /// Logique d'interaction pour EventsByLieu.xaml
    /// </summary>
    public partial class EventsByLieu : Window
    {
        public EventsByLieu()
        {
            InitializeComponent();
            BusinessManager bm = new BusinessManager();

            foreach(Lieu l in bm.getLieux())
            {
                comboLieu.Items.Add(l);
            }
            stackPanel.Children.Add(new TextBlock());
        }

        private void comboLieu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BusinessManager bm = new BusinessManager();

            stackPanel.Children.RemoveRange(2, stackPanel.Children.Count - 2);

            IList<String> events = bm.getEvenementsSortByDate((Lieu)comboLieu.SelectedItem);

            foreach (String s in events)
            {
                TextBlock tb = new TextBlock();
                tb.Text = s;
                stackPanel.Children.Add(tb);
            }

            window.MaxHeight = 165 + 18 * events.Count;
            window.Height = 165 + 18 * events.Count;

        }
    }
}
