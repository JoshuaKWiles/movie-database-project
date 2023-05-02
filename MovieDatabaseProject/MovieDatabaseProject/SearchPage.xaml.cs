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
        private void installpy()
        {
            ProcessStartInfo ProcessInfo;
            Process Process;
            ProcessInfo = new ProcessStartInfo("CMD.exe", "/C " + "(cd scraper) & (pip install -r requirements.txt)");
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            Process = Process.Start(ProcessInfo);
        }
        private void run_cmd(string moviename)
        {
            File.WriteAllText("scraper/moviename.txt", moviename);
            File.WriteAllText("scraper/secretmoviename.txt", moviename);

            installpy();

            ProcessStartInfo ProcessInfo;
            Process Process;
            ProcessInfo = new ProcessStartInfo("CMD.exe", "/C " + "(cd scraper) & (python main.py)");
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = false;
            Process = Process.Start(ProcessInfo);
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
<<<<<<< HEAD
                if(counter == 200)
                {
                    error = true;
                    return;
                }
=======
>>>>>>> parent of 2a66c3b (have to stop for the night because I sent too many requests, trailer fixed and stuff)
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
            loadingmessage.Visibility = Visibility.Visible;
            var t = Task.Run(() => loading());
            await t;

            searchbar.Visibility = Visibility.Visible;
            searchbutton.Visibility = Visibility.Visible;
            title.Visibility = Visibility.Visible;
            instructions.Visibility = Visibility.Visible;

            loadinggif.Visibility = Visibility.Hidden;
            loadingmessage.Visibility = Visibility.Hidden;
<<<<<<< HEAD
            
            if (error)
            {
                error = false;
                
                searchbar.Foreground = Brushes.Red;
                searchbar.FontWeight = FontWeights.Bold;
                searchbar.Text = "ERROR, MOVIE NOT FOUND!";
                System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(3);
                timer.Tick += (s, en) => {
                    showerror();
                    timer.Stop();
                };
                timer.Start();
                counter = 0;
                return;
            }

            searchrunning = false;
=======
>>>>>>> parent of 2a66c3b (have to stop for the night because I sent too many requests, trailer fixed and stuff)

            DescriptionNav(7);
            
        }
        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            search();
        }
    }
}
