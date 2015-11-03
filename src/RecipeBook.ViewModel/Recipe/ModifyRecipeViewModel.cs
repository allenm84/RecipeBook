using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public sealed class ModifyRecipeViewModel : BaseViewModel
  {
    private RecipeEditorViewModel mRecipe;
    private IngredientReferenceViewModel mSelectedIngredient;

    internal ModifyRecipeViewModel(RecipeEditorViewModel recipe)
    {
      mRecipe = recipe;
      Name = recipe.Name + " (Modified)";

      ByIngredient = true;
      SelectedIngredient = null;
      NewIngredientAmount = 0;

      SelectedRecipeAmountDisplay = string.Format("Instead of {0}", Extensions.GetDisplay(recipe.Amount, recipe.Measurement));
      NewRecipeAmount = 0;

      Commit();
    }

    public string Name
    {
      get { return GetField<string>(); }
      set { SetField(value); }
    }

    public bool ByIngredient
    {
      get { return GetField<bool>(); }
      set { SetField(value); }
    }

    public ICollection<IngredientReferenceViewModel> Ingredients
    {
      get { return mRecipe.Items; }
    }

    public IngredientReferenceViewModel SelectedIngredient
    {
      get { return mSelectedIngredient; }
      set 
      { 
        mSelectedIngredient = value;
        FirePropertyChanged();
        UpdateIngredientDisplay();
      }
    }

    public decimal NewIngredientAmount
    {
      get { return GetField<decimal>(); }
      set 
      { 
        SetField(value);
        UpdateIngredientDisplay();
      }
    }

    public string NewIngredientPostFix
    {
      get { return GetField<string>(); }
      private set { SetField(value); }
    }

    public string SelectedRecipeAmountDisplay
    {
      get { return GetField<string>(); }
      private set { SetField(value); }
    }

    public decimal NewRecipeAmount
    {
      get { return GetField<decimal>(); }
      set 
      { 
        SetField(value);
        UpdateRecipeDisplay();
      }
    }

    public string NewRecipePostFix
    {
      get { return GetField<string>(); }
      private set { SetField(value); }
    }

    private void UpdateIngredientDisplay()
    {
      if (mSelectedIngredient == null)
      {
        NewIngredientPostFix = "[Unknown]";
      }
      else
      {
        bool singular = (NewIngredientAmount == 1);
        NewIngredientPostFix = mSelectedIngredient.Amount.Measurement.GetDisplay(singular);
      }
    }

    private void UpdateRecipeDisplay()
    {
      bool singular = (NewRecipeAmount == 1);
      NewRecipePostFix = mRecipe.Measurement.GetDisplay(singular);
    }

    protected override bool CanAccept()
    {
      if (ByIngredient)
      {
        return (mSelectedIngredient != null) && (NewIngredientAmount > 0);
      }
      else
      {
        return NewRecipeAmount > 0;
      }
    }
  }
}
