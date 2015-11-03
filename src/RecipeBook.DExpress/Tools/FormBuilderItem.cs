using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeBook
{
  public class FormBuilderItem
  {
    public Control Control { get; set; }
    public string Label { get; set; }

    public FormBuilderItem()
      : this(null, null)
    {
    }

    public FormBuilderItem(Control control)
      : this(control, null)
    {
    }

    public FormBuilderItem(Control control, string label)
    {
      Control = control;
      Label = label;
    }
  }
}
