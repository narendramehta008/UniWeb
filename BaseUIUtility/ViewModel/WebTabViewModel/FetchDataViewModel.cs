using BaseLibs.EnumPack;
using BaseUIUtility.CustomControl;
using BaseUIUtility.ViewModel.CustomControl;
using BaseUIUtility.ViewModel.GeneralViewModel;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;



namespace BaseUIUtility.ViewModel.WebTabViewModel
{
    public class FetchDataViewModel : BindingObject
    {
        
        /// <summary>
        /// 
        /// </summary>
        #region Declaring Variables
        protected string _PageData = string.Empty;
        protected string _SelectedPatternTypes = string.Empty;
        protected bool _IsCheckAll;
        protected ObservableCollection<FetchDataInputBoxModel> _FetchDataInputBoxModelCollection = new ObservableCollection<FetchDataInputBoxModel>();
        protected ObservableCollection<FetchDataInputBoxView> _FetchDataInputBoxCollection = new ObservableCollection<FetchDataInputBoxView>();
        protected ObservableCollection<string> _PatternTypes = new ObservableCollection<string>();
        protected FetchDataInputBoxView _SelectedInputBoxItem;

        
        #endregion

        #region Declaring Commands
        public ICommand IsCheckAllCommand { get; set; }
        public ICommand ExecutePatternCommand { get; set; }
        public ICommand SavePatternCommand { get; set; }
        #endregion

        #region Defining Variables
        public string PageData
        {
            get { return _PageData; }
            set { SetProperty(ref _PageData, value); }
        }

        public bool IsCheckAll
        {
            get { return _IsCheckAll; }
            set { SetProperty(ref _IsCheckAll, value); }
        }

        public ObservableCollection<FetchDataInputBoxModel> FetchDataInputBoxModelCollection
        {
            get { return _FetchDataInputBoxModelCollection; }
            set { SetProperty(ref _FetchDataInputBoxModelCollection, value); }
        }
        public ObservableCollection<FetchDataInputBoxView> FetchDataInputBoxCollection
        {
            get { return _FetchDataInputBoxCollection; }
            set { SetProperty(ref _FetchDataInputBoxCollection, value); }
        }

        public FetchDataInputBoxView SelectedInputBoxItem
        {
            get { return _SelectedInputBoxItem; }
            set { SetProperty(ref _SelectedInputBoxItem, value); }
        }

        public ObservableCollection<string> PatternTypes
        {
            get { return _PatternTypes; }
            set { SetProperty(ref _PatternTypes, value); }
        }

        public string SelectedPatternTypes
        {
            get { return _SelectedPatternTypes; }
            set { SetProperty(ref _SelectedPatternTypes, value); }
        }



        #endregion

    }
}
