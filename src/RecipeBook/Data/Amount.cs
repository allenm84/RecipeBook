using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  [Serializable]
  [DataContract(Name = "Amount", Namespace = SaveFile.Namespace)]
  public struct Amount
  {
    [DataMember(Order = 0)]
    public decimal Value { get; set; }
    [DataMember(Order = 1)]
    public Measurement Measurement { get; set; }
  }
}
