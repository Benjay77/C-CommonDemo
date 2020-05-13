using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views.NativeMdi;
using System.IO;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace TestDemo
{
    /// <summary>
    /// 树形控件操作
    /// 
    /// Edtion      Editor      Date            Memo 
    /// 
    /// 1.0         Benjay      2017.04.28      创建
    /// 1.1         Benjay      2017.05.02      添加时钟显示及窗口数统计
    /// 1.2         Benjay      2017.05.02      添加右键菜单
    /// 1.3         Benjay      2017.07.15      修改节点添加修改保存删除操作，窗口操作逻辑，修正BUG
    /// 1.4         Benjay      2019.04.24      修改子窗口初始化显示宽度，窗口操作新增、修改逻辑，修正BUG
    /// </summary>
    public partial class TestDemo : Form
    {
        #region 基本变量

        private DataTable dt_Result = new DataTable();
        private int i_dt_ResultRowsCount = 0;//记录已勾选的ID数
        private List<int> lstCheckedKeyID = new List<int>();//选中节点ID集合
        public static List<String> lstCaption = new List<String>();//已出现的窗口
        private System.Threading.Timer timer;
        public static TreeList treeList;
        public static BarButtonItem btn_AddRoot;
        public static BarButtonItem btn_AddChild;
        public static BarButtonItem btn_Delete;
        public static BarButtonItem btn_Save;

        #endregion 基本变量

        public TestDemo()
        {
            InitializeComponent();
            trl_AREA.BeforeCheckNode += TrlAREA_BeforeCheckNode;
            trl_AREA.AfterCheckNode += TrlAREA_AfterCheckNode;
            trl_AREA.MouseDoubleClick += Trl_AREA_MouseDoubleClick;
            trl_AREA.MouseUp += Trl_AREA_MouseUp; 
            btn_ADDROOT.ItemClick += toolBar_ItemClicked;
            btn_DELETE.ItemClick += toolBar_ItemClicked;
            btn_ADDCHILD.ItemClick += toolBar_ItemClicked;
            btn_SAVE.ItemClick += toolBar_ItemClicked;
            btn_SHOW.ItemClick += toolBar_ItemClicked;
            btn_MODIFY.ItemClick += toolBar_ItemClicked;
            if (!File.Exists(Application.StartupPath + "/DATA.XML"))
            {
                XmlHelper.CreateXML("DATA");
                //File.Create(Application.StartupPath + "/DATA.XML");
            }
            else
            {
                if (XmlHelper.GetDataSetByXml("DATA.XML")!=null)
                {
                    dt_Result = XmlHelper.GetDataSetByXml("DATA.XML").Tables[0];
                    trl_AREA.DataSource = dt_Result;
                }
            }
            TimerRefresh();
            timer = new System.Threading.Timer(new System.Threading.TimerCallback(TimerUpdateCallback), null, 0, 1000);
        }
       
        #region 控件触发事件

        /// <summary>
        /// 树形双击节点触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Trl_AREA_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hi = trl_AREA.CalcHitInfo(e.Location);
            TreeListNode CurrentNode = hi.Node;
            if (CurrentNode != null)
            {
                btn_MODIFY_Click(CurrentNode);
            }
        }

        /// <summary>
        /// 树形勾选前触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrlAREA_BeforeCheckNode(object sender, CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        /// <summary>
        /// 树形勾选后触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrlAREA_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        /// <summary>
        /// 窗口关闭触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form form = sender as Form;
            if (form.Text != "0")
            {
                lstCaption.Remove(form.Text);
            }
            btn_DELETE.Enabled = true;
            btn_ADDCHILD.Enabled = true;
            btn_ADDROOT.Enabled = true;
            btn_SAVE.Enabled = true;
        }

        /// <summary>
        /// 右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Trl_AREA_MouseUp(object sender, MouseEventArgs e)
        {
            TreeList tree = sender as TreeList;
            if (e.Button == MouseButtons.Right
                    && ModifierKeys == Keys.None
                    && trl_AREA.State == TreeListState.Regular)
            {
                Point p = new Point(Cursor.Position.X, Cursor.Position.Y);
                TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Location);
                if (hitInfo.HitInfoType == HitInfoType.Cell)
                {
                    tree.SetFocusedNode(hitInfo.Node);
                }
                test_popupMenu.ShowPopup(p);
                if (tree.FocusedNode == null)
                {
                    btn_MODIFY.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 线程时钟CallBack
        /// </summary>
        /// <param name="sender"></param>
        void TimerUpdateCallback(object sender)
        {
             this.UIThread(delegate
            {
                TimerRefresh();
            });
        }

        #endregion 控件触发事件

        #region 树形操作

        /// <summary>
        /// 递归勾选节点信息
        /// </summary>
        /// <param name="nodes"></param>
        private void SetNodesCheckValue(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                if (node.HasChildren)
                {
                    SetNodesCheckValue(node.Nodes);
                }
                if (dt_Result.Select("ID =" + node.GetValue("ID").ToString()).Length != 0)
                {
                    node.CheckState = CheckState.Checked;
                    i_dt_ResultRowsCount += 1;
                    if (i_dt_ResultRowsCount == dt_Result.Rows.Count)//区域分组信息勾选完成 退出循环
                    {
                        SetCheckedParentNodes(node, CheckState.Checked);//父节点设置勾选状态
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 子节点勾选
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        /// <summary>
        /// 父节点勾选
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                CheckState parentCheckState = node.ParentNode.CheckState;
                CheckState nodeCheckState;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    nodeCheckState = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(nodeCheckState))//只要任意一个与其选中状态不一样即父节点状态不全选
                    {
                        parentCheckState = CheckState.Indeterminate;
                        break;
                    }
                    parentCheckState = check;//否则（该节点的兄弟节点选中状态都相同），则父节点选中状态为该节点的选中状态
                }
                node.ParentNode.CheckState = parentCheckState;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        /// <summary>
        /// 获取选择状态的数据主键ID集合
        /// </summary>
        /// <param name="parentNode">父级节点</param>
        private void GetCheckedKeyID(TreeListNode parentNode)
        {
            if (parentNode.Nodes.Count == 0)
            {
                if (parentNode.HasChildren)
                {
                    return;//递归终止
                }                
            }
            if (parentNode.CheckState == CheckState.Checked)
            {
                DataRowView drv = trl_AREA.GetDataRecordByNode(parentNode) as DataRowView;
                if (drv != null)
                {
                    if (!lstCheckedKeyID.Contains(int.Parse(drv["ID"].ToString())))
                    {
                        lstCheckedKeyID.Add(int.Parse(drv["ID"].ToString()));
                    }
                }
            }

            foreach (TreeListNode node in parentNode.Nodes)
            {
                if (node.CheckState == CheckState.Checked)
                {
                    DataRowView drv = trl_AREA.GetDataRecordByNode(node) as DataRowView;
                    if (drv != null)
                    {
                        lstCheckedKeyID.Add(int.Parse(drv["ID"].ToString()));
                    }
                }
                GetCheckedKeyID(node);
            }
        }

        #endregion 树形操作

        #region 工具栏点击事件

        /// <summary>
        /// 工具栏点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBar_ItemClicked(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btn_ADDROOT":
                    btn_ADD_Click("ROOT");
                    break;

                case "btn_DELETE":
                    btn_DELETE_Click();
                    break;

                case "btn_MODIFY":
                    btn_MODIFY_Click(trl_AREA.FocusedNode);
                    break;

                case "btn_ADDCHILD":
                    if (trl_AREA.FocusedNode!= null)
                    {
                        btn_ADD_Click("CHILD");
                    }
                    else
                    {
                        MessageBox.Show("请先选择父节点！");
                    }
                    break;

                case "btn_SAVE":
                    btn_SAVE_Click();
                    break;

                case "btn_SHOW":
                    btn_SHOW_Click();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        private void btn_ADD_Click(string operateType)
        {
            string parentID = string.Empty;
            btn_DELETE.Enabled = false;
            btn_ADDCHILD.Enabled = false;
            btn_ADDROOT.Enabled = false;
            btn_SAVE.Enabled = false;
            if (operateType == "ROOT")
            {
                parentID = "0";
            }
            else
            {
                TreeListNode node = trl_AREA.FocusedNode;
                parentID = node.GetValue("ID").ToString();
            }
            AddDocument("","",parentID,"ADD");
        }

        /// <summary>
        /// 修改
        /// </summary>
        private void btn_MODIFY_Click(TreeListNode node)
        {
            string id = node.GetValue("ID").ToString();
            string name = node.GetValue("NAME").ToString();
            string parentid = node.GetValue("PARENTID").ToString();
            AddDocument(id, name, parentid,"MODIFY");
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void btn_DELETE_Click()
        {
            if (trl_AREA.Nodes.Count > 0)
            {
                foreach (TreeListNode treeListNode in trl_AREA.Nodes)
                {
                    GetCheckedKeyID(treeListNode);
                }
            }
            if (lstCheckedKeyID.Count>0)
            {
                if (XmlHelper.DeleteXmlRowByIndex("DATA.XML", lstCheckedKeyID))
                {
                    MessageBox.Show("删除节点成功！");
                    foreach (int keyID in lstCheckedKeyID)
                    {
                        if (test_DM.View.Documents.Count>0)
                        {
                            string caption = test_DM.View.Documents.FindFirst(x => x.Caption.Substring(0, keyID.ToString().Length).Equals(keyID.ToString())).Caption;
                            if (!string.IsNullOrEmpty(caption))
                            {
                                lstCaption.Remove(caption);
                                test_DM.View.Documents.FindFirst(x => x.Caption.Equals(caption)).Dispose();
                            }
                        }
                    }
                    trl_AREA.Nodes.Clear();
                    DataSet ds = XmlHelper.GetDataSetByXml("DATA.XML");
                    if (ds!=null)
                    {
                        dt_Result = ds.Tables[0];
                        trl_AREA.DataSource = dt_Result;
                    }
                    //SetNodesCheckValue(trl_AREA.Nodes);
                }
                else
                {
                    MessageBox.Show("删除节点失败！");
                }
            }
            else
            {
                MessageBox.Show("请勾选要删除的节点！");
            }
                 
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btn_SAVE_Click()
        {
            if (trl_AREA.Nodes.Count > 0)
            {
                XmlHelper.DeleteXmlAllRows("DATA.XML");
                DataTable dt_Tree = new DataTable();
                dt_Tree = (DataTable)trl_AREA.DataSource;
                if (XmlHelper.WriteXmlByDataSet("DATA.XML", dt_Tree, "ALL"))
                {
                    MessageBox.Show("保存树形成功！");
                }
                else
                {
                    MessageBox.Show("保存树形失败！");
                }
            }
            else
            {
                MessageBox.Show("树形无节点！");
            }
        }

        /// <summary>
        /// 显示区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SHOW_Click()
        {
            test_DOCKPANEL.Show();
        }

        #endregion 工具栏点击事件

        #region 自定义方法

        /// <summary>
        /// 添加活动窗口
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <param name="ParentId"></param>
        /// <param name="OperateType"></param>
        private void AddDocument(string ID,string Name,string ParentId,string OperateType)
        {
            string caption = lstCaption.Find(delegate (string Caption) { return Caption == ID + Name + ParentId; });
            if (string.IsNullOrEmpty(caption))
            {
                treeList = trl_AREA;
                btn_AddRoot = btn_ADDROOT;
                btn_AddChild = btn_ADDCHILD;
                btn_Delete = btn_DELETE;
                btn_Save = btn_SAVE;
                Document bd = new Document();
                bd.Caption = ID + Name + ParentId;
                test_DM.View.Documents.Add(bd);

                Form childForm = null;
                childForm = new Form();
                childForm.Width = 550;
                childForm.FormClosed += ChildForm_FormClosed;
                childForm.Text = ID + Name + ParentId;

                AreaControl areaControl = new AreaControl(ID, Name, ParentId,OperateType);
                areaControl.Parent = childForm;

                childForm.MdiParent = this;
                childForm.Show();
                //根节点添加 可以打开多个窗口添加
                if (bd.Caption != "0")
                {
                    lstCaption.Add(bd.Caption);
                }
            }
            else
            {
                MessageBox.Show("窗口重复！");
            }
        }

        /// <summary>
        /// 时钟刷新
        /// </summary>
        private void TimerRefresh()
        {
            txt_TIME.Caption = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txt_FORM.Caption = test_DM.View.Documents.Count.ToString();
        }

        #endregion 自定义方法
    }
}
