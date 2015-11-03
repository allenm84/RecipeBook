namespace RecipeBook
{
  partial class EditableListGridControl<T>
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.btnClear = new DevExpress.XtraEditors.SimpleButton();
      this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
      this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
      this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
      this.gridItems = new DevExpress.XtraGrid.GridControl();
      this.gridViewItems = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnClear
      // 
      this.btnClear.Location = new System.Drawing.Point(153, 87);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(76, 22);
      this.btnClear.TabIndex = 8;
      this.btnClear.Text = "Clear";
      // 
      // btnRemove
      // 
      this.btnRemove.Location = new System.Drawing.Point(153, 59);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new System.Drawing.Size(76, 22);
      this.btnRemove.TabIndex = 7;
      this.btnRemove.Text = "Remove";
      // 
      // btnEdit
      // 
      this.btnEdit.Location = new System.Drawing.Point(153, 31);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Size = new System.Drawing.Size(76, 22);
      this.btnEdit.TabIndex = 6;
      this.btnEdit.Text = "Edit";
      // 
      // btnAdd
      // 
      this.btnAdd.Location = new System.Drawing.Point(153, 3);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(76, 22);
      this.btnAdd.TabIndex = 5;
      this.btnAdd.Text = "Add";
      // 
      // gridItems
      // 
      this.gridItems.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridItems.Location = new System.Drawing.Point(3, 3);
      this.gridItems.MainView = this.gridViewItems;
      this.gridItems.Name = "gridItems";
      this.tableLayoutPanel1.SetRowSpan(this.gridItems, 5);
      this.gridItems.Size = new System.Drawing.Size(144, 113);
      this.gridItems.TabIndex = 4;
      this.gridItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewItems});
      this.gridItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridItems_MouseDoubleClick);
      // 
      // gridViewItems
      // 
      this.gridViewItems.GridControl = this.gridItems;
      this.gridViewItems.Name = "gridViewItems";
      this.gridViewItems.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridViewItems_SelectionChanged);
      this.gridViewItems.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewItems_FocusedRowChanged);
      this.gridViewItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewItems_KeyDown);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.Controls.Add(this.gridItems, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.btnClear, 1, 3);
      this.tableLayoutPanel1.Controls.Add(this.btnEdit, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.btnRemove, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.btnAdd, 1, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 5;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(232, 119);
      this.tableLayoutPanel1.TabIndex = 9;
      // 
      // EditableListGridControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "EditableListGridControl";
      this.Size = new System.Drawing.Size(232, 119);
      ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.SimpleButton btnClear;
    private DevExpress.XtraEditors.SimpleButton btnRemove;
    private DevExpress.XtraEditors.SimpleButton btnEdit;
    private DevExpress.XtraEditors.SimpleButton btnAdd;
    private DevExpress.XtraGrid.GridControl gridItems;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewItems;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
  }
}
