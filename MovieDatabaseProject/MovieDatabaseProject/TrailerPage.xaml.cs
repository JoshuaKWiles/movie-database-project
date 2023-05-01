using System;
using System.IO;
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
using Microsoft.Web.WebView2.Core;

namespace MovieDatabaseProject
{
    /// <summary>
    /// Interaction logic for TrailerPage.xaml
    /// </summary>
    public partial class TrailerPage : Page
    {
        string trailer = "https://www.youtube.com/embed/u31qwQUeGuM";
        public async void initializewebview()
        {
            if(trailer[trailer.Length - 1] == 1)
            {
                webView.Visibility = Visibility.Visible;
                error.Visibility = Visibility.Visible;
                webView.CoreWebView2.Navigate("https://www.youtube.com/embed/u31qwQUeGuM");
                error.Text = "Trailer Not Found :(";
                return;
            }    
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.Navigate(trailer);
        }
        public TrailerPage()
        {
            InitializeComponent();
            error.Visibility = Visibility.Hidden;
            getTrailer();

                initializewebview();

            /*
                if (!(trailer[trailer.Length - 1] == 1))
                {
                    webView.Visibility= Visibility.Hidden;
                    error.Visibility = Visibility.Visible;
                    error.Text = "Trailer Found, error with Microsoft Web View 2. Watch trailer ";
                }
                else
                {
                    error.Text = "Trailer Not Found, error with Microsoft Web View 2.";
                }
            */


            var main = App.Current.MainWindow as MainWindow;
            main.DescriptionButton.Background = new SolidColorBrush(Colors.LightGray);
            main.ActorsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.TrailerButton.Background = new SolidColorBrush(Colors.Gray);
            main.ScreenshotsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.FactsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.SimilarButton.Background = new SolidColorBrush(Colors.LightGray);
            //string trailerLink = getData();
            string moviename = File.ReadAllText(@"scraper\secretmoviename.txt");
            movie_title.Text = moviename + " Trailer";
            
        }
        public void getTrailer()
        {
            string trail = File.ReadAllText("scraper\\trailer.txt");
            trailer = trail;
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(trailer);
        }
    }
}
