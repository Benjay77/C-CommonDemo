namespace TestDemo
{
    partial class TestDemo
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.test_BM = new DevExpress.XtraBars.BarManager(this.components);
            this.barTool = new DevExpress.XtraBars.Bar();
            this.btn_ADDROOT = new DevExpress.XtraBars.BarButtonItem();
            this.btn_ADDCHILD = new DevExpress.XtraBars.BarButtonItem();
            this.btn_DELETE = new DevExpress.XtraBars.BarButtonItem();
            this.btn_SAVE = new DevExpress.XtraBars.BarButtonItem();
            this.btn_SHOW = new DevExpress.XtraBars.BarButtonItem();
            this.barStatus = new DevExpress.XtraBars.Bar();
            this.txt_TIME = new DevExpress.XtraBars.BarStaticItem();
            this.txt_COUNT = new DevExpress.XtraBars.BarStaticItem();
            this.txt_FORM = new DevExpress.XtraBars.BarHeaderItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btn_MODIFY = new DevExpress.XtraBars.BarButtonItem();
            this.test_DM = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.nativeMdiView = new DevExpress.XtraBars.Docking2010.Views.NativeMdi.NativeMdiView(this.components);
            this.test_DOCKMANAGER = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.test_DOCKPANEL = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.trl_AREA = new DevExpress.XtraTreeList.TreeList();
            this.tlc_ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlc_NAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlc_PARENTID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.test_popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.test_BM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_DM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nativeMdiView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_DOCKMANAGER)).BeginInit();
            this.hideContainerLeft.SuspendLayout();
            this.test_DOCKPANEL.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trl_AREA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // test_BM
            // 
            this.test_BM.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTool,
            this.barStatus});
            this.test_BM.DockControls.Add(this.barDockControlTop);
            this.test_BM.DockControls.Add(this.barDockControlBottom);
            this.test_BM.DockControls.Add(this.barDockControlLeft);
            this.test_BM.DockControls.Add(this.barDockControlRight);
            this.test_BM.Form = this;
            this.test_BM.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_ADDROOT,
            this.btn_DELETE,
            this.btn_ADDCHILD,
            this.btn_SAVE,
            this.btn_SHOW,
            this.txt_TIME,
            this.txt_COUNT,
            this.txt_FORM,
            this.btn_MODIFY});
            this.test_BM.MainMenu = this.barTool;
            this.test_BM.MaxItemId = 13;
            // 
            // barTool
            // 
            this.barTool.BarName = "工具栏";
            this.barTool.DockCol = 0;
            this.barTool.DockRow = 0;
            this.barTool.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTool.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_ADDROOT),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_ADDCHILD),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_DELETE),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_SAVE),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_SHOW)});
            this.barTool.OptionsBar.MultiLine = true;
            this.barTool.OptionsBar.UseWholeRow = true;
            this.barTool.Text = "工具栏";
            // 
            // btn_ADDROOT
            // 
            this.btn_ADDROOT.Caption = "新增根节点";
            this.btn_ADDROOT.Id = 0;
            this.btn_ADDROOT.Name = "btn_ADDROOT";
            // 
            // btn_ADDCHILD
            // 
            this.btn_ADDCHILD.Caption = "新增子节点";
            this.btn_ADDCHILD.Id = 2;
            this.btn_ADDCHILD.Name = "btn_ADDCHILD";
            // 
            // btn_DELETE
            // 
            this.btn_DELETE.Caption = "删除";
            this.btn_DELETE.Id = 1;
            this.btn_DELETE.Name = "btn_DELETE";
            // 
            // btn_SAVE
            // 
            this.btn_SAVE.Caption = "保存";
            this.btn_SAVE.Id = 3;
            this.btn_SAVE.Name = "btn_SAVE";
            // 
            // btn_SHOW
            // 
            this.btn_SHOW.Caption = "显示区域";
            this.btn_SHOW.Id = 4;
            this.btn_SHOW.Name = "btn_SHOW";
            // 
            // barStatus
            // 
            this.barStatus.BarName = "状态栏";
            this.barStatus.DockCol = 0;
            this.barStatus.DockRow = 0;
            this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.txt_TIME),
            new DevExpress.XtraBars.LinkPersistInfo(this.txt_COUNT),
            new DevExpress.XtraBars.LinkPersistInfo(this.txt_FORM)});
            this.barStatus.OptionsBar.UseWholeRow = true;
            this.barStatus.Text = "状态栏";
            // 
            // txt_TIME
            // 
            this.txt_TIME.Id = 5;
            this.txt_TIME.Name = "txt_TIME";
            this.txt_TIME.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // txt_COUNT
            // 
            this.txt_COUNT.Caption = "打开窗口个数：";
            this.txt_COUNT.Id = 6;
            this.txt_COUNT.Name = "txt_COUNT";
            this.txt_COUNT.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // txt_FORM
            // 
            this.txt_FORM.Id = 7;
            this.txt_FORM.Name = "txt_FORM";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.test_BM;
            this.barDockControlTop.Size = new System.Drawing.Size(1139, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 653);
            this.barDockControlBottom.Manager = this.test_BM;
            this.barDockControlBottom.Size = new System.Drawing.Size(1139, 38);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Manager = this.test_BM;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 624);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1139, 29);
            this.barDockControlRight.Manager = this.test_BM;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 624);
            // 
            // btn_MODIFY
            // 
            this.btn_MODIFY.Caption = "修改节点";
            this.btn_MODIFY.Id = 12;
            this.btn_MODIFY.Name = "btn_MODIFY";
            // 
            // test_DM
            // 
            this.test_DM.MdiParent = this;
            this.test_DM.MenuManager = this.test_BM;
            this.test_DM.RightToLeftLayout = DevExpress.Utils.DefaultBoolean.True;
            this.test_DM.View = this.nativeMdiView;
            this.test_DM.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.nativeMdiView});
            // 
            // test_DOCKMANAGER
            // 
            this.test_DOCKMANAGER.AutoHiddenPanelShowMode = DevExpress.XtraBars.Docking.AutoHiddenPanelShowMode.MouseHover;
            this.test_DOCKMANAGER.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerLeft});
            this.test_DOCKMANAGER.Form = this;
            this.test_DOCKMANAGER.MenuManager = this.test_BM;
            this.test_DOCKMANAGER.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // hideContainerLeft
            // 
            this.hideContainerLeft.BackColor = System.Drawing.SystemColors.Control;
            this.hideContainerLeft.Controls.Add(this.test_DOCKPANEL);
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.hideContainerLeft.Location = new System.Drawing.Point(0, 29);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(26, 624);
            // 
            // test_DOCKPANEL
            // 
            this.test_DOCKPANEL.Controls.Add(this.dockPanel1_Container);
            this.test_DOCKPANEL.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.test_DOCKPANEL.ID = new System.Guid("29d0c017-8363-4713-8d7a-602e8f77d0ec");
            this.test_DOCKPANEL.Location = new System.Drawing.Point(0, 0);
            this.test_DOCKPANEL.Name = "test_DOCKPANEL";
            this.test_DOCKPANEL.OriginalSize = new System.Drawing.Size(200, 200);
            this.test_DOCKPANEL.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.test_DOCKPANEL.SavedIndex = 0;
            this.test_DOCKPANEL.Size = new System.Drawing.Size(200, 624);
            this.test_DOCKPANEL.Text = "区域";
            this.test_DOCKPANEL.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.trl_AREA);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 28);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(188, 591);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // trl_AREA
            // 
            this.trl_AREA.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlc_ID,
            this.tlc_NAME,
            this.tlc_PARENTID});
            this.trl_AREA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trl_AREA.Location = new System.Drawing.Point(0, 0);
            this.trl_AREA.Name = "trl_AREA";
            this.trl_AREA.OptionsBehavior.Editable = false;
            this.trl_AREA.OptionsView.ShowCheckBoxes = true;
            this.trl_AREA.Size = new System.Drawing.Size(188, 591);
            this.trl_AREA.TabIndex = 0;
            // 
            // tlc_ID
            // 
            this.tlc_ID.Caption = "ID";
            this.tlc_ID.FieldName = "ID";
            this.tlc_ID.Name = "tlc_ID";
            // 
            // tlc_NAME
            // 
            this.tlc_NAME.Caption = "区域名称";
            this.tlc_NAME.FieldName = "NAME";
            this.tlc_NAME.MinWidth = 34;
            this.tlc_NAME.Name = "tlc_NAME";
            this.tlc_NAME.Visible = true;
            this.tlc_NAME.VisibleIndex = 0;
            // 
            // tlc_PARENTID
            // 
            this.tlc_PARENTID.Caption = "PARENTID";
            this.tlc_PARENTID.FieldName = "PARENTID";
            this.tlc_PARENTID.Name = "tlc_PARENTID";
            // 
            // test_popupMenu
            // 
            this.test_popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_ADDROOT),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_ADDCHILD),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_MODIFY),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_DELETE),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_SAVE)});
            this.test_popupMenu.Manager = this.test_BM;
            this.test_popupMenu.Name = "test_popupMenu";
            // 
            // TestDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 691);
            this.Controls.Add(this.hideContainerLeft);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Name = "TestDemo";
            this.Text = "TestDemo";
            ((System.ComponentModel.ISupportInitialize)(this.test_BM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_DM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nativeMdiView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_DOCKMANAGER)).EndInit();
            this.hideContainerLeft.ResumeLayout(false);
            this.test_DOCKPANEL.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trl_AREA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.test_popupMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarManager test_BM;
        private DevExpress.XtraBars.Bar barTool;
        private DevExpress.XtraBars.BarButtonItem btn_ADDROOT;
        private DevExpress.XtraBars.BarButtonItem btn_DELETE;
        private DevExpress.XtraBars.BarButtonItem btn_ADDCHILD;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Docking2010.DocumentManager test_DM;
        private DevExpress.XtraBars.Docking2010.Views.NativeMdi.NativeMdiView nativeMdiView;
        private DevExpress.XtraBars.Docking.DockPanel test_DOCKPANEL;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockManager test_DOCKMANAGER;
        private DevExpress.XtraTreeList.TreeList trl_AREA;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlc_NAME;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlc_ID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlc_PARENTID;
        private DevExpress.XtraBars.BarButtonItem btn_SAVE;
        private DevExpress.XtraBars.BarButtonItem btn_SHOW;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerLeft;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarStaticItem txt_TIME;
        private DevExpress.XtraBars.BarStaticItem txt_COUNT;
        private DevExpress.XtraBars.BarHeaderItem txt_FORM;
        private DevExpress.XtraBars.PopupMenu test_popupMenu;
        private DevExpress.XtraBars.BarButtonItem btn_MODIFY;
    }
}

