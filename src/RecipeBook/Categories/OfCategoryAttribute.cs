using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public class OfCategoryAttribute : MeasurementCategoryAttribute
  {
    public override string Name
    {
      get { return "Other"; }
    }

    public OfCategoryAttribute(string display)
      : base(display)
    {

    }

    public OfCategoryAttribute(string singular, string plural)
      : base(singular, plural)
    {

    }
  }
}
