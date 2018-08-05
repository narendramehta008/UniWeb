using BaseUIUtility.ViewModel.GeneralViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BaseUIUtility.ViewModel.TabContentViewModel
{
   
    public class AccountTabContentViewModel : BindingObject
    {
        public Lazy<UserControl> AccountTab = new Lazy<UserControl>();
       // public Lazy<UserControl> BrowserTab = new Lazy<UserControl>();
       // public Lazy<UserControl> FetchDataTab = new Lazy<UserControl>();
    }
}
