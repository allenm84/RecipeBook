using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace RecipeBook
{
  public partial class OKCancelButtons : XtraUserControl
  {
    private class ButtonProxy : IButtonControl
    {
      private SimpleButton button;

      public ButtonProxy(SimpleButton button)
      {
        this.button = button;
      }

      DialogResult IButtonControl.DialogResult
      {
        get { return button.DialogResult; }
        set { button.DialogResult = value; }
      }

      void IButtonControl.NotifyDefault(bool value)
      {
        button.NotifyDefault(value);
      }

      void IButtonControl.PerformClick()
      {
        button.PerformClick();
      }

      public static implicit operator SimpleButton(ButtonProxy proxy)
      {
        return proxy.button;
      }
    }

    private ButtonProxy okButton;
    private ButtonProxy cancelButton;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public IButtonControl OK { get { return okButton; } }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public IButtonControl Cancel { get { return cancelButton; } }

    [DefaultValue(true)]
    public bool CancelVisible
    {
      get { return layoutControlItem2.Visible; }
      set
      {
        layoutControlItem2.Visibility = value 
          ? LayoutVisibility.Always 
          : LayoutVisibility.Never;
      }
    }

    [DefaultValue(true)]
    public bool OKVisible
    {
      get { return layoutControlItem1.Visible; }
      set
      {
        layoutControlItem1.Visibility = value
          ? LayoutVisibility.Always
          : LayoutVisibility.Never;
      }
    }

    public event EventHandler OKClick
    {
      add { btnOK.Click += value; }
      remove { btnOK.Click -= value; }
    }

    public event EventHandler CancelClick
    {
      add { btnCancel.Click += value; }
      remove { btnCancel.Click -= value; }
    }

    [Browsable(false)]
    public string OKText
    {
      get { return btnOK.Text; }
      set { btnOK.Text = value; }
    }

    [Browsable(false)]
    public string CancelText
    {
      get { return btnCancel.Text; }
      set { btnCancel.Text = value; }
    }

    public OKCancelButtons()
    {
      InitializeComponent();
      okButton = new ButtonProxy(btnOK);
      cancelButton = new ButtonProxy(btnCancel);
      MaximumSize = new Size(0, Height);
      MinimumSize = Size;
    }

    public SimpleButton GetOK() { return btnOK; }
    public SimpleButton GetCancel() { return btnCancel; }
  }
}
