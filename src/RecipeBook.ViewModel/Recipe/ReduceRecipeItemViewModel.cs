using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public class ReduceRecipeItemViewModel : BaseViewModel
  {
    static readonly Dictionary<Measurement, MeasurementCategoryAttribute> sMeasurementAttributes;
    static ReduceRecipeItemViewModel()
    {
      sMeasurementAttributes = Enums<Measurement>.Values.ToDictionary(
        k => k, 
        v => v.GetAttribute<MeasurementCategoryAttribute>());
    }

    private readonly IngredientReferenceViewModel mIngredient;
    private readonly BindingList<ValueDisplayItem> mMeasurements;
    private ValueDisplayItem mSelectedItem;

    public ReduceRecipeItemViewModel(IngredientReferenceViewModel ingredient)
    {
      mIngredient = ingredient;
      mMeasurements = new BindingList<ValueDisplayItem>();

      Postfix = string.Format("of {0}", ingredient.Name);

      var amount = ingredient.Amount;
      var attr = sMeasurementAttributes[amount.Measurement];
      if (attr is OfCategoryAttribute)
      {
        Enabled = false;
        mSelectedItem = new AmountItem(amount);
        mMeasurements.Add(mSelectedItem);
      }
      else
      {
        Enabled = true;

        var baseValue = amount.Value * attr.Factor;

        var type = attr.GetType();
        foreach (var kvp in sMeasurementAttributes)
        {
          var measurement = kvp.Key;
          if (kvp.Value.GetType() == type)
          {
            var item = new MeasurementFractionItem(baseValue, measurement, sMeasurementAttributes[measurement]);
            mMeasurements.Add(item);
            if (item.Measurement == amount.Measurement)
            {
              mSelectedItem = item;
            }
          }
        }
      }

      Commit();
    }

    internal IngredientReferenceViewModel Ingredient
    {
      get { return mIngredient; }
    }

    public bool Enabled
    {
      get { return GetField<bool>(); }
      private set { SetField(value); }
    }

    public BindingList<ValueDisplayItem> Measurements
    {
      get { return mMeasurements; }
    }

    public ValueDisplayItem SelectedItem
    {
      get { return mSelectedItem; }
      set
      {
        mSelectedItem = value;
        FirePropertyChanged();
      }
    }

    public string Postfix
    {
      get { return GetField<string>(); }
      private set { SetField(value); }
    }
  }
}
