using BaseLibs.Logger;
using BaseUIUtility.ViewModel.CustomControl;
using BaseUIUtility.ViewModel.WebTabViewModel;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseUniWeb.ViewFunctionality.AllWebFunc
{
    public class FetchData : FetchDataViewModel
    {
        public FetchData CurrentFetchData { get; set; }
        public FetchData()
        {
            CurrentFetchData = this;
            #region assigning methods to commands
            IsCheckAllCommand = new RelayCommand(IsCheckAllExecute, (sender) => true);
            ExecutePatternCommand = new RelayCommand(ExecutePatternExecute, (sender) => true);
            SavePatternCommand = new RelayCommand(SavePatternExecute, (sender) => true);
            #endregion
        }

        #region declaring commands
        private void IsCheckAllExecute(object sender)
        {
            try
            {
                if (IsCheckAll)
                    FetchDataInputBoxModelCollection.OfType<FetchDataInputBoxModel>().ToList().ForEach(x => { x.IsValidates = true; });
                else
                    FetchDataInputBoxModelCollection.OfType<FetchDataInputBoxModel>().ToList().ForEach(x => { x.IsValidates = false; });
            }
            catch (Exception ex)
            {
                ex.ErrorLog();
            }
        }

        private void ExecutePatternExecute(object obj)
        {

        }

        private void SavePatternExecute(object obj)
        {

        }
        #endregion
    }
}
