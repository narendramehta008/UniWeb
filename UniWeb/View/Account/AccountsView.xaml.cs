using BaseLibs.DBUtility;
using BaseLibs.EntityModel;
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
    /// Interaction logic for AccountsView.xaml
    /// </summary>
    public partial class AccountsView : UserControl
    {
        AccountsViewModel AccountsViewModel = new AccountsViewModel();
        public AccountsView()
        {
            InitializeComponent();
            InitializeValues();
        }

        private void InitializeValues()
        {
           try
            {
                this.DataContext = AccountsViewModel;
                AccountsViewModel.WebAccountList = new System.Collections.ObjectModel.ObservableCollection<WebAccount>(DBConnector.GetList<WebAccount>(x => true));
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
            }
        }

        private static AccountsView obj;

        public static AccountsView GetObj()
        {
            return obj ?? (obj = new AccountsView());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.ToString());
            }
        }
    }
}
