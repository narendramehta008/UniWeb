using BaseLibs.DBUtility.EntityModel;

using BaseUIUtility.ViewModel.GeneralViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BaseUIUtility.ViewModel.WebTabViewModel
{
    public class EmbeddeBrowserViewModel : BindingObject
    {

        public EmbeddeBrowserViewModel()
        {
           // DemoActionCommand = new ActionCommand();
        }
        private string _WebAddress= "https://www.google.com/";

        public ICommand EnterPage;

        public ICommand DemoActionCommand;

        // public ICommand Check = new DelegateCommand<object>();

        public string WebAddress
        {
            get { return _WebAddress; }
            set { SetProperty(ref _WebAddress, value); }
        }

        private  string _PageSource="";

        public  string PageSource
        {
            get { return _PageSource; }
            set { SetProperty(ref _PageSource, value); }
        }

        private WebAccount _WebAccount;

        public WebAccount WebAccount
        {
            get { return _WebAccount; }
            set { SetProperty(ref _WebAccount, value); }
        }

        private string _FinalWebAddress = "https://www.google.com/";

        public string FinalWebAddress
        {
            get { return _FinalWebAddress; }
            set { SetProperty(ref _FinalWebAddress, value); }
        }
    }
}
