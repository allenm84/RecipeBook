using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public class RecipeListViewModel : BaseLookUpListViewModel<RecipeViewModel>
  {
    private readonly IngredientListViewModel mIngredientList;

    internal RecipeListViewModel(IngredientListViewModel ingredientList)
    {
      mIngredientList = ingredientList;
    }

    internal IngredientListViewModel IngredientList
    {
      get { return mIngredientList; }
    }

    protected override RecipeViewModel CreateNew()
    {
      return new RecipeViewModel(this, ID.Next, "<New Recipe>");
    }
  }
}
