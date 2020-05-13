using SortDemo.SortClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txt_Input.KeyDown += Txt_Input_KeyDown;
            btn_Clear.Click += Btn_Clear_Click;
            txt_Input.Text = "23，34，5，9，7，6，10，8";
        }

        /// <summary>
        /// 清除输出和时间显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            rtb_Output.Clear();
            rtb_SortTime.Clear();
        }

        /// <summary>
        /// 输入数据回车触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Input_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //各排序算法比较
                List<string> lst_Input = txt_Input.Text.Trim().Split('，').ToList();
                List<int> lst_Sort = new List<int>();
                lst_Input.ForEach(s=>
                {
                    lst_Sort.Add(Convert.ToInt32(s));
                });
                List<int> lst_Sorted = new List<int>();
                lst_Sorted = lst_Sort;
                string tip = string.Empty;
                Stopwatch stopwatch = Stopwatch.StartNew();
                //插入排序
                if (rb_InsertionSort.Checked)
                {
                    tip = rb_InsertionSort.Text;
                    SortMethod.InsertionSortMethod(lst_Sorted);
                }
                //冒泡排序
                if (rb_BubbleSort.Checked)
                {
                    tip = rb_BubbleSort.Text;
                    SortMethod.BubbleSortMethod(lst_Sorted);
                }
                //希尔排序
                if (rb_ShellSort.Checked)
                {
                    tip = rb_ShellSort.Text;
                    SortMethod.ShellSortMethod(lst_Sorted);
                }
                stopwatch.Stop();
                rtb_Output.AppendText(tip + "结果：【" + PrintList(lst_Sorted) + "】");
                rtb_Output.AppendText(Environment.NewLine);
                rtb_SortTime.AppendText(tip + "耗时：【" + stopwatch.Elapsed.ToString() + "】");
                rtb_SortTime.AppendText(Environment.NewLine);
            }
        }

        /// <summary>
        /// 打印排序后的列表
        /// </summary>
        /// <param name="lst_Sorted"></param>
        /// <returns></returns>
        public static string PrintList(List<int> lst_Sorted)
        {
            string str_List = string.Empty;
            lst_Sorted.ForEach(i=>
            {
                str_List += i.ToString() + ",";
            });
            return str_List.Substring(0,str_List.Length-1);
        }

        
    }
}
