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
using System.Linq.Expressions;
using DevExpress.XtraEditors.Controls;
using DevExpress.Data;

namespace RecipeBook
{
  public partial class AmountControl : XtraUserControl
  {
    public AmountControl(bool showLabels = true)
    {
      InitializeComponent();
      cboMeasurement.FillWithEnum<Measurement>();

      if (!showLabels)
      {
        labelControl1.Visible = false;
        labelControl2.Visible = false;
        Height -= 20;
      }

      MinimumSize = Size;
      MaximumSize = new Size(0, Height);
    }

    public Binding BindAmount<TSource>(TSource value, Expression<Func<TSource, decimal>> propertyLambda)
    {
      return numAmount.DataBindings.Add("Value", value, propertyLambda.Get(), false, DataSourceUpdateMode.OnPropertyChanged);
    }

    public Binding BindMeasurement<TSource>(TSource value, Expression<Func<TSource, Measurement>> propertyLambda)
    {
      return cboMeasurement.DataBindings.Add("EditValue", value, propertyLambda.Get(), false, DataSourceUpdateMode.OnPropertyChanged);
    }
  }
}
