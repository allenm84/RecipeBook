using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace RecipeBook
{
  public class MessageBoxConfirm : IConfirmCommand
  {
    private IWin32Window mOwner;
    private string mMessage;

    public MessageBoxConfirm(IWin32Window owner, string message)
    {
      mOwner = owner;
      mMessage = message;
    }

    bool IConfirmCommand.Confirm()
    {
      return MessageHelper.Confirm(mOwner, mMessage);
    }
  }
}
