using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCreator.Dialogs.Abstractions
{
    public interface IDialogManager
    {
        object ShowDialog(string key, object data);
    }
}
