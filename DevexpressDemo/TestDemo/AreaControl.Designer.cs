namespace TestDemo
{
    partial class AreaControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_PARENTID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_SAVE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribe_SAVE = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gc_MODIFY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribe_MODIFY = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribe_SAVE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribe_MODIFY)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ribe_SAVE,
            this.ribe_MODIFY});
            this.gridControl.Size = new System.Drawing.Size(711, 591);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gc_ID,
            this.gc_NAME,
            this.gc_PARENTID,
            this.gc_SAVE,
            this.gc_MODIFY});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // gc_ID
            // 
            this.gc_ID.Caption = "区域ID";
            this.gc_ID.FieldName = "ID";
            this.gc_ID.Name = "gc_ID";
            this.gc_ID.Visible = true;
            this.gc_ID.VisibleIndex = 0;
            // 
            // gc_NAME
            // 
            this.gc_NAME.Caption = "区域名称";
            this.gc_NAME.FieldName = "NAME";
            this.gc_NAME.Name = "gc_NAME";
            this.gc_NAME.Visible = true;
            this.gc_NAME.VisibleIndex = 1;
            // 
            // gc_PARENTID
            // 
            this.gc_PARENTID.Caption = "上级区域ID";
            this.gc_PARENTID.FieldName = "PARENTID";
            this.gc_PARENTID.Name = "gc_PARENTID";
            this.gc_PARENTID.OptionsColumn.AllowEdit = false;
            this.gc_PARENTID.OptionsColumn.ReadOnly = true;
            this.gc_PARENTID.Visible = true;
            this.gc_PARENTID.VisibleIndex = 2;
            // 
            // gc_SAVE
            // 
            this.gc_SAVE.Caption = "保存操作";
            this.gc_SAVE.ColumnEdit = this.ribe_SAVE;
            this.gc_SAVE.FieldName = "SAVE";
            this.gc_SAVE.Name = "gc_SAVE";
            this.gc_SAVE.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gc_SAVE.Visible = true;
            this.gc_SAVE.VisibleIndex = 3;
            // 
            // ribe_SAVE
            // 
            this.ribe_SAVE.AutoHeight = false;
            this.ribe_SAVE.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "保存", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.ribe_SAVE.Name = "ribe_SAVE";
            this.ribe_SAVE.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gc_MODIFY
            // 
            this.gc_MODIFY.Caption = "修改操作";
            this.gc_MODIFY.ColumnEdit = this.ribe_MODIFY;
            this.gc_MODIFY.FieldName = "MODIFY";
            this.gc_MODIFY.Name = "gc_MODIFY";
            this.gc_MODIFY.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gc_MODIFY.Visible = true;
            this.gc_MODIFY.VisibleIndex = 4;
            // 
            // ribe_MODIFY
            // 
            this.ribe_MODIFY.AutoHeight = false;
            this.ribe_MODIFY.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "修改", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.ribe_MODIFY.Name = "ribe_MODIFY";
            this.ribe_MODIFY.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // AreaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "AreaControl";
            this.Size = new System.Drawing.Size(711, 591);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribe_SAVE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribe_MODIFY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gc_ID;
        private DevExpress.XtraGrid.Columns.GridColumn gc_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn gc_PARENTID;
        private DevExpress.XtraGrid.Columns.GridColumn gc_SAVE;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribe_SAVE;
        private DevExpress.XtraGrid.Columns.GridColumn gc_MODIFY;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribe_MODIFY;
    }
}
