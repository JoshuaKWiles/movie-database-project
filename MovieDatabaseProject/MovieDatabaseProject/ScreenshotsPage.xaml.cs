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
        ImageSourceConverter imgs = new ImageSourceConverter();
        public ScreenshotsPage()
        {
            InitializeComponent();
            getImages();
            var main = App.Current.MainWindow as MainWindow;
            main.DescriptionButton.Background = new SolidColorBrush(Colors.LightGray);
            main.ActorsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.TrailerButton.Background = new SolidColorBrush(Colors.LightGray);
            main.ScreenshotsButton.Background = new SolidColorBrush(Colors.Gray);
            main.FactsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.SimilarButton.Background = new SolidColorBrush(Colors.LightGray);

            

            string moviename = File.ReadAllText(@"scraper\secretmoviename.txt");
            picHolder.SetValue(Image.SourceProperty, imgs.ConvertFromString(imageAddresses[0]));
            movie_title.Text = moviename + " Screenshots";

        }

        int i = 1;

        private void GoBack(object sender, RoutedEventArgs e)
        {
            i--;
            if (i < 0)
            {
                i = 9;
            }
            picHolder.SetValue(Image.SourceProperty, imgs.ConvertFromString(imageAddresses[i]));
        }

        private void GoNext(object sender, RoutedEventArgs e)
        {
            i++;
            if (i > 9)
            {
                i = 0;
            }
            picHolder.SetValue(Image.SourceProperty, imgs.ConvertFromString(imageAddresses[i]));
        }
        public void getImages()
        {
            string[] images = new string[10];
            var lines = File.ReadLines("scraper\\screenshots.txt");
            int count = 0;
            foreach (string line in lines)
            {
                images[count] = line;
                count++;
            }
            imageAddresses = images;
        }
    }
}
