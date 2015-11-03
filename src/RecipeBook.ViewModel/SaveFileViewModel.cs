using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeBook
{
  public sealed class SaveFileViewModel : BaseAcceptableViewModel
  {
    private readonly ISaveFileService mService;
    private readonly DelegateCommand mSaveCommand;

    public SaveFileViewModel(ISaveFileService service)
    {
      ViewModelStack.Initialize(this);

      mService = service;
      var data = mService.ReadSaveFile();

      Ingredients = new IngredientListViewModel();
      foreach (var ingredient in data.Ingredients)
      {
        Ingredients.Items.Add(new IngredientViewModel(ingredient));
      }

      Recipes = new RecipeListViewModel(Ingredients);
      foreach (var recipe in data.Recipes)
      {
        Recipes.Items.Add(new RecipeViewModel(Recipes, recipe));
      }

      mSaveCommand = new DelegateCommand(DoSave);
    }

    public ICommand SaveCommand
    {
      get { return mSaveCommand; }
    }

    public IngredientListViewModel Ingredients { get; private set; }
    public RecipeListViewModel Recipes { get; private set; }

    private void DoSave()
    {
      var data = new SaveFile();

      data.Ingredients = Ingredients.Items.Select(i => new Ingredient
      {
        ID = i.ID,
        Name = i.Name,
      }).ToArray();

      data.Recipes = Recipes.Items.Select(r => new Recipe
      {
        Amount = r.Amount,
        ID = r.ID,
        Ingredients = r.Ingredients.Select(i => new IngredientReference
        {
          Amount = i.Amount,
          IngredientID = i.IngredientID,
        }).ToArray(),
        Name = r.Name,
      }).ToArray();

      mService.WriteSaveFile(data);
    }
  }
}
