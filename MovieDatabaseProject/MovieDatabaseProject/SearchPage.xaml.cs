using System;
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
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
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
        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            DescriptionNav(7);
        }
    }
}
