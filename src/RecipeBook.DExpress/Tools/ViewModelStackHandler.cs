using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors;

namespace RecipeBook
{
  public class ViewModelStackHandler
  {
    private Stack<BaseForm> formStack = new Stack<BaseForm>();

    public ViewModelStackHandler(MainForm main)
    {
      formStack.Push(main);
      ViewModelStack.StackChanged += ViewModelStack_StackChanged;
    }

    private BaseForm CreateForm(BaseAcceptableViewModel viewModel)
    {
      if (viewModel is IngredientEditorViewModel)
      {
        var ingredient = (IngredientEditorViewModel)viewModel;
        var txtName = new TextEdit();
        txtName.BindText(ingredient, i => i.Name);
        return FormBuilder.CreateSimpleOKCancel("Edit Ingredient", ingredient, txtName, "Name:");
      }
      else if (viewModel is RecipeEditorViewModel)
      {
        var recipe = (RecipeEditorViewModel)viewModel;

        var txtName = new TextEdit();
        txtName.BindText(recipe, r => r.Name);

        var tbl = new TableLayoutPanel();
        tbl.ColumnCount = 3;
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        tbl.RowCount = 1;
        tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        tbl.Height = 28;
        tbl.MinimumSize = new Size(0, 28);

        var btnModify = new SimpleButton();
        btnModify.Margin = new Padding(3);
        btnModify.Text = "Modify Recipe";
        btnModify.Size = new Size(96, 22);
        btnModify.Bind(recipe.ModifyRecipeCommand);

        tbl.SuspendLayout();
        tbl.Controls.Add(btnModify, 1, 0);
        tbl.ResumeLayout();

        var ctrlAmount = new AmountControl(false);
        ctrlAmount.BindAmount(recipe, r => r.Amount);
        ctrlAmount.BindMeasurement(recipe, r => r.Measurement);

        var grid = new EditableListGridControl<IngredientReferenceViewModel>(recipe);
        return FormBuilder.CreateOKCancel("Edit Recipe", recipe,
          new FormBuilderItem(txtName, "Name:"),
          new FormBuilderItem(grid, "Items:"),
          new FormBuilderItem(tbl),
          new FormBuilderItem(ctrlAmount, "Makes:"));
      }
      else if (viewModel is IngredientReferenceEditorViewModel)
      {
        var ingredient = (IngredientReferenceEditorViewModel)viewModel;

        var cboIngredients = new SearchLookUpEdit();
        cboIngredients.Properties.View.Columns.AddVisible("Display").SortOrder = ColumnSortOrder.Ascending;
        cboIngredients.Properties.View.OptionsView.ShowColumnHeaders = false;
        cboIngredients.Properties.View.OptionsView.ShowIndicator = false;
        cboIngredients.Properties.DataSource = ingredient.Ingredients;
        cboIngredients.Properties.ValueMember = "ID";
        cboIngredients.Properties.DisplayMember = "Display";
        cboIngredients.Properties.ShowAddNewButton = true;
        cboIngredients.AddNewValue += (o, e) =>
        {
          // execute the add ingredient command
          ingredient.SearchText = cboIngredients.GetFilterText();
          ingredient.AddIngredientCommand.Execute(this);
          e.Cancel = true;
        };

        var binding = cboIngredients.BindEditValue(ingredient, (i => i.IngredientID));
        binding.DataSourceNullValue = null;

        var ctrlAmount = new AmountControl();
        ctrlAmount.BindAmount(ingredient, r => r.Amount);
        ctrlAmount.BindMeasurement(ingredient, r => r.Measurement);

        return FormBuilder.CreateOKCancel("Edit Recipe Ingredient", ingredient,
          new FormBuilderItem(cboIngredients, "Ingredient:"),
          new FormBuilderItem(ctrlAmount));
      }
      else if (viewModel is ModifyRecipeViewModel)
      {
        return new ModifyRecipeDialog((ModifyRecipeViewModel)viewModel);
      }

      return null;
    }

    private void ViewModelStack_StackChanged(object sender, EventArgs e)
    {
      using (var form = CreateForm(ViewModelStack.Current))
      {
        if (form != null)
        {
          var parent = formStack.Peek();
          formStack.Push(form);
          form.ShowDialog(parent);
          formStack.Pop();
        }
      }
    }
  }
}
