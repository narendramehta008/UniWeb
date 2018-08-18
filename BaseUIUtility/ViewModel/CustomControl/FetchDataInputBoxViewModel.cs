using BaseLibs.EnumPack;
using BaseUIUtility.ViewModel.GeneralViewModel;
using System;
using System.Collections.Generic;
using BaseUIUtility.ResourceStyle;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace BaseUIUtility.ViewModel.CustomControl
{
    public class FetchDataInputBoxViewModel : BindingObject
    {
        public FetchDataInputBoxViewModel()
        {
        }
        private string _SNo = string.Empty;
        private string _FirstPattern = string.Empty;
        private string _SecondPattern = string.Empty;
        private string _SelectedPatternType = string.Empty;
        private string _GetBetweenString = string.Empty;
        private ObservableCollection<MatchCollection> _RegexResult = new ObservableCollection<MatchCollection>();
        private ObservableCollection<string> _InnerHtml = new ObservableCollection<string>();

        public string SNo
        {
            get { return _SNo; }
            set { SetProperty(ref _SNo, value); }
        }

        public string FirstPattern
        {
            get { return _FirstPattern; }
            set { SetProperty(ref _FirstPattern, value); }
        }

        public string SecondPattern
        {
            get { return _SecondPattern; }
            set { SetProperty(ref _SecondPattern, value); }
        }

        public string GetBetweenString
        {
            get { return _GetBetweenString; }
            set { SetProperty(ref _GetBetweenString, value); }
        }

        public List<string> PatternType = new List<string>()
        {
            PattenTypes.Regex.ToString(),
            PattenTypes.GetBetween.ToString(),
            PattenTypes.HtmlAgility.ToString()
        };

        public ObservableCollection<MatchCollection> RegexResult
        {
            get { return _RegexResult; }
            set { SetProperty(ref _RegexResult, value); }
        }

        public ObservableCollection<string> InnerHtml
        {
            get { return _InnerHtml; }
            set { SetProperty(ref _InnerHtml, value); }
        }



    }
}
