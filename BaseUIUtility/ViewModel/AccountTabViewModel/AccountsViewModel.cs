using BaseLibs.DBUtility.EntityModel;
//using BaseLibs.EntityModel;
using BaseLibs.Logger;
using BaseUIUtility.ViewModel.GeneralViewModel;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BaseUIUtility.ViewModel.AccountTabViewModel
{
   public class AccountsViewModel : BindingObject
    {
        public AccountsViewModel()
        {
            SubmitDetails = new RelayCommand(Submit, IsValidDetails);
            ViewDetails = new RelayCommand(VisitViewDetails, IsExecute);
            ReturnAllAccountDetails = new RelayCommand(ReturnAllAccountDetailsExecute, IsExecute);

            WebAccountList.Add(new WebAccount() { Username="Demo",Password="password",});
        }

        private bool IsExecute(object arg)
        {
            return true;
        }

        private bool _IsShowAdvanceSetting;
        private Visibility _IsShowAdvanceSettingVisibility = Visibility.Visible;
        private GridLength _AdvanceSettingWidth = new GridLength(0);
        private ObservableCollection<WebAccount> _WebAccountList = new ObservableCollection<WebAccount>();
        private string _EmailAddress = string.Empty;
        private string _UserName = string.Empty;
        private string _Password = string.Empty;


        private Visibility _AccountDetailsVisibility = Visibility.Visible; //Visible
        private Visibility _ShowAllAccountDetails = Visibility.Collapsed;//Visible
        public ICommand SubmitDetails;
        public ICommand ViewDetails;
        public ICommand ReturnAllAccountDetails;


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

        public Visibility IsShowAdvanceSettingVisibility
        {
            get { return _IsShowAdvanceSettingVisibility; }
            set { SetProperty(ref _IsShowAdvanceSettingVisibility, value); }
        }

        public GridLength AdvanceSettingWidth
        {
            get { return _AdvanceSettingWidth; }
            set { SetProperty(ref _AdvanceSettingWidth, value); }
        }

        public ObservableCollection<WebAccount> WebAccountList
        {
            get { return _WebAccountList; }
            set { SetProperty(ref _WebAccountList, value); }
        }

        //SubmitDetails

        // [Required]
       // [EmailAddress]
        public string EmailAddress
        {
            get { return _EmailAddress; }
            set { SetProperty(ref _EmailAddress, value); }
        }

       // [Required]
        public string UserName
        {
            get { return _UserName; }
            set { SetProperty(ref _UserName, value); }
        }

       // [Required]
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }

       

        public bool IsValidDetails(object arg)
        {
            return false;
        }

       

        public Visibility AccountDetailsVisibility
        {
            get { return _AccountDetailsVisibility; }
            set { SetProperty(ref _AccountDetailsVisibility, value); }
        }

        public Visibility ShowAllAccountDetails
        {
            get { return _ShowAllAccountDetails; }
            set { SetProperty(ref _ShowAllAccountDetails, value); }
        }

        public void Submit(object obj)
        {
            throw new NotImplementedException();
        }

        public void VisitViewDetails(object obj)
        {
            try
            {
                AccountDetailsVisibility = Visibility.Visible;
                ShowAllAccountDetails = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                ex.ErrorLog();
            }
        }

        public void ReturnAllAccountDetailsExecute(object obj)
        {
            try
            {
                AccountDetailsVisibility = Visibility.Collapsed;
                ShowAllAccountDetails = Visibility.Visible;
            }
            catch (Exception ex)
            {
                ex.ErrorLog();
            }
        }
    }
}
