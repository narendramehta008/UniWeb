using BaseLibs.Logger;
using BaseUIUtility.ViewModel.TabContentViewModel;
using System;
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
using UniWeb.View.Account;

namespace UniWeb.View.TabContentView
{
    /// <summary>
    /// Interaction logic for AccountsTabContent.xaml
    /// </summary>
    public partial class AccountsTabContent : UserControl
    {
        public AccountsTabContent()
        {
            InitializeComponent();
            InitializeValues();
        }

        AccountTabContentViewModel AccountTabContentViewModel = new AccountTabContentViewModel();

        private void InitializeValues()
        {
            try
             {
                DataContext = AccountTabContentViewModel;
                AccountTabContentViewModel.AccountTab = new Lazy<UserControl>(() => AccountsView.GetObj());
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
            }
        }

        private static AccountsTabContent obj;

        public static AccountsTabContent GetObj()
        {
            return obj = (obj ?? new AccountsTabContent());
        }
    }
}
