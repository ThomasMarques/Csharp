using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EntitiesLayer;
using BusinessLayer;

namespace MyWPFAgenda
{
    /// <summary>
    /// Logique d'interaction pour AddArtist.xaml
    /// </summary>
    public partial class AddArtist : Window
    {
        private BusinessManager bm;

        private Artiste _currentArtiste;
        public Artiste Artiste
        {
            get
            {
                return _currentArtiste;
            }
        }

        public AddArtist()
        {
            bm = new BusinessManager();
            InitializeComponent();
            _currentArtiste = new Artiste();

            foreach (string str in bm.getArtistesSortByName())
            {
                this.ListArtist.Items.Add(str.ToString());
            }
        }

        /// <summary>
        /// Bouton annuler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _currentArtiste = null;
            this.Close();
        }

        /// <summary>
        /// Bouton ajouter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.TabArtiste.SelectedIndex == 0)
            {
                _currentArtiste.Nom = this.Nom.Text;
                _currentArtiste.Prenom = this.Prenom.Text;
                _currentArtiste.DateDeNaissance = this.Date.SelectedDate.Value;
            }
            else if (this.TabArtiste.SelectedIndex == -1)
            {
                _currentArtiste = null;
            }
            this.Close();
        }

        /// <summary>
        /// Selection changed dans la liste des Artistes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListArtist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.ListArtist.SelectedIndex != -1)
            {
                _currentArtiste = bm.getArtistesTypeSortByName().ElementAt(this.ListArtist.SelectedIndex);
            }
        }


    }
}
