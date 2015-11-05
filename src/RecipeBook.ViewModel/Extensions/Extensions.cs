using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public static class Extensions
  {
    public static HashSet<T> ToHashSet<T>(this IEnumerable<T> values)
    {
      return new HashSet<T>(values);
    }

    public static string GetDisplay(this object value)
    {
      if (value == null)
      {
        return "[Nothing]";
      }
      else
      {
        return value.ToString();
      }
    }

    public static TAttribute GetAttribute<TAttribute>(this Enum value)
      where TAttribute : Attribute
    {
      var type = value.GetType();
      var info = type.GetMember(value.ToString()).FirstOrDefault();
      if (info == null)
        return null;
      return info.GetCustomAttribute<TAttribute>();
    }

    public static string GetDisplay(this Amount amount)
    {
      return GetDisplay(amount.Value, amount.Measurement);
    }

    public static string GetDisplay(decimal count, Measurement measurement)
    {
      return string.Format("{0:0.##} {1}",
        count,
        measurement.GetDisplay(count == 1));
    }

    public static string GetDisplay(this Measurement measure, bool singular)
    {
      var value = measure.GetAttribute<MeasurementCategoryAttribute>();
      return value.GetDisplay(singular);
    }

    public static bool IsInCategory(this Measurement a, Measurement b)
    {
      var attrA = a.GetAttribute<MeasurementCategoryAttribute>();
      var attrB = b.GetAttribute<MeasurementCategoryAttribute>();
      return attrA.GetType() == attrB.GetType();
    }
  }
}
