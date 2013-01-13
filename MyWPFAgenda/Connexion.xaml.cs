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
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (BusinessManager.CheckConnectionUser(txtLogin.Text.ToLower(), txtPassword.Password))
            {
                new MainWindow().Show();
                this.Close();
            }
            else
            {
                if (txtLogin.Text.Length > 0)
                {
                    labelError.Content = "Couple login, password incorrecte.";
                }
                else
                {
                    labelError.Content = "Le login ne peut pas être vide...";
                }
                    labelError.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void TextBox_Login_changed(object sender, TextChangedEventArgs e)
        {

        }
    }
}
