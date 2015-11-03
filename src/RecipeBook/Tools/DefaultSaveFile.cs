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
      recipe.Directions = "1/4 cup warm water, add 1 tsp sugar & 1 1/4tsp yeast. Mix until yeast is mixed in thoroughly. Let rise for 10 minutes.\r\n\r\nPut 2 1/4 cups flour plus 1 tbsp flour in mixer. Pour garlic over. Once yeast has rose for time, add 3/4 cup water in yeast mix and mix. Then pour yeast mix in mixer. Add 1 tbsp olive oil and cap full of lemon juice. Put mixer on 2 and mix until done. Spray bowl and put dough in. Set timer for 45 minutes and let  rise.";

      var saveFile = new SaveFile();
      saveFile.Ingredients = ingredients.ToArray();
      saveFile.Recipes = new Recipe[] { recipe };
      return saveFile;
    }
  }
}
