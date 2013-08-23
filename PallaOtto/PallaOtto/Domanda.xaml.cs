using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PallaOtto
{
    public partial class Domanda : PhoneApplicationPage
    {
        public Domanda()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PhoneApplicationService.Current.State["dom"] = txtDomanda.Text.ToString();
            NavigationService.Navigate(new Uri("/Risposta.xaml", UriKind.Relative));

        }

        private void Cancella(object sender, RoutedEventArgs e)
        {
            txtDomanda.Text = "";
        }




    }
}