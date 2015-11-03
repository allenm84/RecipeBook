using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors.Controls;
using DevExpress.Data;

namespace RecipeBook
{
  public partial class ModifyRecipeDialog : BaseForm
  {
    private ModifyRecipeViewModel mModify;

    public ModifyRecipeDialog(ModifyRecipeViewModel modify)
    {
      mModify = modify;
      InitializeComponent();

      txtName.BindText(mModify, m => m.Name);

      var lookUp = cboIngredients.Properties;
      lookUp.DataSource = modify.Ingredients;
      lookUp.DisplayMember = "Display";
      lookUp.ShowHeader = false;
      lookUp.Columns.Add(new LookUpColumnInfo("Display") { Visible = true, SortOrder = ColumnSortOrder.Ascending });
      cboIngredients.BindEditValue(mModify, m => m.SelectedIngredient);
      numNewIngredientAmount.BindValue(mModify, m => m.NewIngredientAmount);
      lblNewIngredientPostfix.BindText(mModify, m => m.NewIngredientPostFix);

      lblSelectedRecipeAmount.BindText(mModify, m => m.SelectedRecipeAmountDisplay);
      numNewRecipeAmount.BindValue(mModify, m => m.NewRecipeAmount);
      lblNewRecipePostfix.BindText(mModify, m => m.NewRecipePostFix);

      okCancelButtons1.Bind(modify);
      UpdateSelection();
    }

    private void UpdateSelection()
    {
      mModify.ByIngredient = (tabbedControlGroup1.SelectedTabPage == lcgByIngredient);
    }

    private void tabbedControlGroup1_SelectedPageChanged(object sender, LayoutTabPageChangedEventArgs e)
    {
      UpdateSelection();
    }
  }
}