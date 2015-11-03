using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public class IngredientEditorViewModel : BaseViewModel
  {
    private readonly IngredientViewModel mIngredient;

    internal IngredientEditorViewModel(IngredientViewModel ingredient)
    {
      mIngredient = ingredient;

      Name = ingredient.Name;
      Commit();
    }

    public string Name
    {
      get { return GetField<string>(); }
      set { SetField(value); }
    }

    protected override bool CanAccept()
    {
      return !string.IsNullOrEmpty(Name);
    }

    protected override void InternalDoAccept()
    {
      base.InternalDoAccept();
      mIngredient.Name = Name;
    }
  }
}
