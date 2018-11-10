using BaseLibs.GlobalsPack;
using BaseUIUtility.ViewModel.DemoViewModel;
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

namespace UniWeb.View.DemoView
{
    /// <summary>
    /// Interaction logic for DemoCustomControl.xaml
    /// </summary>
    public partial  class DemoCustomControl : UserControl
    {
        DemoViewModel DemoViewModel = new DemoViewModel();
        public DemoCustomControl()
        {
            InitializeComponent();
            InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            try
            {
                DataContext = DemoViewModel;
            }
            catch(Exception ex)
            {
            }
        }

        private static DemoCustomControl obj;

        public static DemoCustomControl GetObj()
            => obj ?? (obj = new DemoCustomControl());

        private void LoadHtml_Click(object sender, RoutedEventArgs e)
        {
            DemoViewModel.PageResponse = Global.PageSource;
        }
    }
}
