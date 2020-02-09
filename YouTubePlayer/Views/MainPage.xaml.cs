using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using YouTubePlayer.ViewModels;

namespace YouTubePlayer.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            this.DataContext = ViewModel;
        }
            
        private  void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //<iframe width="640" height="360" src="https://www.youtube.com/embed/hMy5za-m5Ew" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
            var page = @"<Html><Body><h1><iframe width='640' height='360'  src='https://www.youtube.com/embed/hMy5za-m5Ew' frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen ></iframe><h1><Body></Html>";
            var res = page.Replace("'", "\"");
            player.NavigateToString(res);
            //Uri _videoUri = await GetYoutubeUri("3YhQV3aQmb4");
            //if (_videoUri != null)
            //{
            //    player.Source = _videoUri;
            //    player.Play();
            //}
        }
    }
}
