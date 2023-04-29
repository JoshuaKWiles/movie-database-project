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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            string moviename = File.ReadAllText(@"scraper\secretmoviename.txt");
            movie_title.Text = moviename;
        }
        public void DescriptionNav(int page)
        {
            var main = App.Current.MainWindow as MainWindow; 
            main.navigate(page);
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            DescriptionNav(0);
        }

        private void Description_Click(object sender, RoutedEventArgs e)
        {
            DescriptionNav(1);
        }

        private void Actors_Click(object sender, RoutedEventArgs e)
        {
            DescriptionNav(2);
        }

        private void Trailer_Click(object sender, RoutedEventArgs e)
        {
            DescriptionNav(3);
        }

        private void Screenshots_Click(object sender, RoutedEventArgs e)
        {
            DescriptionNav(4);
        }

        private void Facts_Click(object sender, RoutedEventArgs e)
        {
            DescriptionNav(5);
        }

        private void Similar_Click(object sender, RoutedEventArgs e)
        {
            DescriptionNav(6);
        }
    }
}
