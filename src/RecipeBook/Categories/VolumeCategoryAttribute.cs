using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public class VolumeCategoryAttribute : MeasurementCategoryAttribute
  {
    public override string Name
    {
      get { return "Volume"; }
    }

    public double ToCups { get; private set; }

    public VolumeCategoryAttribute(double toCups, string display)
      : this(toCups, display, display + "s")
    {
      ToCups = toCups;
    }

    public VolumeCategoryAttribute(double toCups, string singular, string plural)
      : base(singular, plural)
    {
      ToCups = toCups;
    }
  }
}
