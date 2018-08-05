
using BaseLibs.DBUtility;
using BaseLibs.EntityModel;
using BaseLibs.Logger;
using BaseUIUtility.ViewModel.GeneralViewModel;
using FirstFloor.ModernUI.Windows.Controls;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
using UniWeb;
using UniWeb.View.AllWeb;
using UniWeb.View.TabContentView;

namespace UniWeb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeValues();

        }
        MainWindowViewModel MainWindowViewModel = new MainWindowViewModel();
       // private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private void InitializeValues()
        {
            try
            {
                // DBCreation dBCreation = new DBCreation();

                DataContext = MainWindowViewModel;
                Languages.ItemsSource = MainWindowViewModel.Languages;
                MainWindowViewModel.CurrentTab = new Lazy<UserControl>(() => AccountsTabContent.GetObj());

                //FbAccount fbAccount = new FbAccount() { UserId = "26415616", Username = "one", Email = "any.com", Password = "efsdfsdfsdf", LoginStatus = "Not Logged In", LogoSource = "sdfsfd" };
                //DBConnector.AddData(fbAccount);

                XmlConfigurator.Configure();
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
            }
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
            }
        }
        private void WindowMaximize_Click(object sender, RoutedEventArgs e)
        {
            #region Window Maximize
            try
            {
                if (MainWindowViewModel.WindowMaximize.Equals(App.Current.FindResource("LangKeyMaximize").ToString()))
                {
                    MainWindowViewModel.WindowMaximizeIcon = Visibility.Collapsed;
                    MainWindowViewModel.WindowRestoreIcon = Visibility.Visible;
                    WindowState = WindowState.Maximized;
                    MainWindowViewModel.WindowMaximize = App.Current.FindResource("LangKeyRestore").ToString();
                }
                else
                {
                    MainWindowViewModel.WindowMaximizeIcon = Visibility.Visible;
                    MainWindowViewModel.WindowRestoreIcon = Visibility.Collapsed;
                    WindowState = WindowState.Normal;
                    MainWindowViewModel.WindowMaximize = App.Current.FindResource("LangKeyMaximize").ToString();
                }

            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
            }
            #endregion
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string winClose = "No";
                switch (MainWindowViewModel.SelectedLanguage)
                {
                    case "English":
                        {
                            winClose = ModernDialog.ShowMessage("Are you really want to exit?", "UniWeb", MessageBoxButton.YesNo).ToString();
                        }
                        break;

                    case "Hindi":
                        {
                            winClose = ModernDialog.ShowMessage("क्या आप वास्तव में बाहर निकलना चाहते हैं ? ", "UniWeb", MessageBoxButton.YesNo).ToString();
                        }
                        break;
                    case "French":
                        {
                            winClose = ModernDialog.ShowMessage(" vous vraiment quitter ? ", "UniWeb", MessageBoxButton.YesNo).ToString();
                        }
                        break;
                }
                if (winClose.Equals("Yes"))
                    this.Close();
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
            }
        }

        private void Languages_Selected(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                App.ChangeUILanguage(MainWindowViewModel.SelectedLanguage);
                DataContext = MainWindowViewModel;
                Languages.ItemsSource = MainWindowViewModel.Languages;
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
            }
        }


        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string tabSwitch = ((ListViewItem)((ListView)sender).SelectedItem).Name;

                switch (tabSwitch)
                {
                    case "AllAccountTab":
                        MainWindowViewModel.CurrentTab = new Lazy<UserControl>(() => AccountsTabContent.GetObj());
                        break;

                    case "AllWebTab":
                        MainWindowViewModel.CurrentTab = new Lazy<UserControl>(() => AllWebTabContent.GetObj());
                        break;

                        //case "FacebookTab":
                        //    mainWindowViewModel.CurrentTab = new Lazy<UserControl>(FBContentPage.getObj);
                        //    break;
                        //case "TwitterTab":
                        //    GridMain.DataContext = TwitterTab.getObj();
                        //    break;
                        //case "PinterestTab":
                        //    mainWindowViewModel.CurrentTab = new Lazy<UserControl>(PinContentPage.getObj);
                        //    break;

                        //case "FileIOTab":
                        //    mainWindowViewModel.CurrentTab = new Lazy<UserControl>(FileIOContentPage.getObj);
                        //   break;

                }
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.ToString());
            }

        }

      
    }

}
