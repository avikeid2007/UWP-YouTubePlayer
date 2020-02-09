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
            
       
    }
}
