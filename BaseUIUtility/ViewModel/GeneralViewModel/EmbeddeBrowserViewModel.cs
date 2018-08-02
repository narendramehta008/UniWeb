using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseUIUtility.ViewModel.GeneralViewModel
{
    public class EmbeddeBrowserViewModel : BindingObject
    {
        private string _WebAddress= "https://www.google.com/";

        public string WebAddress
        {
            get { return _WebAddress; }
            set { SetProperty(ref _WebAddress, value); }
        }

        private string _PageSource="";

        public string PageSource
        {
            get { return _PageSource; }
            set { SetProperty(ref _PageSource, value); }
        }


    }
}
