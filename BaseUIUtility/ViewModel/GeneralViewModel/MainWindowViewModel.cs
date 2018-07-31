using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<string> Languages
            = new List<string>() { "English", "French" ,"Hindi"};

        private string _SelectedLanguage = "English";
        public string SelectedLanguage
        {
            get { return _SelectedLanguage; }
            set { SetProperty(ref _SelectedLanguage, value); }
        }

    }
}
