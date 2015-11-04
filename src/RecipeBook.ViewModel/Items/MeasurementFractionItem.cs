using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  internal class MeasurementFractionItem : ValueDisplayItem
  {
    private readonly string mDisplay;

    public MeasurementFractionItem(decimal baseValue, Measurement measurement, MeasurementCategoryAttribute measurementAttribute)
    {
      var toMeasurment = baseValue * (1m / measurementAttribute.Factor);
      var f = Fraction.ToFraction(toMeasurment);

      if (f.Denominator == 1)
      {
        mDisplay = string.Format("{0} {1}",
          f.Numerator,
          measurementAttribute.GetDisplay(f.Numerator == 1));
      }
      else
      {
        int w = 0;
        while (f.Numerator > f.Denominator)
        {
          ++w;
          f.Numerator -= f.Denominator;
        }

        if (w > 0)
        {
          mDisplay = string.Format("{0} & {1}/{2} {3}", w, f.Numerator, f.Denominator,
            measurementAttribute.GetDisplay(false));
        }
        else
        {
          mDisplay = string.Format("{0}/{1} {2}", f.Numerator, f.Denominator,
            measurementAttribute.GetDisplay(false));
        }
      }

      Amount = toMeasurment;
      Measurement = measurement;
    }

    public override object Value { get { return this; } }
    public override string Display { get { return mDisplay; } }

    public decimal Amount { get; private set; }
    public Measurement Measurement { get; private set; }
  }
}
