using BaseLibs.EnumPack;
using BaseLibs.Logger;
using BaseUIUtility.ViewModel.CustomControl;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseUniWeb.CustomControlFunctionality
{
   public class FetchDataInputBox: FetchDataInputBoxModel
    {
       
        public override void ExecutePattern(object sender)
        {
            try
            {
                base.ExecutePattern(sender);
                string text = sender as string;
                var demo = "";
                if (SelectedPatternTypes.Equals(PatternTypes.GetBetween.ToString()))
                    demo = BaseLibs.DataUtility.Utils.GetBetween(text, FirstPatterns, SecondPatterns);
            }
            catch (Exception ex)
            {
                ex.ErrorLog();
            }
        }

    }
}
