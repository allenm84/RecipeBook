using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public abstract class BaseEditableViewModel : BaseSelectableViewModel
  {
    internal abstract BaseViewModel CreateEditor();
  }
}
