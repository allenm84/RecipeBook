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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.Data;

namespace RecipeBook
{
  public partial class ReduceRecipeDialog : BaseForm
  {
    private ReduceRecipeViewModel mViewModel;

    public ReduceRecipeDialog(ReduceRecipeViewModel viewModel)
    {
      mViewModel = viewModel;
      InitializeComponent();
      MinimumSize = Size;
      bsIngredients.DataSource = mViewModel.Items;
      gridViewItems.CustomRowCellEdit += gridViewItems_CustomRowCellEdit;
      okCancelButtons1.Bind(viewModel, this);
    }

    private void gridViewItems_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
    {
      if (e.Column == colSelectedItem)
      {
        var item = gridViewItems.GetRow(e.RowHandle) as ReduceRecipeItemViewModel;
        var cboItems = new RepositoryItemLookUpEdit();
        cboItems.Columns.Add(new LookUpColumnInfo("Display") { SortOrder = ColumnSortOrder.Ascending });
        cboItems.ShowHeader = false;
        cboItems.DataSource = item.Measurements;
        cboItems.ValueMember = "Value";
        cboItems.DisplayMember = "Display";
        e.RepositoryItem = cboItems;
      }
    }
  }
}