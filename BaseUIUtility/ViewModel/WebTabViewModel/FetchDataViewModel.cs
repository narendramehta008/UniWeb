using BaseUIUtility.ViewModel.CustomControl;
using BaseUIUtility.ViewModel.GeneralViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaseUIUtility.ViewModel.WebTabViewModel
{
   public class FetchDataViewModel : BindingObject
    {
        private string _PageData = string.Empty;
        
        private ObservableCollection<FetchDataInputBoxViewModel> _FetchDataInputBoxViewModelCollection = new ObservableCollection<FetchDataInputBoxViewModel>();

        public string PageData
        {
            get { return _PageData; }
            set { SetProperty(ref _PageData, value); }
        }

        public ObservableCollection<FetchDataInputBoxViewModel> FetchDataInputBoxViewModelCollection
        {
            get { return _FetchDataInputBoxViewModelCollection; }
            set { SetProperty(ref _FetchDataInputBoxViewModelCollection, value); }
        }


    }
}
