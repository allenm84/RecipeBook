using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  [DataContract(Name = "Measurement", Namespace = SaveFile.Namespace)]
  public enum Measurement
  {
    [EnumMember, VolumeCategory(0.02083333333333333333333333333333, "tsp")]
    Teaspoon,
    [EnumMember, VolumeCategory(0.0625, "tbsp")]
    Tablespoon,
    [EnumMember, VolumeCategory(0.125, "fl oz", "fl ounces")]
    FluidOunce,
    [EnumMember, VolumeCategory(0.5, "gill")]
    Gill,
    [EnumMember, VolumeCategory(1, "cup")]
    Cup,
    [EnumMember, VolumeCategory(2, "pt")]
    Pint,
    [EnumMember, VolumeCategory(4, "qt")]
    Quart,
    [EnumMember, VolumeCategory(16, "gal")]
    Gallon,
    [EnumMember, VolumeCategory(0.00422675, "ml")]
    Milliliter,
    [EnumMember, VolumeCategory(4.22675, "l")]
    Liter,
    [EnumMember, VolumeCategory(0.422675284, "dl")]
    Deciliter,

    [EnumMember, MassWeightCategory(453.592, "lb")]
    Pound,
    [EnumMember, MassWeightCategory(28.3495, "oz", "ounces")]
    Ounce,
    [EnumMember, MassWeightCategory(0.000001, "mcg")]
    Microgram,
    [EnumMember, MassWeightCategory(0.001, "mg")]
    Milligram,
    [EnumMember, MassWeightCategory(1, "g")]
    Gram,
    [EnumMember, MassWeightCategory(1000, "kg")]
    Kilogram,

    [EnumMember, OfCategory("piece")]
    Piece,
    [EnumMember, OfCategory("slice")]
    Slice,
    [EnumMember, OfCategory("packet")]
    Packet,
    [EnumMember, OfCategory("unit")]
    Unit,
    [EnumMember, OfCategory("pinch", "pinches")]
    Pinch,
  }
}
