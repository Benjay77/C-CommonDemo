using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using SpeechLib;
namespace ComboxFilterDemo
{
    public partial class FormComboxFilter : Form
    {
        private SpVoice voice = new SpVoice();//语音合成对象
        public FormComboxFilter()
        {
            InitializeComponent();
        }
        List<string> listBinding = new List<string>();//将绑定的datasource转为list 方便查询
        DataTable dt_Source = new DataTable();//作为操作Combox绑定的DataTable
        string tempIP = string.Empty;//IP
        public void FormComboxFilter_Load(object sender, EventArgs e)
        {
            dt_Source.Columns.Add("Name");
            dt_Source.Columns.Add("CODE");
            dt_Source.Rows.Add(new string[] { "01王一", "01" });
            dt_Source.Rows.Add(new string[] { "02赵一", "02" });
            dt_Source.Rows.Add(new string[] { "03王二", "03" });
            dt_Source.Rows.Add(new string[] { "04赵二", "04" });
            ComboxDataBinding(dt_Source);
            cmb_Filter.SelectedIndex = -1;
            //获取内网IP
            txt_InnerIP.Text = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();
            try
            {
                SpeechVoiceSpeakFlags flag = SpeechVoiceSpeakFlags.SVSFlagsAsync;
                //voice.Voice = voice.GetVoices(string.Empty, string.Empty).Item(3);//xp下sdk5.1版本使用此方法选择播报方式 win7使用sdk5.4 屏蔽  
                voice.Speak(txt_InnerIP.Text, flag);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #region 获取外网IP
            //try
            //{
            //IPInterfaceProperties ipInterface = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(b =>b.NetworkInterfaceType.ToString().Equals("Wireless80211")).GetIPProperties();
            //for(int i=0;i<ipInterface.UnicastAddresses.Count;i++)
            //{
            //    if (ipInterface.UnicastAddresses[i].Address.AddressFamily.ToString() == "InterNetwork")
            //    {
            //        txt_OuterIP.Text = ipInterface.UnicastAddresses[i].Address.ToString();
            //    }
            //}

            //HttpWebRequest request = HttpWebRequest.Create("http://www.whatismyip.com") as HttpWebRequest;
            //request.Method = "GET";
            //request.ContentType = "application/x-www-form-urlencoded";
            //WebResponse response = request.GetResponse();
            //using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            //{
            //    txt_OuterIP.Text = Regex.Match(reader.ReadToEnd(), @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}").ToString();
            //}
            //WebClient client = new WebClient();
            //client.Encoding = System.Text.Encoding.Default;
            //string response = client.UploadString("http://www.ip138.com/ip2city.asp", "");
            //Match mc = Regex.Match(response, @"location.href=""(.*)""");
            //if (mc.Success && mc.Groups.Count > 1)
            //{
            //    response = client.UploadString(mc.Groups[1].Value, "");
            //    txt_OuterIP.Text = response;
            //}
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //} 
            #endregion
        }

        /// <summary>
        /// 取得TP-LINK路由器的外网IP地址
        /// 本函数假设路由器已处于连网状态，不再对是否连网状态进行判断
        /// </summary>
        /// <param name="strTPIP">TP-LINK路由器的IP地址</param>
        /// <param name="strUserName">TP-LINK路由器的管理用户名</param>
        /// <param name="strPassword">TP-LINK路由器的管理用户密码</param>
        /// <returns>外网IP地址，为空表示获取失败</returns>
        //private string GetWanIP(string strTPIP, string strUserName, string strPassword)
        //{
        //    // 包含TP-LINK路由器状态信息的网页URL
        //    string strTPURL = "http://" + strTPIP + "/userRpm/StatusRpm.htm";

        //    // 设置获取状态信息网页内容的相关参数
        //    System.Net.HttpWebRequest objRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(strTPURL);
        //    objRequest.Referer = strTPURL;
        //    objRequest.Credentials = new System.Net.NetworkCredential(strUserName, strPassword);

        //    // 取得结果信息内容
        //    SetLogMessage(0, "尝试获取路由器状态信息内容");
        //    System.Net.HttpWebResponse objResponse = (System.Net.HttpWebResponse)objRequest.GetResponse();

        //    SetLogMessage(1, "已取得路由器状态信息");
        //    // 取得结果内容文本
        //    System.IO.StreamReader objResponseReader = new System.IO.StreamReader(objResponse.GetResponseStream(), Encoding.Default);
        //    string strResponseText = objResponseReader.ReadToEnd();
        //    objResponseReader.Close();
        //    objResponse.Close();

        //    // 查找包含外网IP地址的数据数组位置
        //    SetLogMessage(1, "查找包含外网IP地址的数据数组位置");
        //    int intPos = strResponseText.IndexOf("var wanPara = new Array");
        //    if (intPos < 0)
        //    {
        //        SetLogMessage(0, "*** 查找包含外网IP地址的数据数组位置失败");
        //        return "";
        //    }

        //    // 查找外网IP地址位置
        //    SetLogMessage(1, "查找外网IP地址位置");
        //    int intPos2 = strResponseText.IndexOf("\",\n\"", intPos);
        //    if (intPos2 < 0)
        //    {
        //        SetLogMessage(0, "*** 查找外网IP地址位置失败");
        //        return "";
        //    }

        //    // 查找外网IP地址结束位置
        //    SetLogMessage(1, "查找外网IP地址结束位置");
        //    int intPos3 = strResponseText.IndexOf("\"", intPos2 + 4);
        //    if (intPos3 < 0)
        //    {
        //        SetLogMessage(0, "*** 查找外网IP地址结束位置失败");
        //        return "";
        //    }

        //    // 得到外网IP地址
        //    int intIPPos = intPos2 + 4;
        //    string strWanIP = strResponseText.Substring(intIPPos, intPos3 - intIPPos);
        //    SetLogMessage(0, "得到结果外网IP地址：[" + strWanIP + "]");

        //    return strWanIP;
        //}

        /// <summary>
        /// Combox数据绑定自动完成下拉框
        /// </summary>
        /// <param name="dt"></param>
        public void ComboxDataBinding(DataTable dt)
        {
            //cmb_Filter.DataSource = null;//清除原有集合
            cmb_Filter.DropDownStyle = ComboBoxStyle.DropDown;
            cmb_Filter.DisplayMember = "NAME";//DisplayMember绑定的是需显示的字段 
            cmb_Filter.ValueMember = "CODE";//ValueMember绑定的是对应的值
            cmb_Filter.DataSource = dt.DefaultView;//绑定视图方便使用RowFilter属性过滤
            //AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    coll.Add(dt.Rows[i]["NAME"].ToString());//这个地方是自动完成的下拉框的显示内容 
            //}
            //cmb_Filter.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //cmb_Filter.AutoCompleteCustomSource = coll;//设置自动完成的源
            foreach (DataRowView dr in cmb_Filter.Items)
            {
                listBinding.Add(dr[0].ToString());
            }
            cmb_Filter.DataSource = null;//清除原有集合
            cmb_Filter.Items.AddRange(listBinding.ToArray());
        }

        /// <summary>
        /// Combox键盘捕捉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //public void cmb_Filter_KeyDown(Object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            if (!string.IsNullOrEmpty(cmb_Filter.Text.Trim()))
        //            {
        //                SelectDataTableByFilter("name like '%" + cmb_Filter.Text + "%'");
        //                //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
        //                this.cmb_Filter.SelectionStart = this.cmb_Filter.Text.Length;
        //                //自动弹出下拉框
        //                this.cmb_Filter.DroppedDown = true;
        //            }
        //            else
        //            {
        //                ComboxDataBinding(dt_Source);
        //                cmb_Filter.SelectedIndex = -1;
        //            }
        //        }
        //        //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
        //        Cursor = Cursors.Default;
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        /// <summary>
        /// Combox文本捕捉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cmb_Filter_TextUpdate(Object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmb_Filter.Text.Trim()))
                {
                    //模糊查询
                    cmb_Filter.Items.Clear();
                    List<string> listItem = new List<string>();
                    listItem.Clear();
                    foreach (var item in listBinding)
                    {
                        if (item.Contains(cmb_Filter.Text.Trim()))
                        {
                            listItem.Add(item);
                        }
                    }
                    cmb_Filter.Items.AddRange(listItem.ToArray());
                    //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
                    this.cmb_Filter.SelectionStart = this.cmb_Filter.Text.Length;
                    //自动弹出下拉框
                    this.cmb_Filter.DroppedDown = true;
                }    
                //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 根据Combox文本输入的条件进行过滤查询
        /// </summary>
        /// <param name="filterString"></param>
        public void SelectDataTableByFilter(string filterString)
        {
            DataRow[] dr_Filter = dt_Source.Select(filterString);
            DataTable dt_Filter = dt_Source.Clone();
            foreach (DataRow dr in dt_Source.Rows)
            {
                dt_Filter.ImportRow(dr);
            }
            dt_Filter.DefaultView.RowFilter = filterString;
            ComboxDataBinding(dt_Filter);
        }
    }
}
