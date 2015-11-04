namespace RecipeBook
{
  partial class ReduceRecipeDialog
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
      this.okCancelButtons1 = new RecipeBook.OKCancelButtons();
      this.gridItems = new DevExpress.XtraGrid.GridControl();
      this.bsIngredients = new System.Windows.Forms.BindingSource(this.components);
      this.gridViewItems = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colSelectedItem = new DevExpress.XtraGrid.Columns.GridColumn();
      this.cboItems = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.colPostfix = new DevExpress.XtraGrid.Columns.GridColumn();
      this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
      this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
      this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
      this.layoutControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bsIngredients)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cboItems)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
      this.SuspendLayout();
      // 
      // layoutControl1
      // 
      this.layoutControl1.Controls.Add(this.okCancelButtons1);
      this.layoutControl1.Controls.Add(this.gridItems);
      this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.layoutControl1.Location = new System.Drawing.Point(0, 0);
      this.layoutControl1.Name = "layoutControl1";
      this.layoutControl1.Root = this.layoutControlGroup1;
      this.layoutControl1.Size = new System.Drawing.Size(585, 261);
      this.layoutControl1.TabIndex = 0;
      this.layoutControl1.Text = "layoutControl1";
      // 
      // okCancelButtons1
      // 
      this.okCancelButtons1.CancelText = "Cancel";
      this.okCancelButtons1.Location = new System.Drawing.Point(12, 223);
      this.okCancelButtons1.MaximumSize = new System.Drawing.Size(0, 26);
      this.okCancelButtons1.MinimumSize = new System.Drawing.Size(170, 26);
      this.okCancelButtons1.Name = "okCancelButtons1";
      this.okCancelButtons1.OKText = "OK";
      this.okCancelButtons1.Size = new System.Drawing.Size(561, 26);
      this.okCancelButtons1.TabIndex = 5;
      // 
      // gridItems
      // 
      this.gridItems.DataSource = this.bsIngredients;
      this.gridItems.Location = new System.Drawing.Point(12, 28);
      this.gridItems.MainView = this.gridViewItems;
      this.gridItems.Name = "gridItems";
      this.gridItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboItems});
      this.gridItems.Size = new System.Drawing.Size(561, 191);
      this.gridItems.TabIndex = 4;
      this.gridItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewItems});
      // 
      // bsIngredients
      // 
      this.bsIngredients.DataSource = typeof(RecipeBook.ReduceRecipeItemViewModel);
      // 
      // gridViewItems
      // 
      this.gridViewItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelectedItem,
            this.colPostfix});
      this.gridViewItems.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
      this.gridViewItems.GridControl = this.gridItems;
      this.gridViewItems.Name = "gridViewItems";
      this.gridViewItems.OptionsDetail.EnableMasterViewMode = false;
      this.gridViewItems.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gridViewItems.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
      this.gridViewItems.OptionsView.ShowColumnHeaders = false;
      this.gridViewItems.OptionsView.ShowGroupPanel = false;
      this.gridViewItems.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
      this.gridViewItems.OptionsView.ShowIndicator = false;
      this.gridViewItems.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
      // 
      // colSelectedItem
      // 
      this.colSelectedItem.AppearanceCell.Options.UseTextOptions = true;
      this.colSelectedItem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
      this.colSelectedItem.ColumnEdit = this.cboItems;
      this.colSelectedItem.FieldName = "SelectedItem";
      this.colSelectedItem.Name = "colSelectedItem";
      this.colSelectedItem.Visible = true;
      this.colSelectedItem.VisibleIndex = 0;
      // 
      // cboItems
      // 
      this.cboItems.AutoHeight = false;
      this.cboItems.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cboItems.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Display", "Display", 44, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending)});
      this.cboItems.DisplayMember = "Display";
      this.cboItems.Name = "cboItems";
      this.cboItems.NullText = "[Select a measurement]";
      this.cboItems.ShowHeader = false;
      this.cboItems.ValueMember = "Value";
      // 
      // colPostfix
      // 
      this.colPostfix.AppearanceCell.Options.UseTextOptions = true;
      this.colPostfix.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
      this.colPostfix.FieldName = "Postfix";
      this.colPostfix.Name = "colPostfix";
      this.colPostfix.OptionsColumn.AllowEdit = false;
      this.colPostfix.OptionsColumn.ReadOnly = true;
      this.colPostfix.Visible = true;
      this.colPostfix.VisibleIndex = 1;
      // 
      // layoutControlGroup1
      // 
      this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
      this.layoutControlGroup1.GroupBordersVisible = false;
      this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
      this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
      this.layoutControlGroup1.Name = "layoutControlGroup1";
      this.layoutControlGroup1.Size = new System.Drawing.Size(585, 261);
      this.layoutControlGroup1.TextVisible = false;
      // 
      // layoutControlItem1
      // 
      this.layoutControlItem1.Control = this.gridItems;
      this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
      this.layoutControlItem1.Name = "layoutControlItem1";
      this.layoutControlItem1.Size = new System.Drawing.Size(565, 211);
      this.layoutControlItem1.Text = "Select the measurement you want for each ingredient:";
      this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
      this.layoutControlItem1.TextSize = new System.Drawing.Size(262, 13);
      // 
      // layoutControlItem2
      // 
      this.layoutControlItem2.Control = this.okCancelButtons1;
      this.layoutControlItem2.Location = new System.Drawing.Point(0, 211);
      this.layoutControlItem2.Name = "layoutControlItem2";
      this.layoutControlItem2.Size = new System.Drawing.Size(565, 30);
      this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
      this.layoutControlItem2.TextVisible = false;
      // 
      // ReduceRecipeDialog
      // 
      this.AcceptButton = this.okCancelButtons1.OK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.okCancelButtons1.Cancel;
      this.ClientSize = new System.Drawing.Size(585, 261);
      this.Controls.Add(this.layoutControl1);
      this.Name = "ReduceRecipeDialog";
      this.Text = "ReduceRecipeDialog";
      ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
      this.layoutControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bsIngredients)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cboItems)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraLayout.LayoutControl layoutControl1;
    private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
    private OKCancelButtons okCancelButtons1;
    private DevExpress.XtraGrid.GridControl gridItems;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewItems;
    private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    private System.Windows.Forms.BindingSource bsIngredients;
    private DevExpress.XtraGrid.Columns.GridColumn colSelectedItem;
    private DevExpress.XtraGrid.Columns.GridColumn colPostfix;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboItems;
  }
}