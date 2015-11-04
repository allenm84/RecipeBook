using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public sealed class ReduceRecipeViewModel : BaseViewModel
  {
    private readonly RecipeEditorViewModel mRecipe;
    private readonly BindingList<ReduceRecipeItemViewModel> mItems;

    internal ReduceRecipeViewModel(RecipeEditorViewModel recipe)
    {
      mRecipe = recipe;
      mItems = new BindingList<ReduceRecipeItemViewModel>();
      foreach (var item in recipe.Items)
      {
        mItems.Add(new ReduceRecipeItemViewModel(item));
      }

      Commit();
    }

    public BindingList<ReduceRecipeItemViewModel> Items
    {
      get { return mItems; }
    }

    protected override bool CanAccept()
    {
      return mItems.Count > 0 && mItems.All(i => i.SelectedItem != null);
    }
  }
}
