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
    /// Logique d'interaction pour Lieux.xaml
    /// </summary>
    public partial class Lieux : Window
    {
        public Lieux()
        {
            InitializeComponent();
            BusinessManager bm = new BusinessManager();
            IList<string> list=bm.getLieuxWithEvents();

            stackPanel.Children.Add(new TextBlock());

            foreach (string s in list)
            {
                TextBlock tb = new TextBlock();
                tb.Text = s;
                stackPanel.Children.Add(tb);
            }

            window.Height = 120 + 18 * list.Count;
            window.MaxHeight = 120 + 18 * list.Count;

        }
    }
}
