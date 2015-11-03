namespace RecipeBook
{
  partial class AmountControl
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
      this.cboMeasurement = new DevExpress.XtraEditors.LookUpEdit();
      this.numAmount = new DevExpress.XtraEditors.SpinEdit();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      ((System.ComponentModel.ISupportInitialize)(this.cboMeasurement.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numAmount.Properties)).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // cboMeasurement
      // 
      this.cboMeasurement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.cboMeasurement.Location = new System.Drawing.Point(93, 24);
      this.cboMeasurement.Name = "cboMeasurement";
      this.cboMeasurement.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cboMeasurement.Properties.NullText = "[Select a Measurement]";
      this.cboMeasurement.Size = new System.Drawing.Size(176, 20);
      this.cboMeasurement.TabIndex = 5;
      // 
      // numAmount
      // 
      this.numAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.numAmount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
      this.numAmount.Location = new System.Drawing.Point(3, 24);
      this.numAmount.Name = "numAmount";
      this.numAmount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.numAmount.Size = new System.Drawing.Size(84, 20);
      this.numAmount.TabIndex = 4;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.numAmount, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.cboMeasurement, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.labelControl2, 1, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(272, 49);
      this.tableLayoutPanel1.TabIndex = 6;
      // 
      // labelControl1
      // 
      this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelControl1.Location = new System.Drawing.Point(3, 3);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(41, 13);
      this.labelControl1.TabIndex = 6;
      this.labelControl1.Text = "Amount:";
      // 
      // labelControl2
      // 
      this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelControl2.Location = new System.Drawing.Point(93, 3);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(69, 13);
      this.labelControl2.TabIndex = 7;
      this.labelControl2.Text = "Measurement:";
      // 
      // AmountControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "AmountControl";
      this.Size = new System.Drawing.Size(272, 49);
      ((System.ComponentModel.ISupportInitialize)(this.cboMeasurement.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numAmount.Properties)).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.SpinEdit numAmount;
    private DevExpress.XtraEditors.LookUpEdit cboMeasurement;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.LabelControl labelControl2;
  }
}
