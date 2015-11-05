using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  internal class AmountItem : ValueDisplayItem
  {
    private readonly Amount mAmount;
    private readonly string mDisplay;

    public AmountItem(Amount amount)
    {
      mAmount = amount;
      mDisplay = mAmount.GetDisplay();
    }

    public override object Value { get { return this; } }
    public override string Display { get { return mDisplay; } }
    internal Amount Amount { get { return mAmount; } }
  }
}
