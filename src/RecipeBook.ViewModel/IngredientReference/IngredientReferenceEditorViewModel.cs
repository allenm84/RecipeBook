using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public class IngredientReferenceEditorViewModel : BaseViewModel
  {
    private readonly BindingList<ValueDisplayItem> mIngredients;
    private readonly IngredientReferenceViewModel mReference;

    internal IngredientReferenceEditorViewModel(BindingList<ValueDisplayItem> ingredients, IngredientReferenceViewModel reference)
    {
      mIngredients = ingredients;
      mReference = reference;

      IngredientID = reference.IngredientID;
      Amount = reference.Amount.Value;
      Measurement = reference.Amount.Measurement;

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
