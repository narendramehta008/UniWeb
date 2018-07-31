using BaseUIUtility.ViewModel.GeneralViewModel;
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

namespace UniWeb.View.AllWeb
{
    /// <summary>
    /// Interaction logic for EmbeddedBrowser.xaml
    /// </summary>
    public partial class EmbeddedBrowser : UserControl
    {
        EmbeddeBrowserViewModel EmbeddeBrowserViewModel = new EmbeddeBrowserViewModel();

        private ICommand EnterPage;

        public EmbeddedBrowser()
        {
            InitializeComponent();
            // EnterPage => (IsExecute, VisitUrl);
        }

        private static EmbeddedBrowser obj;

        public static EmbeddedBrowser GetObj()
        {
            return obj ?? (obj = new EmbeddedBrowser());
        }

        private bool IsExecute(object sender) => true;

        private void VisitUrl(object sender)
        {

        }
    }
}
