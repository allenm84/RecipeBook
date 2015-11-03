using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  [DataContract(Name = "SaveFile", Namespace = SaveFile.Namespace)]
  public class SaveFile : ExtensibleDataObject
  {
    public const string Namespace = "http://www.mapa.com/apps/recipebook/v1";

    [DataMember(Order = 0)]
    public Ingredient[] Ingredients { get; set; }
    [DataMember(Order = 1)]
    public Recipe[] Recipes { get; set; }
  }
}
