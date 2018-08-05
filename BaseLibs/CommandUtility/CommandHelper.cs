using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BaseLibs.CommandUtility
{
   
    public class CommandHelper : ICommand
    {
        // Specify the keys and mouse actions that invoke the command. 
        public Key GestureKey { get; set; }
        public ModifierKeys GestureModifier { get; set; }
       // public MouseAction MouseGesture { get; set; }

        Action<object> _executeDelegate;

        public event EventHandler CanExecuteChanged;

        public CommandHelper(Action<object> executeDelegate)
        {
            _executeDelegate = executeDelegate;
        }

        public void Execute(object parameter)
        {
            _executeDelegate(parameter);
        }

        public bool CanExecute(object parameter) { return true; }
      //  public event EventHandler CanExecuteChanged;
    }
}
