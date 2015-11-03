using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  [DataContract(Name = "ExtensibleDataObject", Namespace = SaveFile.Namespace)]
  public abstract class ExtensibleDataObject : IExtensibleDataObject
  {
    ExtensionDataObject IExtensibleDataObject.ExtensionData { get; set; }
  }
}
