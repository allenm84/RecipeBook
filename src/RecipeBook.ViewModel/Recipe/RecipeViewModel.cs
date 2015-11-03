using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public class RecipeViewModel : BaseIDNameViewModel
  {
    private readonly RecipeListViewModel mOwner;

    internal RecipeViewModel(RecipeListViewModel owner, Recipe recipe)
      : this(owner, recipe.ID, recipe.Name, recipe.Amount, recipe.Ingredients)
    {
    }

    internal RecipeViewModel(RecipeListViewModel owner, string id, string name)
      : this(owner, id, name, new Amount(), Arrays<IngredientReference>.Empty)
    {
    }

    internal RecipeViewModel(RecipeListViewModel owner, string id, string name, Amount amount, IEnumerable<IngredientReference> ingredients)
    {
      mOwner = owner;

      ID = id;
      Name = name;
      Amount = amount;
      Ingredients = ingredients.Select(i => new IngredientReferenceViewModel(owner.IngredientList, i)).ToArray();
      
      Commit();
    }

    internal RecipeListViewModel Owner
    {
      get { return mOwner; }
    }

    internal IngredientReferenceViewModel[] Ingredients { get; set; }

    internal Amount Amount
    {
      get { return GetField<Amount>(); }
      set 
      { 
        SetField(value);
        AmountDisplay = string.Format("Makes {0}", value.GetDisplay());
      }
    }

    public string AmountDisplay
    {
      get { return GetField<string>(); }
      private set { SetField(value); }
    }

    internal override BaseViewModel CreateEditor()
    {
      return new RecipeEditorViewModel(this);
    }
  }
}
