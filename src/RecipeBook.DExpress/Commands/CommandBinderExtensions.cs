using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using DevExpress.XtraBars;

namespace RecipeBook
{
  public static class CommandBinderExtensions
  {
    public static ControlCommandBinder[] Bind(this OKCancelButtons button, BaseAcceptableViewModel acceptable, IConfirmCommand cancel = null)
    {
      return new[]
      { 
        Bind(button.GetOK(), acceptable.Accept),
        Bind(button.GetCancel(), acceptable.Cancel, cancel),
      };
    }

    public static ControlCommandBinder Bind(this Control control, ICommand command, IConfirmCommand confirm = null)
    {
      return new ControlCommandBinder(control, command, confirm);
    }
  }
}
