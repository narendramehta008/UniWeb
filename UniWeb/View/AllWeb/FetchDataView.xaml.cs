using BaseLibs.GlobalsPack;
using BaseLibs.Logger;
using BaseUIUtility.CustomControl;
using BaseUIUtility.ViewModel.WebTabViewModel;
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
    /// Interaction logic for FetchDataView.xaml
    /// </summary>
    public partial class FetchDataView : UserControl
    {
        FetchDataViewModel FetchDataViewModel { get; set; } = new FetchDataViewModel();

        public FetchDataView()
        {
            InitializeComponent();
        }

        private static FetchDataView obj;

        public static FetchDataView GetObj()
        {
            return obj ?? (obj = new FetchDataView());
        }

       
        private void ButtonImport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FetchDataViewModel.PageData = Global.PageSource;
            }
            catch (Exception ex)
            {
                ex.ErrorLog();
            }
        }


        private void ButtonAddPattern_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PatternCollection.Items.Add(new FetchDataInputBox());
            }
            catch(Exception ex)
            {
                ex.ErrorLog();
            }
        }

        private void MenuItemDeletePattern_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }catch(Exception ex)
            {
                ex.ErrorLog();
            }
        }

        private void MenuItemDuplicatePattern_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ex.ErrorLog();
            }
        }
    }
}
