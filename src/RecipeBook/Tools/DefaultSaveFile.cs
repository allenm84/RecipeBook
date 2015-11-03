using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
  public static class DefaultSaveFile
  {
    public static SaveFile GetDefault()
    {
      var ingredients = new List<Ingredient>();
      var recipeItems = new List<IngredientReference>();

      Action<decimal, Measurement, string> addIngredient = (amount, measurement, name) =>
      {
        var ingredient = ingredients.Single(i => i.Name == name);
        recipeItems.Add(new IngredientReference
        {
          Amount = new Amount
          {
            Measurement = measurement,
            Value = amount,
          },
          IngredientID = ingredient.ID,
        });
      };

      ingredients.Add(new Ingredient { ID = ID.Next, Name = "Flour" });
      ingredients.Add(new Ingredient { ID = ID.Next, Name = "Sugar" });
      ingredients.Add(new Ingredient { ID = ID.Next, Name = "Water" });
      ingredients.Add(new Ingredient { ID = ID.Next, Name = "Yeast" });
      ingredients.Add(new Ingredient { ID = ID.Next, Name = "Garlic Powder" });
      ingredients.Add(new Ingredient { ID = ID.Next, Name = "Olive Oil" });
      ingredients.Add(new Ingredient { ID = ID.Next, Name = "Lemon Juice" });
      ingredients.Add(new Ingredient { ID = ID.Next, Name = "Honey" });

      addIngredient(2.25m, Measurement.Cup, "Flour");
      addIngredient(1, Measurement.Teaspoon, "Sugar");
      addIngredient(1, Measurement.Cup, "Water");
      addIngredient(1.25m, Measurement.Teaspoon, "Yeast");
      addIngredient(2, Measurement.Tablespoon, "Garlic Powder");
      addIngredient(1, Measurement.Tablespoon, "Olive Oil");
      addIngredient(0.5m, Measurement.Tablespoon, "Lemon Juice");
      addIngredient(1, Measurement.Tablespoon, "Honey");

      var recipe = new Recipe();
      recipe.Name = "Pizza Dough";
      recipe.ID = ID.Next;
      recipe.Amount = new Amount { Value = 8, Measurement = Measurement.Slice };
      recipe.Ingredients = recipeItems.ToArray();

      var saveFile = new SaveFile();
      saveFile.Ingredients = ingredients.ToArray();
      saveFile.Recipes = new Recipe[] { recipe };
      return saveFile;
    }
  }
}
