using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public class OfCategoryAttribute : MeasurementCategoryAttribute
  {
    public OfCategoryAttribute(string display)
      : base(display)
    {

    }

    public OfCategoryAttribute(string singular, string plural)
      : base(singular, plural)
    {

    }

    public override string Name
    {
      get { return "Other"; }
    }

    public override decimal Factor
    {
      get { return 1m; }
    }
  }
}
