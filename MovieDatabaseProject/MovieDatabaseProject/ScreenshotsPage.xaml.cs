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

namespace MovieDatabaseProject
{
    /// <summary>
    /// Interaction logic for ScreenshotsPage.xaml
    /// </summary>
    public partial class ScreenshotsPage : Page
    {
        string[] imageAddresses = { };
        public ScreenshotsPage()
        {
            InitializeComponent();
            var main = App.Current.MainWindow as MainWindow;
            main.DescriptionButton.Background = new SolidColorBrush(Colors.LightGray);
            main.ActorsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.TrailerButton.Background = new SolidColorBrush(Colors.LightGray);
            main.ScreenshotsButton.Background = new SolidColorBrush(Colors.Gray);
            main.FactsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.SimilarButton.Background = new SolidColorBrush(Colors.LightGray);
            getImages();

        }

        int i = 1;

        private void GoBack(object sender, RoutedEventArgs e)
        {
            i--;
            if (i < 1)
            {
                i = 9;
            }
            picHolder.Source = new BitmapImage(new Uri(imageAddresses[i], UriKind.Relative));
        }

        private void GoNext(object sender, RoutedEventArgs e)
        {
            i++;
            if (i > 9)
            {
                i = 1;
            }
            picHolder.Source = new BitmapImage(new Uri(imageAddresses[i], UriKind.Relative));
        }
        public void getImages()
        {
            using (var reader = new StreamReader("scraper\\screenshots.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    imageAddresses.Append(values[0]);
                }
            }
        }
    }
}
