using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public class MassWeightCategoryAttribute : MeasurementCategoryAttribute
  {
    public override string Name
    {
      get { return "Mass/Weight"; }
    }

    public double ToGrams { get; private set; }

    public MassWeightCategoryAttribute(double toGrams, string display)
      : this(toGrams, display, display + "s")
    {

    }

    public MassWeightCategoryAttribute(double toGrams, string singular, string plural)
      : base(singular, plural)
    {
      ToGrams = toGrams;
    }
  }
}
