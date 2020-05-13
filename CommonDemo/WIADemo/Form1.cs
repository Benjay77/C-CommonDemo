using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime;
using WIA;
using System.Net;
using System.Threading;
using System.Diagnostics;

namespace WIADemo
{
    public partial class Form1 : Form
    {

        private static Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private static double test1()
        {
            var x = new Stopwatch();
            x.Start();
            Thread.Sleep(rnd.Next(1000));
            return x.Elapsed.TotalMilliseconds;
        }

        private static double test2()
        {
            var x = new Stopwatch();
            x.Start();
            new WebClient().DownloadData("http://bbs.csdn.net/topics/392174830");
            return x.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// 扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScan_Click(object sender, EventArgs e)
        {
            //测试并行任务
            var tasks = new List<Func<Double>> { test1, test1, test1, test2, test2 };
            var x = new Stopwatch();
            var query = from t in tasks.AsParallel()
                        select t();
            x.Start();
            var requst = query.Max();
            x.Stop();
            richTextBox1.Text = string.Format(@"执行{0}个并发计算，用时 {1:0} 毫秒", tasks.Count, x.Elapsed.TotalMilliseconds);

            //测试打印机扫描图片
            ImageFile imageFile = null;
            CommonDialogClass cdc = new CommonDialogClass();
            try
            {
                imageFile = cdc.ShowAcquireImage(WiaDeviceType.ScannerDeviceType, WiaImageIntent.TextIntent, WiaImageBias.MaximizeQuality,
                    "{00000000-0000-0000-0000-000000000000}", true, true, false);
            }
            catch (Exception ex)
            {
                imageFile = null;
            }
            if (imageFile!=null)
            {
                imageFile.SaveFile(@"D:\");
            }
        }
    }
}
