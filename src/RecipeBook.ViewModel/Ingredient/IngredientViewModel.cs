using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public class IngredientViewModel : BaseIDNameViewModel
  {
    internal IngredientViewModel(Ingredient ingredient)
      : this(ingredient.ID, ingredient.Name)
    {

    }

    internal IngredientViewModel(string id, string name)
    {
      ID = id;
      Name = name;

      Commit();
    }

    internal override BaseViewModel CreateEditor()
    {
      return new IngredientEditorViewModel(this);
    }
  }
}
