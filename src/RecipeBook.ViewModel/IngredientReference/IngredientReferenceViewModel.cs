using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public class IngredientReferenceViewModel : BaseEditableViewModel
  {
    private readonly IngredientListViewModel mIngredients;
    private readonly Dictionary<string, ValueDisplayItem> mLookUp;

    internal IngredientReferenceViewModel(IngredientListViewModel ingredients, IngredientReference reference)
      : this(ingredients, reference.IngredientID, reference.Amount)
    {

    }

    internal IngredientReferenceViewModel(IngredientListViewModel ingredients, string ingredientID, Amount amount)
    {
      mIngredients = ingredients;
      mLookUp = new Dictionary<string, ValueDisplayItem>();

      IngredientID = ingredientID;
      Amount = amount;

      RefreshLookUp();
      Commit();
    }

    internal IngredientListViewModel IngredientList
    {
      get { return mIngredients; }
    }

    internal string IngredientID
    {
      get { return GetField<string>(); }
      set { SetField(value); }
    }

    internal Amount Amount
    {
      get { return GetField<Amount>(); }
      set { SetField(value); }
    }

    public string Display
    {
      get { return GetField<string>(); }
      private set { SetField(value); }
    }

    private void RefreshLookUp()
    {
      mLookUp.Clear();

      foreach (var ingredient in mIngredients.Items)
      {
        mLookUp[ingredient.ID] = new IngredientItem(ingredient);
      }

      RefreshDisplay();
    }

    private void RefreshDisplay()
    {
      ValueDisplayItem item;
      if (string.IsNullOrEmpty(IngredientID) || !mLookUp.TryGetValue(IngredientID, out item))
      {
        item = null;
      }

      string display = "[Nothing]";
      if (item != null)
      {
        display = string.Format("{0} of {1}",
          Amount.GetDisplay(),
          item.Display);
      }

      Display = display;
    }

    internal override BaseViewModel CreateEditor()
    {
      var list = new BindingList<ValueDisplayItem>();
      foreach (var item in mLookUp.Values)
      {
        list.Add(item);
      }

      var editor = new IngredientReferenceEditorViewModel(list, this);
      UpdateLookUpWhenComplete(editor);
      return editor;
    }

    private async void UpdateLookUpWhenComplete(IngredientReferenceEditorViewModel editor)
    {
      if (await editor.Completed)
      {
        var list = editor.Ingredients;

        var newIngredients = list.Cast<IngredientItem>().Where(i => mIngredients[i.ID] == null);
        foreach (var ingredient in newIngredients)
        {
          mIngredients.Items.Add(ingredient.Ingredient);
        }

        RefreshLookUp();
      }
    }
  }
}
