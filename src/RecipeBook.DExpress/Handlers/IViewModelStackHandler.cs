using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public interface IViewModelStackHandler
  {
    BaseForm Handle(BaseAcceptableViewModel viewModel);
  }
}
