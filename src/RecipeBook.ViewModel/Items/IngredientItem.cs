using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public class IngredientItem : ValueDisplayItem
  {
    private readonly IngredientViewModel mIngredient;

    internal IngredientItem(IngredientViewModel ingredient)
    {
      mIngredient = ingredient;
    }

    internal IngredientViewModel Ingredient
    {
      get { return mIngredient; }
    }

    public override string ID
    {
      get { return mIngredient.ID; }
    }

    public override string Display
    {
      get { return mIngredient.Name; }
    }
  }
}
