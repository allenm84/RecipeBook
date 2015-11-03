using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public static class Enums<T>
  {
    public static readonly T[] Values;
    static Enums()
    {
      Values = (T[])Enum.GetValues(typeof(T));
    }
  }
}
