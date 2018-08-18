using BaseLibs.Logger;
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

namespace BaseUIUtility.CustomControl
{
    /// <summary>
    /// Interaction logic for FetchDataInputBox.xaml
    /// </summary>
    public partial class FetchDataInputBox : UserControl
    {
        FetchDataInputBoxViewModel FetchDataInputBoxViewModel { get; set; } = new FetchDataInputBoxViewModel();

        public FetchDataInputBox()
        {
            InitializeComponent();
            this.DataContext = FetchDataInputBoxViewModel;
        }

        #region viewmodel dependency property
        //public static readonly DependencyProperty SetFetchDataInputBoxViewModelProperty =
        //    DependencyProperty.Register("SetFetchDataInputBoxViewModel",typeof(FetchDataInputBox),
        //       new PropertyMetadata(new FetchDataInputBoxViewModel(), new PropertyChangedCallback(OnSetFetchDataInputBoxChanged)));

        //private static void OnSetFetchDataInputBoxChanged(DependencyObject d,DependencyPropertyChangedEventArgs e)
        //{
        //    FetchDataInputBox fetchDataInputBox = d as FetchDataInputBox;
        //    fetchDataInputBox.OnSetFetchDataInputBoxChanged(e);
        //}
        //private void OnSetFetchDataInputBoxChanged(DependencyPropertyChangedEventArgs e)
        //{
        //    FetchDataInputBoxViewModel = e.NewValue as FetchDataInputBoxViewModel;
        //} 

        //public FetchDataInputBoxViewModel SetFetchDataInputBoxViewModel
        //{
        //    get { return (FetchDataInputBoxViewModel)GetValue(SetFetchDataInputBoxViewModelProperty); }
        //    set { SetValue(SetFetchDataInputBoxViewModelProperty, value); }
        //}

        #endregion


        public static readonly DependencyProperty FetchDataInputBoxViewModelProperty =
    DependencyProperty.Register("SetFetchDataInputBoxViewModel", typeof(FetchDataInputBoxViewModel ),
        typeof(FetchDataInputBox), 
        new PropertyMetadata(OnSetFetchDataInputBoxChanged));//new FetchDataInputBoxViewModel()

        public FetchDataInputBoxViewModel SetFetchDataInputBoxViewModel
        {
            get { return (FetchDataInputBoxViewModel)GetValue(FetchDataInputBoxViewModelProperty); }
            set { SetValue(FetchDataInputBoxViewModelProperty,  value); }
        }

        private static void OnSetFetchDataInputBoxChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FetchDataInputBox fetchDataInputBox = d as FetchDataInputBox;
            //fetchDataInputBox.SetFetchDataInputBoxViewModel(e);
        }

        #region set property
        //public static readonly DependencyProperty SetTextProperty =
        // DependencyProperty.Register("SetText", typeof(string), typeof(FetchDataInputBox), new
        //    PropertyMetadata("", new PropertyChangedCallback(OnSetTextChanged)));

        //public string SetText
        //{
        //    get { return (string)GetValue(SetTextProperty); }
        //    set { SetValue(SetTextProperty, value); }
        //}

        //private static void OnSetTextChanged(DependencyObject d,
        //   DependencyPropertyChangedEventArgs e)
        //{
        //    FetchDataInputBox UserControl1Control = d as FetchDataInputBox;
        //    UserControl1Control.OnSetTextChanged(e);
        //}

        //private void OnSetTextChanged(DependencyPropertyChangedEventArgs e)
        //{
        //    TxtPattern.Text = e.NewValue.ToString();
        //} 
        #endregion


        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ButtonExecute_Click(object sender, RoutedEventArgs e)
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
