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
    /// Interaction logic for FactsPage.xaml
    /// </summary>
    public partial class FactsPage : Page
    {
        public FactsPage()
        {
            InitializeComponent();
            var main = App.Current.MainWindow as MainWindow;
            main.DescriptionButton.Background = new SolidColorBrush(Colors.LightGray);
            main.ActorsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.TrailerButton.Background = new SolidColorBrush(Colors.LightGray);
            main.ScreenshotsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.FactsButton.Background = new SolidColorBrush(Colors.Gray);
            main.SimilarButton.Background = new SolidColorBrush(Colors.LightGray);
            string moviename = File.ReadAllText(@"scraper\secretmoviename.txt");
            movie_title.Text = moviename + " Facts";

            getFacts();
        }
        
        public void getFacts()
        {
            string[] facts = { "", "", "", "", ""};
            var lines = File.ReadLines("scraper\\trivia.txt");
            int count = 0;
            foreach (string line in lines)
            {
                facts[count] = "-" + line + "\n";
                count++;
            }
            fact1.Text = facts[0];
            fact2.Text = facts[1];
            fact3.Text = facts[2];
            fact4.Text = facts[3];
            fact5.Text = facts[4];
        }
    }
}
