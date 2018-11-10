
using BaseLibs.DataUtility;
using BaseLibs.EnumPack;
using BaseLibs.Logger;
using BaseUIUtility.ViewModel.GeneralViewModel;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BaseUIUtility.ViewModel.CustomControl
{


    public class FetchDataInputBoxModel : BindingObject
    {
        //[Obsolete("Found alternative solution")]

        public FetchDataInputBoxModel()
        {
            ExecutePatternCommands = new RelayCommand(ExecutePattern, (sender) => true);
        }

        #region declaring variables

        protected FetchDataInputBoxModel currentFetchDataInputBoxModel;
        private int _SNos = 1;
        private bool _IsValidates;
        private string _FirstPatterns = string.Empty;
        private string _SecondPatterns = string.Empty;
        private string _SelectedPatternTypes = PatternTypes.Regex.ToString();
        private string _GetBetweenStrings = string.Empty;
        private ObservableCollection<string> _RegexResult = new ObservableCollection<string>();
        private ObservableCollection<string> _InnerHtml = new ObservableCollection<string>();
        private ObservableCollection<string> _ListCurrentPatternResult = new ObservableCollection<string>();
        public ICommand ExecutePatternCommands { get; set; }


        #endregion

        #region defining variables
        public int SNos
        {
            get { return _SNos; }
            set { SetProperty(ref _SNos, value); }
        }

        public string FirstPatterns
        {
            get { return _FirstPatterns; }
            set { SetProperty(ref _FirstPatterns, value); }
        }
        public string SecondPatterns
        {
            get { return _SecondPatterns; }
            set { SetProperty(ref _SecondPatterns, value); }
        }

        public string SelectedPatternTypes
        {
            get { return _SelectedPatternTypes; }
            set { SetProperty(ref _SelectedPatternTypes, value); }
        }

        public bool IsValidates
        {
            get { return _IsValidates; }
            set { SetProperty(ref _IsValidates, value); }
        }

        public string GetBetweenStrings
        {
            get { return _GetBetweenStrings; }
            set { SetProperty(ref _GetBetweenStrings, value); }
        }

        public ObservableCollection<string> InnerHtmls
        {
            get { return _InnerHtml; }
            set { SetProperty(ref _InnerHtml, value); }
        }

        public ObservableCollection<string> RegexResults
        {
            get { return _RegexResult; }
            set { SetProperty(ref _RegexResult, value); }
        }

        //ListCurrentPatternResult
        public ObservableCollection<string> ListCurrentPatternResult
        {
            get { return _ListCurrentPatternResult; }
            set { SetProperty(ref _ListCurrentPatternResult, value); }
        }

        #endregion
        public virtual void ExecutePattern(object sender)
        {
            try
            {
                string text = sender as string;

                if (SelectedPatternTypes.Equals(PatternTypes.GetBetween.ToString()))
                {
                    GetBetweenStrings = BaseLibs.DataUtility.Utils.GetBetween(text, FirstPatterns, SecondPatterns);
                    ListCurrentPatternResult.Clear();
                    ListCurrentPatternResult.Add(GetBetweenStrings);
                }
                    
                else if (SelectedPatternTypes.Equals(PatternTypes.HtmlAgility.ToString()))
                {
                    _InnerHtml = new ObservableCollection<string>(HtmlAgilityHelper.GetListHtmlByClassName(text, FirstPatterns));
                    ListCurrentPatternResult = _InnerHtml;
                }
                else if (SelectedPatternTypes.Equals(PatternTypes.Regex.ToString()))
                {
                    _RegexResult = new ObservableCollection<string>();
                    List<int> listGroup = new List<int>();
                    int tempGroup = 0;
                    listGroup = SecondPatterns.Trim().Split(',').Where(x => int.TryParse(x.Trim(), out tempGroup))
                        .Select(x => int.Parse(x.Trim())).ToList();
                    MatchCollection matchCollection = Regex.Matches(text, FirstPatterns,RegexOptions.Multiline);

                    foreach (Match data in matchCollection)
                    {
                        if (listGroup.Count == 0)
                            _RegexResult.Add($"Pattern(0)=>  {data.Groups[0].ToString()}");
                        else
                        {
                            for(int i=0;i< listGroup.Count;i++)
                                if (data.Groups.Count > i)
                                    _RegexResult.Add($"Pattern({i})=>  {data.Groups[i].ToString()}");
                        }
                    }
                    ListCurrentPatternResult = _RegexResult;
                }
            }
            catch (Exception ex)
            {
                ex.ErrorLog();
            }
        }


    }
}
