using BasicMvvm;
using BasicMvvm.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace YouTubePlayer.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string _url;
        private WebView _player;

        public MainViewModel()
        {
            LoadCommand = new DelegateCommand<object>(OnLoadPlayerComandExecute);
            PlayCommand= new DelegateCommand(OnPlayComandExecute);
            Url = "https://www.youtube.com/watch?v=hMy5za-m5Ew";
        }

        private void OnPlayComandExecute()
        {
            try
            {
                if (!string.IsNullOrEmpty(Url) && _player != null)
                {
                    var vid = Url.Split("v=")[1];
                    if (!string.IsNullOrEmpty(vid))
                    {
                        var page = $"<Html><Body><h1><iframe width='640' height='360'  src='https://www.youtube.com/embed/{vid}' frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen ></iframe><h1><Body></Html>";
                        var res = page.Replace("'", "\"");
                        _player.NavigateToString(res);
                    }
                    else
                    {
                        MessageDialog messageDialog = new MessageDialog("Invalid URL");
                        _ = messageDialog.ShowAsync();
                    }
                }
                else
                {
                    MessageDialog messageDialog = new MessageDialog("Invalid URL");
                    _ = messageDialog.ShowAsync();
                }
            }
            catch( Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                _ = messageDialog.ShowAsync();
            }
        }

        private void OnLoadPlayerComandExecute(object obj)
        {
            _player= obj as WebView;
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; OnPropertyChanged(); }
        }
        public ICommand LoadCommand { get; set; }
        public ICommand PlayCommand { get; set; }
    }
}
