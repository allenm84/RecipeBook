using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils.Win;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace RecipeBook
{
  public static class DevExpressExtensions
  {
    public static string Get<TSource, TType>(this Expression<Func<TSource, TType>> propertyLambda)
    {
      return GetPropertyInfo(propertyLambda).Name;
    }

    public static PropertyInfo GetPropertyInfo<TSource, TType>(this Expression<Func<TSource, TType>> propertyLambda)
    {
      if (propertyLambda == null)
        throw new ArgumentNullException("propertyLambda");

      var body = propertyLambda.Body;

      // make sure that we're actually accessing a property
      var member = body as MemberExpression;
      if (member == null)
        throw new ArgumentException(string.Format("Expression '{0}' refers to a method, not a property.",
          propertyLambda.ToString()));

      // and that its actually a property
      var propInfo = member.Member as PropertyInfo;
      if (propInfo == null)
        throw new ArgumentException(string.Format("Expression '{0}' refers to a field, not a property.",
          propertyLambda.ToString()));

      return propInfo;
    }

    public static Binding BindEnabled<TSource>(this Control control, TSource value, Expression<Func<TSource, bool>> propertyLambda)
    {
      return control.DataBindings.Add("Enabled", value, propertyLambda.Get(), false, DataSourceUpdateMode.OnPropertyChanged);
    }

    public static Binding BindEditValue(this LookUpEdit lookUp, object value, string property)
    {
      return lookUp.DataBindings.Add("EditValue", value, property, false, DataSourceUpdateMode.OnPropertyChanged);
    }

    public static Binding BindEditValue<TSource, TValue>(this LookUpEdit lookUp, TSource value, Expression<Func<TSource, TValue>> propertyLambda)
    {
      return lookUp.DataBindings.Add("EditValue", value, propertyLambda.Get(), false, DataSourceUpdateMode.OnPropertyChanged);
    }

    public static Binding BindEditValue<TSource, TValue>(this SearchLookUpEdit lookUp, TSource value, Expression<Func<TSource, TValue>> propertyLambda)
    {
      return lookUp.DataBindings.Add("EditValue", value, propertyLambda.Get(), false, DataSourceUpdateMode.OnPropertyChanged);
    }

    public static Binding BindChecked<TSource>(this CheckEdit check, TSource value, Expression<Func<TSource, bool>> propertyLambda)
    {
      return check.DataBindings.Add("Checked", value, propertyLambda.Get(), false, DataSourceUpdateMode.OnPropertyChanged);
    }

    public static Binding BindDateTime<TSource>(this DateEdit dateEdit, TSource value, Expression<Func<TSource, DateTime>> propertyLambda)
    {
      return dateEdit.DataBindings.Add("DateTime", value, propertyLambda.Get(), false, DataSourceUpdateMode.OnPropertyChanged);
    }

    public static Binding BindValue(this SpinEdit spin, object value, string property)
    {
      return spin.DataBindings.Add("Value", value, property, false, DataSourceUpdateMode.OnPropertyChanged);
    }

    public static Binding BindValue<TSource>(this SpinEdit spin, TSource value, Expression<Func<TSource, decimal>> propertyLambda)
    {
      return spin.DataBindings.Add("Value", value, propertyLambda.Get(), false, DataSourceUpdateMode.OnPropertyChanged);
    }

    public static Binding BindValue<TSource>(this SpinEdit spin, TSource value, Expression<Func<TSource, int>> propertyLambda)
    {
      return spin.DataBindings.Add("Value", value, propertyLambda.Get(), false, DataSourceUpdateMode.OnPropertyChanged);
    }

    public static Binding BindText<TSource>(this LabelControl label, TSource value, Expression<Func<TSource, string>> propertyLambda)
    {
      return label.DataBindings.Add("Text", value, propertyLambda.Get(), false, DataSourceUpdateMode.OnPropertyChanged);
    }

    public static Binding BindText<TSource>(this TextEdit text, TSource value, Expression<Func<TSource, string>> propertyLambda)
    {
      return text.DataBindings.Add("Text", value, propertyLambda.Get(), false, DataSourceUpdateMode.OnPropertyChanged);
    }

    public static GridColumn AddVisible<TSource, TType>(this GridColumnCollection columns, Expression<Func<TSource, TType>> propertyLambda)
    {
      return columns.AddVisible(Get(propertyLambda));
    }

    public static void ImmediateUpdate(this GridView view)
    {
      view.BeginUpdate();
      view.EndUpdate();
    }

    public static IEnumerable<int> GetRows(this GridView view)
    {
      for (int i = 0; i < view.DataRowCount; ++i)
      {
        yield return view.GetRowHandle(i);
      }
    }

    public static void RemoveSelectedValue(this LookUpEdit lookUp, IList source)
    {
      var value = lookUp.EditValue;
      var index = source.IndexOf(value);
      source.Remove(value);

      // normalize the index. If the value removed was at the end of the list, then
      // this will push up the index to be the new last value. Otherwise, the index
      // will remain the same.
      index = Math.Min(source.Count - 1, index);

      // if the index is valid, then use it as the currently selected value
      if (index > -1)
      {
        lookUp.EditValue = source[index];
      }
      else
      {
        lookUp.EditValue = null;
      }
    }

    public static CheckState ToCheckState(this bool value)
    {
      return value
        ? CheckState.Checked
        : CheckState.Unchecked;
    }

    public static void SetIsVisible(this BarItem item, bool visible)
    {
      item.Visibility = visible
        ? BarItemVisibility.Always
        : BarItemVisibility.Never;
    }

    public static void SetIsVisible(this BaseLayoutItem item, bool visible)
    {
      item.Visibility = visible
        ? LayoutVisibility.Always
        : LayoutVisibility.Never;
    }

    public static bool GetIsVisible(this BaseLayoutItem item)
    {
      return item.Visible;
    }

    public static string GetFilterText(this SearchLookUpEdit search)
    {
      return search.Properties.GetFilterText();
    }

    public static string GetFilterText(this RepositoryItemSearchLookUpEdit search)
    {
      return search.View.FindFilterText;
    }

    public static void ClearRows(this GridView gridView)
    {
      gridView.BeginUpdate();
      gridView.SelectAll();
      gridView.DeleteSelectedRows();
      gridView.EndUpdate();
    }

    public static void SetEnabled(this Bar bar, bool enabled)
    {
      ((IDockableObject)bar).BarControl.Enabled = enabled;
    }

    public static void SetMinMax(this SpinEdit edit)
    {
      edit.Properties.MinValue = decimal.MinValue + 1;
      edit.Properties.MaxValue = decimal.MaxValue - 1;
    }

    public static void FillWith<TItem, TDisplay, TValue>(this LookUpEdit lookUp, 
      IEnumerable<TItem> items,
      Expression<Func<TItem, TDisplay>> displayMember,
      Expression<Func<TItem, TValue>> valueMember)
    {
      lookUp.Properties.FillWith(items, displayMember, valueMember);
    }

    public static void FillWith<TItem, TDisplay, TValue>(this RepositoryItemLookUpEdit lookUp,
      IEnumerable<TItem> items,
      Expression<Func<TItem, TDisplay>> displayMember,
      Expression<Func<TItem, TValue>> valueMember)
    {
      lookUp.DataSource = items.ToArray();
      lookUp.DisplayMember = displayMember.Get();
      lookUp.ValueMember = valueMember.Get();
      lookUp.ShowHeader = false;
      lookUp.Columns.Add(new LookUpColumnInfo(lookUp.DisplayMember)
      {
        Visible = true,
        SortOrder = ColumnSortOrder.Ascending,
      });
    }

    public static void FillWithEnum<T>(this LookUpEdit lookUp, Func<T, string> getText = null, bool sortByValue = false)
    {
      lookUp.Properties.FillWithEnum(getText, sortByValue);
    }

    public static void FillWithEnum<T>(this RepositoryItemLookUpEdit lookUp, Func<T, string> getText = null, bool sortByValue = false)
    {
      if (getText == null)
      {
        getText = (x) => x.ToString();
      }

      var values = Enum.GetValues(typeof(T)).Cast<T>();
      lookUp.DataSource = values
        .Select(v => new { Value = v, Display = getText(v) })
        .ToArray();
      lookUp.DisplayMember = "Display";
      lookUp.ValueMember = "Value";
      lookUp.ShowHeader = false;

      lookUp.Columns.Clear();
      lookUp.Columns.Add(new LookUpColumnInfo("Display")
      {
        Visible = true,
        SortOrder = sortByValue
          ? ColumnSortOrder.None
          : ColumnSortOrder.Ascending,
      });

      if (sortByValue)
      {
        lookUp.Columns.Add(new LookUpColumnInfo("Value")
        {
          Visible = false,
          SortOrder = ColumnSortOrder.Ascending,
        });
      }
    }
  }
}
