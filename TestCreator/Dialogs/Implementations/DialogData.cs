using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCreator.Dialogs.Implementations
{
    public class DialogData
    {
        public DialogData(Func<object> viewModelFunc, Func<object> viewFunc)
        {
            ViewModelFunc = viewModelFunc;
            ViewFunc = viewFunc;
        }

        public Func<object> ViewModelFunc { get; }

        public Func<object> ViewFunc { get; }
    }
}
