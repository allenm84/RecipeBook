using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
  public abstract class MeasurementCategoryAttribute : Attribute
  {
    private readonly string mSingularDisplay;
    private readonly string mPluralDisplay;

    public MeasurementCategoryAttribute(string display)
      : this(display, display + "s")
    {

    }

    public MeasurementCategoryAttribute(string singularDisplay, string pluralDisplay)
    {
      mSingularDisplay = singularDisplay;
      mPluralDisplay = pluralDisplay;
    }

    public abstract string Name { get; }

    public abstract decimal Factor { get; }

    public override string ToString()
    {
      return Name;
    }

    public string GetDisplay(bool singular)
    {
      return singular
        ? mSingularDisplay
        : mPluralDisplay;
    }
  }
}
