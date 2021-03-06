﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  [DataContract(Name = "IDName", Namespace = SaveFile.Namespace)]
  public abstract class IDName : ExtensibleDataObject
  {
    [DataMember(Order = 0)]
    public string ID { get; set; }
    [DataMember(Order = 1)]
    public string Name { get; set; }
  }
}
