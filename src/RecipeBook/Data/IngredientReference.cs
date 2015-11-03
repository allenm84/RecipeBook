using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  [DataContract(Name = "IngredientReference", Namespace = SaveFile.Namespace)]
  public class IngredientReference : ExtensibleDataObject
  {
    [DataMember(Order = 0)]
    public string IngredientID { get; set; }
    [DataMember(Order = 1)]
    public Amount Amount { get; set; }
  }
}
