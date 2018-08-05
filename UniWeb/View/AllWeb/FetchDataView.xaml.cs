﻿using System;
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
        public FetchDataView()
        {
            InitializeComponent();
        }

        private static FetchDataView obj;

        public static FetchDataView GetObj()
        {
            return obj ?? (obj = new FetchDataView());
        }
    }
}
