using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Windows;
using Windows.ApplicationModel.DataTransfer;

// Il modello di elemento per la pagina vuota è documentato all'indirizzo http://go.microsoft.com/fwlink/?LinkId=234238

namespace PallaOttoW8
{
    /// <summary>
    /// Pagina vuota che può essere utilizzata autonomamente oppure esplorata all'interno di un frame.
    /// </summary>
    public sealed partial class Gioco : Page
    {

        int introInd;
        int rispInd;
        Random rnd = new Random();
        string[] intro = new string[5] { "Dopo attenta valutazione, la risposta è:", "PallaOtto ha deliberato:", "La risposta è:", "Il verdetto è il seguente:", "PallaOtto dice:" };
        string[] risp = new string[19] { "Assolutamente no!", "Neanche per sogno!", "Scordatelo", "Mi piacerebbe dirti di sì, ma non posso..", "Ti piacerebbe, eh?", "Purtroppo no", "Non credo", "Forse..", "Io tenterei ancora..", "Ritenta, e sarai più fortunato", "Non sono sicuro, riprova!", "Mentre ci penso su, riprova!", "Forse sì", "La vedo bene", "Certo!", "Assolutamente sì!", "Senza alcun dubbio!", "Ci puoi contare!", "Sicuramente!" };
        DataTransferManager dtm;

        public Gioco()
        {
            this.InitializeComponent();
        }

        private void txtDom_GotFocus(object sender, RoutedEventArgs e)
        {
            txtDom.SelectAll();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            
            InitializeComponent();
            lblDom.Text = txtDom.Text;
            introInd = rnd.Next(0, 4);
            rispInd = rnd.Next(0, 18);
            lblRisp.Text = intro[introInd];
            txtRisp.Text = risp[rispInd];

            txtRisp.Visibility = Visibility.Visible;
            lblRisp.Visibility = Visibility.Visible;
            lblDom.Visibility = Visibility.Visible;
           

        }




        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            dtm = DataTransferManager.GetForCurrentView();
            dtm.DataRequested += dtm_DataRequested;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            dtm.DataRequested -= dtm_DataRequested;
        }

        void dtm_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            string textSource = "Ho chiesto: '" + lblDom.Text + "' e ho appena ricevuto la risposta: '" + txtRisp.Text + "'!    #PallaOtto";
            string textTitle = "#PallaOtto - Responso ricevuto!";
            string textDescription = "Invia ai tuoi amici il responso!";  //This is an optional value.

            DataPackage data = args.Request.Data;
            data.Properties.Title = textTitle;
            data.Properties.Description = textDescription;
            data.SetText(textSource);
        }
 
    }
}
