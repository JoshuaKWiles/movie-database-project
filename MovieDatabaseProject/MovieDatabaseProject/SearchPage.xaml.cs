using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        bool found = false;
        private void run_cmd(string moviename)
        {
            File.WriteAllText("scraper/moviename.txt", moviename);

            ProcessStartInfo start = new ProcessStartInfo("CMD.exe", "(cd scraper) & (python main.py)");
            start.Arguments = string.Format("{0} {1}", "python main.py", moviename);
            start.UseShellExecute = false;
        }
        public SearchPage()
        {
            InitializeComponent();
            var main = App.Current.MainWindow as MainWindow;
        }
        public void DescriptionNav(int page)
        {
            var main = App.Current.MainWindow as MainWindow;
            main.navigate(page);
        }
        public void loading()
        {
            if (File.Exists("scraper/moviename.txt"))
            {
                Thread.Sleep(200);
                loading();
            }
            found = true;
        }
        public async void search()
        {
            string moviename = searchbar.Text;
            if (moviename == "")
            {
                return;
            }

            run_cmd(moviename);

            searchbar.Visibility = Visibility.Hidden;
            searchbutton.Visibility = Visibility.Hidden;
            title.Visibility = Visibility.Hidden;
            instructions.Visibility = Visibility.Hidden;

            loadinggif.Visibility = Visibility.Visible;
            var t = Task.Run(() => loading());
            await t;

            DescriptionNav(7);
            
        }
        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            search();
        }
    }
}
