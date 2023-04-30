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
    /// Interaction logic for SimilarMoviesPage.xaml
    /// </summary>
    
    public partial class SimilarMoviesPage : Page
    {
        string[] similarmoviestitles = { };
        string[] similarmoviesimages = { };

        public SimilarMoviesPage()
        {
            InitializeComponent();
            var main = App.Current.MainWindow as MainWindow;
            main.DescriptionButton.Background = new SolidColorBrush(Colors.LightGray);
            main.ActorsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.TrailerButton.Background = new SolidColorBrush(Colors.LightGray);
            main.ScreenshotsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.FactsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.SimilarButton.Background = new SolidColorBrush(Colors.Gray);

            ImageSourceConverter imgs = new ImageSourceConverter();

            getSimilarMovies();

            for (int i = 0; i < similarmoviestitles.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        movie1Name.Text = similarmoviestitles[i];
                        movie1Photo.SetValue(Image.SourceProperty, imgs.ConvertFromString(similarmoviesimages[i]));
                        break;
                    case 1:
                        movie2Name.Text = similarmoviestitles[i];
                        movie2Photo.SetValue(Image.SourceProperty, imgs.ConvertFromString(similarmoviesimages[i]));
                        break;
                    case 2:
                        movie3Name.Text = similarmoviestitles[i];
                        movie3Photo.SetValue(Image.SourceProperty, imgs.ConvertFromString(similarmoviesimages[i]));
                        break;
                    default:
                        break;
                }
            }
        }

        public void getSimilarMovies()
        {
            string[] images = { "", "", "" };
            string[] titles = { "", "", "" };
            var lines = File.ReadLines("scraper\\similarmovies.txt");
            int count = 0;
            foreach (string line in lines)
            {
                string[] values = line.Split('|');
                images[count] = values[0];
                titles[count] = values[1];
                count++;
            }

            similarmoviesimages = images;
            similarmoviestitles = titles;
        }
    }
}
