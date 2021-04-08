using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCreator.Dialogs.Abstractions
{
    interface IInteractionAware
    {
        Action FinishInteraction { get; set; }
    }
}
