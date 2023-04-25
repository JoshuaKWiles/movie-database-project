﻿using System;
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
    /// Interaction logic for DescriptionPage.xaml
    /// </summary>
    public partial class DescriptionPage : Page
    {
        public DescriptionPage()
        {
            InitializeComponent();
            var main = App.Current.MainWindow as MainWindow;
            main.DescriptionButton.Background = new SolidColorBrush(Colors.Gray);
            main.ActorsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.TrailerButton.Background = new SolidColorBrush(Colors.LightGray);
            main.ScreenshotsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.FactsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.SimilarButton.Background = new SolidColorBrush(Colors.LightGray);
        }
        public void actorsPage()
        {
            
        }
    }
}