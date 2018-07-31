using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BaseUIUtility.ViewModel.GeneralViewModel
{
    public class TabTemplate
    {
        public string TabHeader = string.Empty;
        public Lazy<UserControl> TabContent = new Lazy<UserControl>();
        public Visibility Visibility = Visibility.Visible;

    }
}
