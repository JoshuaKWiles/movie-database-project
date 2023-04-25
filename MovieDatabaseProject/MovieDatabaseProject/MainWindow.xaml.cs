using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void ToolBar_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.ToolBar toolBar = sender as System.Windows.Controls.ToolBar;
            var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
            if (overflowGrid != null)
            {
                overflowGrid.Visibility = Visibility.Collapsed;
            }
            var mainPanelBorder = toolBar.Template.FindName("MainPanelBorder", toolBar) as FrameworkElement;
            if (mainPanelBorder != null)
            {
                mainPanelBorder.Margin = new Thickness();
            }
        }
        public MainWindow()
        {
            InitializeComponent();


            _mainFrame.Navigate(new SearchPage());
            navbar.Visibility = Visibility.Hidden;
            

        }

        private void SearchReturnButton_Click(object sender, RoutedEventArgs e)
        {
            navigate(0);
        }

        private void DescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            navigate(1);
        }

        private void ActorsButton_Click(object sender, RoutedEventArgs e)
        {
            navigate(2); 
        }

        private void TrailerButton_Click(object sender, RoutedEventArgs e)
        {
            navigate(3);
        }

        private void ScreenshotsButton_Click(object sender, RoutedEventArgs e)
        {
            navigate(4);
        }

        private void FactsButton_Click(object sender, RoutedEventArgs e)
        {
            navigate(5);
        }

        private void SimilarButton_Click(object sender, RoutedEventArgs e)
        {
            navigate(6);
        }

        public void navigate(int page)
        {
            switch (page)
            {
                case 0:
                    _mainFrame.Navigate(new SearchPage());
                    navbar.Visibility = Visibility.Hidden;
                    //Task.Factory.StartNew(() => { updateactive(); });
                    break;
                case 1:
                    _mainFrame.Navigate(new DescriptionPage());
                    navbar.Visibility = Visibility.Visible;
                    //Task.Factory.StartNew(() => { updateactive(); });
                    break;
                case 2:
                    _mainFrame.Navigate(new ActorsPage());
                    navbar.Visibility = Visibility.Visible;
                    //Task.Factory.StartNew(() => { updateactive(); });
                    break;
                case 3:
                    _mainFrame.Navigate(new TrailerPage());
                    navbar.Visibility = Visibility.Visible;
                    //Task.Factory.StartNew(() => { updateactive(); });
                    break;
                case 4:
                    _mainFrame.Navigate(new ScreenshotsPage());
                    navbar.Visibility = Visibility.Visible;
                    //Task.Factory.StartNew(() => { updateactive(); });
                    break;
                case 5:
                    _mainFrame.Navigate(new FactsPage());
                    navbar.Visibility = Visibility.Visible;
                    //Task.Factory.StartNew(() => { updateactive(); });
                    break;
                case 6:
                    _mainFrame.Navigate(new SimilarMoviesPage());
                    navbar.Visibility = Visibility.Visible;
                    //Task.Factory.StartNew(() => { updateactive(); });
                    break;
                case 7:
                    _mainFrame.Navigate(new MainPage());
                    navbar.Visibility = Visibility.Hidden;
                    //Task.Factory.StartNew(() => { updateactive(); });
                    break;
                default:
                    _mainFrame.Navigate(new SearchPage());
                    navbar.Visibility = Visibility.Hidden;
                    //Task.Factory.StartNew(() => { updateactive(); });
                    break;
            }
        }
    }
}
