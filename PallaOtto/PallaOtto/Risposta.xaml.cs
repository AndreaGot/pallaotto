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
        string[] risp = new string[19] {"Assolutamente no!", "Neanche per sogno!","Scordatelo","Mi piacerebbe dirti di sì, ma non posso..", "Ti piacerebbe, eh?","Purtroppo no", "Non credo", "Forse..", "Io tenterei ancora..", "Ritenta, e sarai più fortunato", "Non sono sicuro, riprova!", "Mentre ci penso su, riprova!", "Forse sì", "La vedo bene", "Certo!", "Assolutamente sì!", "Senza alcun dubbio!", "Ci puoi contare!", "Sicuramente!"};

        public Page1()
        {
            InitializeComponent();
            introInd = rnd.Next(0,4);
            rispInd = rnd.Next(0,18);
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
            ShareNewsArticle("Ho chiesto: '" + PhoneApplicationService.Current.State["dom"].ToString() + "' e ho appena ricevuto la risposta: " + risp[rispInd] + "!    #PallaOtto");
        }

    }
}