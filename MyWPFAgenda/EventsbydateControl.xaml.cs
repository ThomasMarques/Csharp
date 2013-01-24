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
    /// Logique d'interaction pour EventsbydateControl.xaml
    /// </summary>
    public partial class EventsbydateControl : UserControl
    {
        public EventsbydateControl()
        {
            InitializeComponent();

            BusinessManager bm = new BusinessManager();

            IList<String> list = bm.getEvenementsSortByDate();

            foreach(String str in list)
            {
                TextBlock tb = new TextBlock();
                tb.Text = str;
                stackPanel.Items.Add(tb);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pas encore fait...");
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("A faire aussi...");
        }
    }
}
