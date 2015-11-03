using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public class IngredientListViewModel : BaseLookUpListViewModel<IngredientViewModel>
  {
    protected override IngredientViewModel CreateNew()
    {
      return new IngredientViewModel(ID.Next, "<New Ingredient>");
    }
  }
}
