using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraLayout;

namespace RecipeBook
{
  public static class FormBuilder
  {
    public static BaseForm CreateOKCancel(string text, BaseAcceptableViewModel viewModel, params FormBuilderItem[] items)
    {
      var form = new BaseForm();
      form.Text = text;
      form.ClientSize = new Size(100, 80);

      var okCancel = new OKCancelButtons();
      okCancel.Bind(viewModel);

      form.AcceptButton = okCancel.OK;
      form.CancelButton = okCancel.Cancel;

      var lc = new LayoutControl();
      lc.Dock = DockStyle.Fill;
      lc.AllowCustomization = false;
      form.Controls.Add(lc);

      lc.BeginUpdate();
      try
      {
        int i = 0;
        foreach (var item in items)
        {
          var editor = item.Control;
          var label = item.Label;

          var editorItem = lc.Root.AddItem();
          editorItem.Control = editor;
          editorItem.Name = "editorItem" + i++;
          if (string.IsNullOrEmpty(label))
          {
            editorItem.TextVisible = false;
          }
          else
          {
            editorItem.Text = label;
            editorItem.TextLocation = Locations.Top;
          }
        }

        var okCancelItem = lc.Root.AddItem();
        okCancelItem.Control = okCancel;
        okCancelItem.Name = "OKCancel";
        okCancelItem.TextVisible = false;
      }
      finally
      {
        lc.EndUpdate();
      }

      var size = lc.GetPreferredSize(Size.Empty);
      form.ClientSize = lc.GetPreferredSize(size);
      form.MinimumSize = form.Size;
      return form;
    }

    public static BaseForm CreateSimpleOKCancel(string text, BaseAcceptableViewModel viewModel, Control editor, string label = null)
    {
      return CreateOKCancel(text, viewModel, new FormBuilderItem(editor, label));
    }
  }
}
