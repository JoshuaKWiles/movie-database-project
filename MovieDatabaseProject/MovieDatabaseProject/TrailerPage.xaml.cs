﻿using System;
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
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MovieDatabaseProject
{
    /// <summary>
    /// Interaction logic for TrailerPage.xaml
    /// </summary>
    public partial class TrailerPage : Page
    {
        string trailer = "https://www.youtube.com/embed/u31qwQUeGuM";
<<<<<<< HEAD
=======
        public async void initializewebview()
        {
            await webView.EnsureCoreWebView2Async(null);
            //webView.CoreWebView2.Navigate("https://www.youtube.com/embed/u31qwQUeGuM");
            webView.CoreWebView2.Navigate(trailer);
        }
>>>>>>> parent of 2a66c3b (have to stop for the night because I sent too many requests, trailer fixed and stuff)
        public TrailerPage()
        {
            InitializeComponent();
            initializewebview();
            getTrailer();
            var main = App.Current.MainWindow as MainWindow;
            main.DescriptionButton.Background = new SolidColorBrush(Colors.LightGray);
            main.ActorsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.TrailerButton.Background = new SolidColorBrush(Colors.Gray);
            main.ScreenshotsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.FactsButton.Background = new SolidColorBrush(Colors.LightGray);
            main.SimilarButton.Background = new SolidColorBrush(Colors.LightGray);
            string moviename = File.ReadAllText(@"scraper\secretmoviename.txt");
            movie_title.Text = moviename + " Trailer";

        }
        public void getTrailer()
        {
            string trail = File.ReadAllText("scraper\\trailer.txt");
            trailer = trail;
        }
    }
}
