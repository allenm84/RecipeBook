using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeBook
{
  public class IngredientReferenceEditorViewModel : BaseViewModel
  {
    private readonly BindingList<ValueDisplayItem> mIngredients;
    private readonly IngredientReferenceViewModel mReference;

    private readonly DelegateCommand mAddIngredientCommand;

    internal IngredientReferenceEditorViewModel(BindingList<ValueDisplayItem> ingredients, IngredientReferenceViewModel reference)
    {
      mIngredients = ingredients;
      mReference = reference;

      IngredientID = reference.IngredientID;
      Amount = reference.Amount.Value;
      Measurement = reference.Amount.Measurement;

      mAddIngredientCommand = new DelegateCommand(DoAddIngredient);
      Commit();
    }

    public BindingList<ValueDisplayItem> Ingredients
    {
      get { return mIngredients; }
    }

    public string IngredientID
    {
      get { return GetField<string>(); }
      set { SetField(value); }
    }

    public string SearchText
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

    public ICommand AddIngredientCommand
    {
      get { return mAddIngredientCommand; }
    }

    private async void DoAddIngredient()
    {
      var ingredient = new IngredientViewModel(ID.Next, SearchText ?? "<New Ingredient>");
      var editor = ingredient.CreateEditor();
      ViewModelStack.Push(editor);
      if (await editor.Completed)
      {
        mIngredients.Add(new IngredientItem(ingredient));
        IngredientID = ingredient.ID;
      }
    }

    protected override bool CanAccept()
    {
      return !string.IsNullOrEmpty(IngredientID) && Amount > 0;
    }

    protected override void InternalDoAccept()
    {
      base.InternalDoAccept();
      mReference.IngredientID = IngredientID;
      mReference.Amount = new Amount
      {
        Measurement = Measurement,
        Value = Amount,
      };
    }
  }
}
