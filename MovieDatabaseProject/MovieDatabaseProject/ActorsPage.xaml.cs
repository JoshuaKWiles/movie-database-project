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
    /// Interaction logic for ActorsPage.xaml
    /// </summary>
    public partial class ActorsPage : Page
    {
        string[] actornames = { };
        string[] actorimages = { };
        public ActorsPage()
        {
            InitializeComponent();
            getImages();
            var main = App.Current.MainWindow as MainWindow;
            main.DescriptionButton.Background = new SolidColorBrush(Colors.LightGray);
            main.ActorsButton.Background = new SolidColorBrush(Colors.Gray);
            main.TrailerButton.Background = new SolidColorBrush(Colors.LightGray);
            main.ScreenshotsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.FactsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.SimilarButton.Background = new SolidColorBrush(Colors.LightGray);
            
            ImageSourceConverter imgs = new ImageSourceConverter();

            string moviename = File.ReadAllText(@"scraper\secretmoviename.txt");
            movie_title.Text = moviename + " Actors";
            for (int i = 0; i < actornames.Length; i++)
            {
                switch(i)
                {
                    case 0:
                        actor1Name.Text = actornames[i];
                        actor1Photo.SetValue(Image.SourceProperty, imgs.ConvertFromString(actorimages[i]));
                        break;
                    case 1:
                        actor2Name.Text = actornames[i];
                        actor2Photo.SetValue(Image.SourceProperty, imgs.ConvertFromString(actorimages[i]));
                        break;
                    case 2:
                        actor3Name.Text = actornames[i];
                        actor3Photo.SetValue(Image.SourceProperty, imgs.ConvertFromString(actorimages[i]));
                        break;
                    case 3:
                        actor4Name.Text = actornames[i];
                        actor4Photo.SetValue(Image.SourceProperty, imgs.ConvertFromString(actorimages[i]));
                        break;
                    case 4:
                        actor5Name.Text = actornames[i];
                        actor5Photo.SetValue(Image.SourceProperty, imgs.ConvertFromString(actorimages[i]));
                        break;
                    case 5:
                        actor6Name.Text = actornames[i];
                        actor6Photo.SetValue(Image.SourceProperty, imgs.ConvertFromString(actorimages[i]));
                        break;
                    case 6:
                        actor7Name.Text = actornames[i];
                        actor7Photo.SetValue(Image.SourceProperty, imgs.ConvertFromString(actorimages[i]));
                        break;
                    case 7:
                        actor8Name.Text = actornames[i];
                        actor8Photo.SetValue(Image.SourceProperty, imgs.ConvertFromString(actorimages[i]));
                        break;
                    default:
                        break;
                }
            }
            
        }

        public void getImages()
        {
            string[] images = { "", "", "", "", "", "", "", "" };
            string[] actors = { "", "", "", "", "", "", "", "" };
            var lines = File.ReadLines("scraper\\actors.txt");
            int count = 0;
            foreach (string line in lines)
            {
                string[] values = line.Split('|');
                images[count] = values[0];
                actors[count] = values[1];
                count++;
            }
            actor1Name.Text = images.Length.ToString();
            actorimages = images;
            actornames = actors;
        }
    }
}
