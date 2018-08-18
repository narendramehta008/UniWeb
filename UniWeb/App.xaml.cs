using BaseLibs.Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace UniWeb
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string EnglishSource = "/BaseUIUtility;component/ResourceStyle/LanguageResource/EngLanguageResource.xaml";
        private static string FrenchSource = "/BaseUIUtility;component/ResourceStyle/LanguageResource/FrLanguageResource.xaml";
        private static string HindiSource = "/BaseUIUtility;component/ResourceStyle/LanguageResource/HindiLanguageResource.xaml";

        protected override void OnStartup(StartupEventArgs e)
        {
            //base.OnStartup(e);
            //Application.Current.MainWindow = new Window();
            //Current.MainWindow.Show();
        }

        public static void ChangeUILanguage(string selectedLangauge)
        {
            try
            {
                var oldWindow = Application.Current.MainWindow;
                ResourceDictionary ResDict = new ResourceDictionary();
                var check = Application.Current.Resources.MergedDictionaries;

                switch (selectedLangauge)
                {
                    case "English":
                        {
                            ResDict.Source = new Uri(EnglishSource, UriKind.RelativeOrAbsolute);
                        }
                        break;
                    case "Hindi":
                        {
                            ResDict.Source = new Uri(HindiSource, UriKind.RelativeOrAbsolute);
                        }
                        break;
                    case "French":
                        {
                            ResDict.Source = new Uri(FrenchSource, UriKind.RelativeOrAbsolute);
                        }
                        break;

                }
                Application.Current.Resources.MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries[0]);
                Application.Current.Resources.MergedDictionaries.Insert(0, ResDict);

                var check2 = Application.Current.Resources.MergedDictionaries;

                //Current.MainWindow = new Window();
                //Current.MainWindow.Show();
                //oldWindow.Close();
            }
            catch (Exception ex)
            {
                ex.ErrorLog();
            }
        }
    }
}
