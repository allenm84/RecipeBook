using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Base;
using System.Windows.Input;

namespace RecipeBook
{
  public partial class EditableListGridControl<T> : XtraUserControl
    where T : BaseEditableViewModel
  {
    private readonly BaseEditableListViewModel<T> mListViewModel;

    public EditableListGridControl(BaseEditableListViewModel<T> listViewModel)
    {
      mListViewModel = listViewModel;
      InitializeComponent();
      MinimumSize = Size;

      gridViewItems.SetupGrid(typeof(T));
      gridItems.DataSource = listViewModel.Items;

      btnAdd.Bind(listViewModel.AddCommand);
      btnEdit.Bind(listViewModel.EditCommand);

      var remove = new MessageBoxConfirm(this, "Are you sure you want to remove the selected items?");
      btnRemove.Bind(listViewModel.RemoveCommand, remove);

      var clear = new MessageBoxConfirm(this, "Are you sure you want to remove all of the items?");
      btnClear.Bind(listViewModel.ClearCommand, clear);
    }

    public GridView GridView
    {
      get { return gridViewItems; }
    }

    private void gridViewItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      for (int r = 0; r < gridViewItems.DataRowCount; ++r)
      {
        var item = gridViewItems.GetRow(r) as T;
        item.Selected = gridViewItems.IsRowSelected(r);
      }
    }

    private void gridViewItems_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
    {
      var item = gridViewItems.GetRow(e.FocusedRowHandle) as T;
      mListViewModel.Current = item;
    }

    private void gridItems_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (e.Button.HasFlag(MouseButtons.Left))
      {
        var info = gridViewItems.CalcHitInfo(e.X, e.Y);
        if (info.InRow || info.InRowCell)
        {
          btnEdit.PerformClick();
        }
      }
    }

    private void gridViewItems_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Delete)
      {
        btnRemove.PerformClick();
      }
    }
  }
}
