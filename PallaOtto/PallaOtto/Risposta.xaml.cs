using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace PallaOtto
{

    public partial class Page1 : PhoneApplicationPage
    {
        int introInd;
        int rispInd;
        Random rnd = new Random();
        string[] intro = new string[5] {"Dopo attenta valutazione, la risposta è:", "PallaOtto ha deliberato:", "La risposta è:", "Il verdetto è il seguente:", "PallaOtto dice:"};
        string[] risp = new string[11] {"Assolutamente no!", "Neanche per sogno!","Scordatelo", "Non credo", "Forse..", "Non sono sicuro, riprova!", "Forse sì", "La vedo bene", "Certo!", "Assolutamente sì!", "Senza alcun dubbio!"};

        public Page1()
        {
            InitializeComponent();
            introInd = rnd.Next(0,4);
            rispInd = rnd.Next(0,10);
            txtIntro.Text = intro[introInd];
            txtRisp.Text = risp[rispInd];
            txtDom.Text = PhoneApplicationService.Current.State["dom"].ToString();

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Domanda.xaml", UriKind.Relative));

        }

        private void ShareNewsArticle(string message)
        {
            ShareStatusTask sst = new ShareStatusTask();
            sst.Status = message;
            sst.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShareNewsArticle("Sto usando PallaOtto, e ho appena ricevuto la risposta: "  + risp[rispInd] + "!    #PallaOtto");
        }

    }
}