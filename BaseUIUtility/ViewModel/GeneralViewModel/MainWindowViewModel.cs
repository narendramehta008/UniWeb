using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BaseUIUtility.ViewModel.GeneralViewModel
{
    public class MainWindowViewModel : BindingObject
    {
        private Lazy<UserControl> _CurrentTab = new Lazy<UserControl>();

        public Lazy<UserControl> CurrentTab
        {
            get { return _CurrentTab; }
            set { SetProperty(ref _CurrentTab, value); }
        }

        public List<string> Languages = new List<string>() { App.Current.FindResource("LanguageEng").ToString(),
                //App.Current.FindResource("LanguageHindi").ToString(),
                App.Current.FindResource("LanguageFr").ToString()};

        private string _SelectedLanguage = App.Current.FindResource("LanguageEng").ToString();

        public string SelectedLanguage
        {
            get { return _SelectedLanguage; }
            set { SetProperty(ref _SelectedLanguage, value); }
        }

        private string _WindowMaximize = App.Current.FindResource("LangKeyMaximize").ToString();

        public string WindowMaximize
        {
            get { return _WindowMaximize; }
            set { SetProperty(ref _WindowMaximize, value); }
        }

        private Visibility _WindowMaximizeIcon = Visibility.Visible;
        public Visibility WindowMaximizeIcon
        {
            get { return _WindowMaximizeIcon; }
            set { SetProperty(ref _WindowMaximizeIcon, value); }
        }

        private Visibility _WindowRestoreIcon = Visibility.Collapsed;
        public Visibility WindowRestoreIcon
        {
            get { return _WindowRestoreIcon; }
            set { SetProperty(ref _WindowRestoreIcon, value); }
        }
    }
}
