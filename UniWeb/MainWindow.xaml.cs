
using BaseLibs.DBUtility;
using BaseLibs.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

            try
            {
                FbAccount fbAccount = new FbAccount() { UserId = "2641545616", Username = "ones", Email = "anys.com", Password = "efsdfsdfsdsdf", LoginStatus = "Not Logged In", LogoSource = "sdfsfbi54d" };
                DBConnector.AddData(fbAccount);
            }
            catch(Exception ex)
            {

            }
        }
    }

    
}
