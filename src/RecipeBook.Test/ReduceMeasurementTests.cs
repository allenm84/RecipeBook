using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecipeBook
{
  [TestClass]
  public class ReduceMeasurementTests
  {
    [TestMethod]
    public void TestReduce()
    {
      Console.WriteLine(Fraction.ToFraction(16.5m));
    }
  }
}
