using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraLayout;

namespace RecipeBook
{
  public partial class MainForm : BaseForm
  {
    private SaveFileViewModel saveFile;
    private ViewModelStackHandler handler;

    public MainForm()
    {
      InitializeComponent();

      string filepath = Path.Combine(Application.StartupPath, "recipes.xml");
      saveFile = new SaveFileViewModel(new DataContractService(filepath));

      InitializeLayout();
      handler = new ViewModelStackHandler(this);
    }

    private void InitializeLayout()
    {
      layoutControl1.BeginUpdate();
      try
      {
        var tabbedGroup = layoutControlGroup1.AddTabbedGroup();
        tabbedGroup.Name = "TabbedGroup";

        var group1 = tabbedGroup.AddTabPage();
        group1.Name = "LayoutControlGroup1";
        group1.Text = "Ingredients";

        var gridIngredients = new EditableListGridControl<IngredientViewModel>(saveFile.Ingredients);
        gridIngredients.GridView.Columns["Name"].SortOrder = ColumnSortOrder.Ascending;

        var item1 = group1.AddItem();
        item1.Name = "LayoutControlItem1";
        item1.Control = gridIngredients;
        item1.TextVisible = false;

        var group2 = tabbedGroup.AddTabPage();
        group2.Name = "LayoutControlGroup2";
        group2.Text = "Recipes";

        var gridRecipes = new EditableListGridControl<RecipeViewModel>(saveFile.Recipes);
        gridRecipes.GridView.Columns["Name"].SortOrder = ColumnSortOrder.Ascending;

        var item2 = group2.AddItem();
        item2.Name = "LayoutControlItem2";
        item2.Control = gridRecipes;
        item2.TextVisible = false;

        tabbedGroup.SelectedTabPage = group1;
      }
      finally
      {
        layoutControl1.EndUpdate();
      }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      base.OnFormClosing(e);
      if (!e.Cancel)
      {
        saveFile.SaveCommand.Execute(this);
      }
    }
  }
}
