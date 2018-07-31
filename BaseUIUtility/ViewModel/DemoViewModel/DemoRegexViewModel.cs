using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BaseUIUtility.ViewModel.DemoViewModel
{
    class DemoRegexViewModel
    {
    }
    class RegexSubModuleBind : INotifyPropertyChanged
    {
        List<string> _listRegex = new List<string>();
        Brush _FillColor;
        // ObservationCollection<RegexCodeBind> regexCodeBind = new ObservationCollection<RegexCodeBind>();

        RegexCodeBind regexCodeBind = new RegexCodeBind();

        public List<string> listRegex
        {
            get
            {
                return _listRegex;
            }
            set
            {
                if (value != _listRegex)
                {
                    _listRegex = value;

                }
            }
        }

        public Brush FillColor
        {
            get { return _FillColor; }
            set
            {

                if (_FillColor != value)
                {
                    _FillColor = value;
                    FirePropertyChanged("FillColor");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void FirePropertyChanged(string str)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(str));
        }
    }


    public class RegexCodeBind
    {
        private int SNo;
        private bool IsRegexEnabled;
        private string RegexExpression;
        private List<Color> ListColor;

        public event PropertyChangedEventHandler PropertyChanged;
        public void FirePropertyChanged(string str)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(str));
        }

    }
}
