using BaseUIUtility.ViewModel.CustomControl;
using BaseUIUtility.ViewModel.GeneralViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseUIUtility.ViewModel.DemoViewModel
{
   public class DemoViewModel : BindingObject
    {
        private int _SNo;
        private string _FirstPattern;
        private string _PageResponse;
        private bool _Validate;
        private FetchDataInputBoxModel _DemoFetchDataInputBoxModel=new FetchDataInputBoxModel();


        public int SNo
        {
            get { return _SNo; }
            set { SetProperty(ref _SNo, value); }
        }
        public string FirstPattern
        {
            get { return _FirstPattern; }
            set { SetProperty(ref _FirstPattern, value); }
        }
        public string PageResponse
        {
            get { return _PageResponse; }
            set { SetProperty(ref _PageResponse, value); }
        }

        public FetchDataInputBoxModel DemoFetchDataInputBoxModel
        {
            get { return _DemoFetchDataInputBoxModel; }
            set { SetProperty(ref _DemoFetchDataInputBoxModel, value); }
        }

    }
}
