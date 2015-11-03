using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeBook
{
  public class RecipeEditorViewModel : BaseEditableListViewModel<IngredientReferenceViewModel>
  {
    private readonly RecipeViewModel mRecipe;
    private readonly DelegateCommand mModifyRecipeCommand;

    internal RecipeEditorViewModel(RecipeViewModel recipe)
    {
      mRecipe = recipe;

      Name = recipe.Name;
      Amount = recipe.Amount.Value;
      Measurement = recipe.Amount.Measurement;
      Directions = recipe.Directions;

      foreach (var item in recipe.Ingredients)
      {
        mItems.Add(new IngredientReferenceViewModel(item.IngredientList, item.IngredientID, item.Amount));
      }

      mModifyRecipeCommand = new DelegateCommand(DoModifyRecipe);
      Commit();
    }

    public ICommand ModifyRecipeCommand
    {
      get { return mModifyRecipeCommand; }
    }

    public string Name
    {
      get { return GetField<string>(); }
      set { SetField(value); }
    }

    public decimal Amount
    {
      get { return GetField<decimal>(); }
      set { SetField(value); }
    }

    public Measurement Measurement
    {
      get { return GetField<Measurement>(); }
      set { SetField(value); }
    }

    public string Directions
    {
      get { return GetField<string>(); }
      set { SetField(value); }
    }

    private async void DoModifyRecipe()
    {
      var modify = new ModifyRecipeViewModel(this);
      ViewModelStack.Push(modify);
      if (await modify.Completed)
      {
        var recipe = CreateModifiedRecipe(modify);
        var viewModel = new RecipeViewModel(mRecipe.Owner, recipe);
        mRecipe.Owner.Items.Add(viewModel);
      }
    }

    private Recipe CreateModifiedRecipe(ModifyRecipeViewModel modify)
    {
      decimal factor = 1;
      if (modify.ByIngredient)
      {
        factor = modify.NewIngredientAmount / modify.SelectedIngredient.Amount.Value;
      }
      else
      {
        factor = modify.NewRecipeAmount / Amount;
      }

      var ingredients = new List<IngredientReference>();
      foreach (var item in mItems)
      {
        var amount = item.Amount;
        amount.Value *= factor;
        ingredients.Add(new IngredientReference
        {
          Amount = amount,
          IngredientID = item.IngredientID,
        });
      }

      var recipe = new Recipe();
      recipe.Amount = new Amount
      {
        Measurement = Measurement,
        Value = Amount * factor,
      };
      recipe.ID = ID.Next;
      recipe.Ingredients = ingredients.ToArray();
      recipe.Name = modify.Name;
      return recipe;
    }

    protected override IngredientReferenceViewModel CreateNew()
    {
      return new IngredientReferenceViewModel(mRecipe.Owner.IngredientList, null, new Amount());
    }

    protected override bool CanAccept()
    {
      return !string.IsNullOrEmpty(Name) && Amount > 0;
    }

    protected override void InternalDoAccept()
    {
      base.InternalDoAccept();
      mRecipe.Name = Name;
      mRecipe.Amount = new Amount
      {
        Measurement = Measurement,
        Value = Amount,
      };
      mRecipe.Ingredients = mItems.ToArray();
    }
  }
}
