using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;

namespace RecipeBook
{
  public static class GridViewExtensions
  {
    public static void SetupGrid(this GridView gridView, Type type)
    {
      SetupGridView(gridView);
      SetupGridColumns(gridView, type);
    }

    private static void SetupGridView(GridView gridViewItems)
    {
      gridViewItems.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
      gridViewItems.OptionsBehavior.AllowDeleteRows = DefaultBoolean.False;
      gridViewItems.OptionsBehavior.AllowIncrementalSearch = true;
      gridViewItems.OptionsBehavior.AutoPopulateColumns = false;
      gridViewItems.OptionsBehavior.Editable = false;
      gridViewItems.OptionsBehavior.ReadOnly = true;
      gridViewItems.OptionsCustomization.AllowColumnMoving = false;
      gridViewItems.OptionsCustomization.AllowColumnResizing = false;
      gridViewItems.OptionsCustomization.AllowRowSizing = false;
      gridViewItems.OptionsDetail.EnableMasterViewMode = false;
      gridViewItems.OptionsSelection.EnableAppearanceFocusedCell = false;
      gridViewItems.OptionsSelection.EnableAppearanceFocusedRow = true;
      gridViewItems.OptionsSelection.EnableAppearanceHideSelection = true;
      gridViewItems.OptionsSelection.MultiSelect = true;
      gridViewItems.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
      gridViewItems.OptionsSelection.UseIndicatorForSelection = false;
      gridViewItems.OptionsView.ShowColumnHeaders = false;
      gridViewItems.OptionsView.ShowGroupPanel = false;
      gridViewItems.OptionsView.ShowIndicator = false;
    }

    private static void SetupGridColumns(GridView gridViewItems, Type type)
    {
      var properties = TypeDescriptor
        .GetProperties(type)
        .OfType<PropertyDescriptor>()
        .OrderBy(p => p.Name == "Name" ? 0 : 1);

      foreach (var property in properties)
      {
        if (property.Name == "ID" || property.Name == "Selected")
        {
          continue;
        }

        var propertyType = property.PropertyType;
        if (typeof(ICommand).IsAssignableFrom(propertyType))
        {
          continue;
        }

        var column = gridViewItems.Columns.AddVisible(property.Name);
        column.OptionsColumn.AllowEdit = false;
        column.OptionsColumn.ReadOnly = true;
      }
    }
  }
}
