using BaseLibs.EntityModel;
using BaseUIUtility.ViewModel.GeneralViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BaseUIUtility.ViewModel.AccountTabViewModel
{
   public class AccountsViewModel : BindingObject
    {
        private bool _IsShowAdvanceSetting;

        public bool IsShowAdvanceSetting
        {
            get { return _IsShowAdvanceSetting; }
            set
            {
                SetProperty(ref _IsShowAdvanceSetting, value);

                if (value)
                    AdvanceSettingWidth = GridLength.Auto;
                else
                    AdvanceSettingWidth = new GridLength(0);
            }
        }

        private Visibility _IsShowAdvanceSettingVisibility = Visibility.Visible;

        public Visibility IsShowAdvanceSettingVisibility
        {
            get { return _IsShowAdvanceSettingVisibility; }
            set { SetProperty(ref _IsShowAdvanceSettingVisibility, value); }
        }

        private GridLength _AdvanceSettingWidth = new GridLength(0);

        public GridLength AdvanceSettingWidth
        {
            get { return _AdvanceSettingWidth; }
            set { SetProperty(ref _AdvanceSettingWidth, value); }
        }


        private ObservableCollection<WebAccount> _WebAccountList = new ObservableCollection<WebAccount>();
       public ObservableCollection<WebAccount> WebAccountList
        {
            get { return _WebAccountList; }
            set { SetProperty(ref _WebAccountList,value); }
        }
    }
}
