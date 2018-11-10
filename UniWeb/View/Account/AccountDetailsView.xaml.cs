using BaseLibs.Logger;
using BaseUIUtility.ViewModel.AccountTabViewModel;
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

namespace UniWeb.View.Account
{
    /// <summary>
    /// Interaction logic for AccountDetailsView.xaml
    /// </summary>
    public partial class AccountDetailsView : UserControl
    {
        AccountsViewModel AccountsViewModel { get; set; } = new AccountsViewModel();
        public AccountDetailsView()
        {
            InitializeComponent();
            InitializeValues();
        }

        private void InitializeValues()
        {
            try
            {
                DataContext = AccountsViewModel;
            }
            catch (Exception ex)
            {
                ex.ErrorLog();
            }
        }
    }
}
