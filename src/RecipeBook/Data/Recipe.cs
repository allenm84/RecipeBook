using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  [DataContract(Name = "Recipe", Namespace = SaveFile.Namespace)]
  public class Recipe : IDName
  {
    [DataMember(Order = 0)]
    public Amount Amount { get; set; }
    [DataMember(Order = 1)]
    public IngredientReference[] Ingredients { get; set; }
    [DataMember(Order = 2)]
    public string Directions { get; set; }
  }
}
