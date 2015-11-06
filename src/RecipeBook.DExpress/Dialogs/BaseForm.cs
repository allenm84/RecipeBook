using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace RecipeBook
{
  public partial class BaseForm : XtraForm, IConfirmCancel
  {
    protected bool mCancelClose = false;

    public BaseForm()
    {
      InitializeComponent();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      if (mCancelClose)
      {
        e.Cancel = true;
        mCancelClose = false;
      }
      base.OnFormClosing(e);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == Keys.Enter && AcceptButton != null)
      {
        AcceptButton.PerformClick();
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    bool IConfirmCommand.Confirm()
    {
      var result = MessageHelper.Confirm(this, "Are you sure you want to cancel?");
      mCancelClose = !result;
      return result;
    }
  }

  public interface IConfirmCancel : IConfirmCommand
  {
  }
}