using BaseLibs.GlobalsPack;
using BaseLibs.Logger;
using BaseUIUtility.CustomControl;
using BaseUIUtility.ViewModel.WebTabViewModel;
using BaseUIUtility.ViewModel.CustomControl;
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
using BaseUniWeb.ViewFunctionality.AllWebFunc;

namespace UniWeb.View.AllWeb
{
    /// <summary>
    /// Interaction logic for FetchDataView.xaml
    /// </summary>
    public partial class FetchDataView : UserControl
    {
        FetchData FetchDataVMFunct { get; set; } = new FetchData();

        public FetchDataView()
        {
            InitializeComponent();
            DataContext = FetchDataVMFunct;
        }

        private static FetchDataView obj;

        public static FetchDataView GetObj()
            => obj ?? (obj = new FetchDataView());
        

       
        private void ButtonImport_Click(object sender, RoutedEventArgs e)
        {
            FetchDataVMFunct.PageData = Global.PageSource;
        }


        private void ButtonAddPattern_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FetchDataInputBoxModel FetchDataInputBoxModel = new FetchDataInputBoxModel();
                FetchDataInputBoxModel.SNos = FetchDataVMFunct.FetchDataInputBoxModelCollection.Count + 1;
                FetchDataVMFunct.FetchDataInputBoxModelCollection.Add(FetchDataInputBoxModel);
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
                FetchDataVMFunct.FetchDataInputBoxModelCollection.Where(x => x.IsValidates).ToList().ForEach(data =>
                {
                   try
                    {
                        FetchDataVMFunct.FetchDataInputBoxModelCollection.Remove(data);
                    }
                    catch (Exception ex)
                    {
                    }
                });
            }
            catch(Exception ex)
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
