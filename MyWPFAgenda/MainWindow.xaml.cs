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

namespace MyWPFAgenda
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PreferenceUtilisateur pf;

        public MainWindow(string login)
        {
            InitializeComponent();
            pf = new PreferenceUtilisateur(login);
            if (pf.Load(login))
            {
                this.Top = pf.PosX;
                this.Left = pf.PosY;
                this.Height = pf.HeightMainWindow;
                this.Width = pf.WidthMainWindow;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new EventByDate().ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new Artistes().ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new EventsByLieu().ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new Lieux().ShowDialog();
        }

        private void Window_Closed_1(object sender, EventArgs e)
        {
            pf.PosX = this.Top;
            pf.PosY = this.Left;
            pf.WidthMainWindow = this.Width;
            pf.HeightMainWindow = this.Height;
            pf.Save();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            new GestionEventsView().ShowDialog();
        }
    }
}
