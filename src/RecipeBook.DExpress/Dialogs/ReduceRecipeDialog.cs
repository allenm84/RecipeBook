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

namespace RecipeBook
{
  public partial class ReduceRecipeDialog : BaseForm
  {
    private ReduceRecipeViewModel mViewModel;

    public ReduceRecipeDialog(ReduceRecipeViewModel viewModel)
    {
      mViewModel = viewModel;
      InitializeComponent();
      bsIngredients.DataSource = mViewModel.Items;
    }
  }
}