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
using UniWeb.View.AllWeb;

namespace UniWeb.View.TabContentView
{
    /// <summary>
    /// Interaction logic for AllWebTabContent.xaml
    /// </summary>
    public partial class AllWebTabContent : UserControl
    {
        AllWebTabContentViewModel AllWebTabContentViewModel = new AllWebTabContentViewModel();
        public AllWebTabContent()
        {
            InitializeComponent();
            InitializeValues();
        }

        private void InitializeValues()
        {
            try
            {
                DataContext = AllWebTabContentViewModel;
                //AllWebTabContentViewModel.BrowserTab = new Lazy<UserControl>(() => EmbeddedBrowser.GetObj());
                //AllWebTabContentViewModel.FetchDataTab = new Lazy<UserControl>(() => FetchDataView.GetObj());
            }
            catch (Exception ex)
            {
                ex.ErrorLog();
            }
        }

        private static AllWebTabContent obj;

        public static AllWebTabContent GetObj()
        {
            return obj = (obj ?? new AllWebTabContent());
        }
    }
}
