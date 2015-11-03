using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecipeBook
{
  [TestClass]
  public class RecipeViewModelTests
  {
    [TestMethod]
    public void TestAddCancelRecipe()
    {
      var saveFileViewModel = new SaveFileViewModel(new TestSaveFileService());
      Assert.AreEqual(ViewModelStack.Current, saveFileViewModel);
      int count = saveFileViewModel.Recipes.Items.Count;

      saveFileViewModel.Recipes.AddCommand.Execute(this);
      var recipeEditor = ViewModelStack.Current as RecipeEditorViewModel;
      Assert.IsNotNull(recipeEditor);

      recipeEditor.Cancel.Execute(this);
      Assert.AreEqual(count, saveFileViewModel.Recipes.Items.Count);
      Assert.AreEqual(ViewModelStack.Current, saveFileViewModel);
    }

    [TestMethod]
    public void TestAddAcceptRecipe()
    {
      var saveFileViewModel = new SaveFileViewModel(new TestSaveFileService());
      Assert.AreEqual(ViewModelStack.Current, saveFileViewModel);
      int count = saveFileViewModel.Recipes.Items.Count;

      saveFileViewModel.Recipes.AddCommand.Execute(this);
      var recipeEditor = ViewModelStack.Current as RecipeEditorViewModel;
      Assert.IsNotNull(recipeEditor);

      recipeEditor.Accept.Execute(this);
      Assert.AreEqual(count + 1, saveFileViewModel.Recipes.Items.Count);
      Assert.AreEqual(ViewModelStack.Current, saveFileViewModel);
    }

    [TestMethod]
    public void TestRecipeListViewModel()
    {
      var saveFileViewModel = new SaveFileViewModel(new TestSaveFileService());
      var recipes = saveFileViewModel.Recipes;
      Assert.AreEqual(ViewModelStack.Current, saveFileViewModel);
      Assert.IsTrue(recipes.Items.Count == 1);
      var recipe = recipes.Items.First();
      recipes.Current = recipe;
      recipe.Selected = true;
      Assert.IsTrue(recipes.EditCommand.CanExecute(this));
      Assert.IsTrue(recipes.RemoveCommand.CanExecute(this));
    }

    [TestMethod]
    public void TestRecipeIngredientDisplay()
    {
      var saveFileViewModel = new SaveFileViewModel(new TestSaveFileService());
      var recipes = saveFileViewModel.Recipes;
      var recipe = recipes.Items.First();
      recipes.Current = recipe;
      recipe.Selected = true;
      recipes.EditCommand.Execute(this);
      var recipeEditor = ViewModelStack.Current as RecipeEditorViewModel;
      Assert.IsNotNull(recipeEditor);
      Console.WriteLine(string.Join(Environment.NewLine, recipeEditor.Items.Select(i => i.Display)));
    }
  }
}
