using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDemo
{
    public partial class AreaControl : UserControl
    {
        #region 基本变量

        private DataTable dt_AREA = new DataTable();
        private DataTable dt_OLD = new DataTable();
        private bool isAdd = false;
        private bool isModify = false;

        #endregion 基本变量

        public AreaControl(string ID, string NAME,string parentID,string operateType)
        {
            InitializeComponent();
            dt_AREA = XmlHelper.GetDataSetByXml("DATA.XSD").Tables[0].Clone();
            dt_AREA.Rows.Add(ID, NAME, parentID);
            gridControl.DataSource = dt_AREA;
            gridView.OptionsBehavior.ReadOnly = false;
            if (operateType == "ADD")
            {
                isAdd = true;
                gridView.Columns["MODIFY"].OptionsColumn.AllowEdit = false;
                gridView.Columns["MODIFY"].Visible = false;
            }
            else if (operateType == "MODIFY")
            {
                isModify = true;
                gridView.Columns["SAVE"].OptionsColumn.AllowEdit = false;
                gridView.Columns["SAVE"].Visible = false;
            }
            if (!string.IsNullOrEmpty(ID))//双击节点触发gridView为修改状态时ID不可修改
            {
                gridView.Columns["ID"].OptionsColumn.AllowEdit = false;
                gridView.Columns["ID"].OptionsColumn.ReadOnly = true;
                dt_OLD = (DataTable)gridControl.DataSource;
            }
            ribe_SAVE.ButtonClick += Ribe_SAVE_ButtonClick;
            ribe_MODIFY.ButtonClick += Ribe_MODIFY_ButtonClick;
        }

        #region 控件事件

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ribe_MODIFY_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            isModify = true;
            dt_OLD = (DataTable)gridControl.DataSource;
            gridView.OptionsBehavior.ReadOnly = false;
            gridView.Columns["ID"].OptionsColumn.AllowEdit = false;
            gridView.Columns["ID"].OptionsColumn.ReadOnly = true;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ribe_SAVE_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView.CloseEditor();
            gridView.UpdateCurrentRow();
            SaveNode();
        }

        #endregion 控件触发事件

        #region 自定义方法

        /// <summary>
        /// 树保存节点
        /// </summary>
        /// <param name="operateType"></param>
        public void SaveNode()
        {
            DataRow dr_FocusedRow = gridView.GetFocusedDataRow();
            if (!string.IsNullOrEmpty(dr_FocusedRow["ID"].ToString()) && !string.IsNullOrEmpty(dr_FocusedRow["NAME"].ToString()))
            {
                if (!isModify)
                {
                    if(!XmlHelper.WriteXmlByDataSet("DATA.XML", dt_AREA, "ONE"))
                    {
                        MessageBox.Show("该节点已存在！");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("节点保存成功！");
                        RefreshTreeNode();
                        isAdd = false;
                        gridView.Columns["SAVE"].OptionsColumn.AllowEdit = false;
                        gridView.Columns["SAVE"].Visible = false;
                    }
                }
                else
                {
                    if (XmlHelper.UpdateXmlRow("DATA.XML", dt_AREA, dt_OLD))
                    {
                        RefreshTreeNode();
                        dt_OLD = null;
                        MessageBox.Show("修改成功！");
                        isModify = false;
                        gridView.Columns["MODIFY"].OptionsColumn.AllowEdit = false;
                        gridView.Columns["MODIFY"].Visible = false;
                    }
                }
                gridView.OptionsBehavior.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("区域名称或区域ID为空，请检查！");
            }
        }

        /// <summary>
        /// 树节点刷新
        /// </summary>
        public void RefreshTreeNode()
        {
            DataRow dr_FocusedRow = gridView.GetFocusedDataRow();
            if (TestDemo.treeList.Nodes.Count>0)
            {
                TestDemo.treeList.Nodes.Clear();
            }
            dt_AREA = XmlHelper.GetDataSetByXml("DATA.XML").Tables[0];
            TestDemo.treeList.DataSource = dt_AREA;
            TestDemo.btn_Delete.Enabled = true;
            TestDemo.btn_AddChild.Enabled = true;
            TestDemo.btn_AddRoot.Enabled = true;
            TestDemo.btn_Save.Enabled = true;
            this.Parent.Text = dr_FocusedRow["ID"].ToString() + dr_FocusedRow["NAME"].ToString() + dr_FocusedRow["PARENTID"].ToString();
            TestDemo.lstCaption.Add(this.Parent.Text);
            //this.Parent.Dispose();
        }

        #endregion 自定义方法
    }
}
