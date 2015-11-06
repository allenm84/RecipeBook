using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace RecipeBook
{
  public static class MessageHelper
  {
    public static void Error(IWin32Window owner, string message)
    {
      Error(owner, message, "Error");
    }

    public static void Error(IWin32Window owner, string message, string caption)
    {
      XtraMessageBox.Show(owner, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void Inform(IWin32Window owner, string message)
    {
      Inform(owner, message, "Information");
    }

    public static void Inform(IWin32Window owner, string message, string caption)
    {
      XtraMessageBox.Show(owner, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static bool Confirm(IWin32Window owner, string message)
    {
      return Confirm(owner, message, "Confirm");
    }

    public static bool Confirm(IWin32Window owner, string message, string caption)
    {
      var result = XtraMessageBox.Show(owner, message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      return (result == DialogResult.Yes);
    }

    public static DialogResult ConfirmAdvanced(IWin32Window owner, string message)
    {
      return ConfirmAdvanced(owner, message, "Confirm");
    }

    public static DialogResult ConfirmAdvanced(IWin32Window owner, string message, string caption)
    {
      return XtraMessageBox.Show(owner, message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
    }
  }
}
