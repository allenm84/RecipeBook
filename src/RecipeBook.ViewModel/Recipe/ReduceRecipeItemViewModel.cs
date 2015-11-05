﻿using System;
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
    static readonly HashSet<Measurement> sCommonMeasurements;
    static ReduceRecipeItemViewModel()
    {
      sMeasurementAttributes = Enums<Measurement>.Values.ToDictionary(
        k => k, 
        v => v.GetAttribute<MeasurementCategoryAttribute>());

      sCommonMeasurements = new HashSet<Measurement>
      {
         Measurement.Cup,
         Measurement.Gram,
         Measurement.Ounce,
         Measurement.Tablespoon,
         Measurement.Teaspoon,
         Measurement.FluidOunce,
      };
    }

    private readonly IngredientReferenceViewModel mIngredient;
    private readonly BindingList<ValueDisplayItem> mMeasurements;
    private ValueDisplayItem mSelectedItem;

    public ReduceRecipeItemViewModel(IngredientReferenceViewModel ingredient)
    {
      mIngredient = ingredient;
      mMeasurements = new BindingList<ValueDisplayItem>();

      var amount = ingredient.Amount;
      var attr = sMeasurementAttributes[amount.Measurement];
      if (attr is OfCategoryAttribute)
      {
        Enabled = false;
        Postfix = ingredient.Name;
        mSelectedItem = new AmountItem(amount);
      }
      else
      {
        Enabled = true;
        Postfix = string.Format("of {0}", ingredient.Name);

        var baseValue = amount.Value * attr.Factor;

        var type = attr.GetType();
        foreach (var kvp in sMeasurementAttributes)
        {
          var measurement = kvp.Key;
          if (!sCommonMeasurements.Contains(measurement))
          {
            continue;
          }
          
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
