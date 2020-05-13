using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using Spire.Pdf;
using System.Text;

namespace PrintDemo
{
    public partial class FormPrint : Form
    {
        string url = null;
        WebBrowser wbs_WayBill = new WebBrowser();
        static bool isPrint = false;//能否打印标志
        PdfDocument pdfDOC = new PdfDocument();

        #region 关于取消事件的处理 暂时不用
        //public delegate void CancelEventHandler(object sender, CancelEventArgs e);

        //public static event CancelEventHandler Print;

        //protected void OnPrint(object sender, CancelEventArgs e)
        //{
        //    if (Print != null)
        //    {
        //        Print(sender, e);
        //    }
        //}

        //public void IsCancelPrint(object sender, CancelEventArgs e)
        //{
        //    if (isPrint)
        //    {
        //        e.Cancel = false;
        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //    }
        //}
        #endregion

        public FormPrint()
        {
            InitializeComponent();
            //url = URL;//客户提供的url
        }
        
        public void FormPrint_Load(object sender, System.EventArgs e)
        {
            //wbs_WayBill.Navigate(url);
            //wbs_WayBill.Navigate(" http://img01.taobaocdn.com/tfscom/TB1atsvJFXXXXXjXpXXSutbFXXX"); //测试地址
            //wbs_WayBill.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wbs_WayBill_DocumentCompleted);
            //FormPrint.Print += new FormPrint.CancelEventHandler(IsCancelPrint);
        }

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Print_Click(object sender, EventArgs e)
        {
            //打印图片
            try
            {
                //测试PDF打印
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://img01.taobaocdn.com/tfscom/TB1hvFHKFXXXXXEaXXXXXXXXXXX.pdf");
                using (WebResponse wr = req.GetResponse())
                {
                    Stream str = wr.GetResponseStream();
                    using (FileStream fileStream = new FileStream(string.Format("面单.pdf"), FileMode.Create, FileAccess.Write))
                    {
                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = str.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                fileStream.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                pdfDOC.LoadFromFile("面单.pdf");

                //选择默认打印机打印所有页面
                pdfDOC.PrintDocument.Print();

                //测试打印机打印
                //if (string.IsNullOrEmpty(txt_Height.Text.Trim()) || string.IsNullOrEmpty(txt_Width.Text.Trim()))
                //{
                //    MessageBox.Show("请输入面单模板打印大小！");
                //    return;
                //}
                //printDialog = new PrintDialog();
                //printDialog.Document = printDocument;
                //printDocument.Print();
                //this.Close();//打印完毕关闭窗体
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void wbs_WayBill_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string imgUrl = string.Empty;//图片地址
            HtmlElementCollection ElementCollection = wbs_WayBill.Document.GetElementsByTagName("img");
            imgUrl = ElementCollection[0].GetAttribute("src");
            WebClient webClient = new WebClient();
            byte[] buffer = webClient.DownloadData(imgUrl);
            webClient.Dispose();
            MemoryStream ms = new MemoryStream(buffer);
            //Image image = Image.FromStream(ms);
            //Bitmap bm = new Bitmap(image, pic_Print.Width, pic_Print.Height);
            pic_Print.Image = Image.FromStream(ms);
        }

        #region 获取设备像素调用的API
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr ptr); 

        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(
        IntPtr hdc, // handle to DC
        int nIndex // index of capability
        );

        const int LOGPIXELSX = 88;
        const int LOGPIXELSY = 90; 

        [DllImport("user32.dll")]
        internal static extern bool SetProcessDPIAware();
        #endregion

        /// <summary>
        /// 获取图片准备打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image printImage = pic_Print.Image;
            #region 转换打印模板的实际单位为像素
            double pixelTargetWidth = 0;//像素宽度
            double pixelTargetHeight = 0;//像素高度

            //使用系统API获取打印机DPI 
            SetProcessDPIAware(); //重要 
            IntPtr screenDC = GetDC(IntPtr.Zero);
            int dpi_x = GetDeviceCaps(screenDC, LOGPIXELSX);
            int dpi_y = GetDeviceCaps(screenDC, LOGPIXELSY);

            pixelTargetWidth = double.Parse(txt_Width.Text.Trim()) * dpi_x / 2.54;
            pixelTargetHeight = double.Parse(txt_Height.Text.Trim()) * dpi_y / 2.54;
            #endregion

            //按比例缩放图片
            Image newPrintImage = ZoomPic(printImage, pixelTargetWidth, pixelTargetHeight,100);
            if (!isPrint)
            {
                e.Cancel = true;
                printDocument.Dispose();
                return;
            }
            else
            {
                int x = e.MarginBounds.X;
                int y = e.MarginBounds.Y;
                int width = newPrintImage.Width;
                int height = newPrintImage.Height;
                Rectangle destRect = new Rectangle(x, y, width, height);
                e.Graphics.DrawImage(newPrintImage, destRect);
            }
        }

        /// <summary>
        /// 图片等比例缩放
        /// </summary>
        /// <param name="printImage">打印的图片</param>
        /// <param name="targetWidth">模板宽度</param>
        /// <param name="targetHeight">模板高度</param>
        /// <returns></returns>
        public static Image ZoomPic(Image printImage, double targetWidth, double targetHeight, int quality)
        {
            //原图宽高均小于模版不作处理
            if (printImage.Width <= targetWidth && printImage.Height <= targetHeight)
            {
                MessageBox.Show("图片小于模板大小，请重新设置！");
                return printImage;
            }
            else
            {
                //缩略图宽、高计算
                double newWidth =printImage.Width;
                double newHeight =printImage.Height;
                //宽大于高或宽等于高（横图或正方）
                if (printImage.Width > printImage.Height || printImage.Width == printImage.Height)
                {
                    //如果宽大于模版
                    if (printImage.Width > targetWidth)
                    {
                        //宽按模版，高按比例缩放
                        newWidth = targetWidth;
                        newHeight =printImage.Height * (targetWidth /printImage.Width);
                    }
                }
                //高大于宽（竖图）
                else
                {
                    //如果高大于模版
                    if (printImage.Height > targetHeight)
                    {
                        //高按模版，宽按比例缩放
                        newHeight = targetHeight;
                        newWidth = printImage.Width * (targetHeight /printImage.Height);
                    }
                }

                //生成新图
                //新建一个bmp图片
                Image tempImage = new Bitmap((int)newWidth, (int)newHeight);
                //新建一个画板
                Graphics newG = Graphics.FromImage(tempImage);
                //设置质量
                newG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                newG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                //置背景色
                newG.Clear(Color.White);
                //画图
                newG.DrawImage(printImage, new Rectangle(0, 0, tempImage.Width, tempImage.Height),
                    new Rectangle(0, 0, printImage.Width, printImage.Height), System.Drawing.GraphicsUnit.Pixel);
                //质量控制
                ImageCodecInfo myImageCodecInfo;
                myImageCodecInfo = GetEncoderInfo("image/jpeg");
                EncoderParameters ep = new EncoderParameters(1);
                ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);
                //保存缩略图到内存
                MemoryStream memoryStream = new MemoryStream();
                tempImage.Save(memoryStream, myImageCodecInfo, ep);
                //释放资源
                newG.Dispose();
                //printImage.Dispose();//不释放 若模板参数不对可继续打印
                //从内存中读取新保存的缩略图
                Image newImage = Image.FromStream(memoryStream);
                isPrint = true;
                return newImage;
            }
        }

        /// <summary>
        /// 获取图片类型
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        #region 解析网页代码获取图片 目前客户提供的只有一张 暂时不用
        //定义num记录listBox2中获取到的图片URL个数
        //public int num = 0;
        ////点击"获取"按钮
        //private void button2_Click(object sender, EventArgs e)
        //{    
        //    HtmlElement html = webBrowser1.Document.Body;      //定义HTML元素    
        //    string str = html.OuterHtml;                       //获取当前元素的HTML代码    
        //    MatchCollection matches;                           //定义正则表达式匹配集合    
        //    //清空    
        //    listBox1.Items.Clear();    
        //    listBox2.Items.Clear();    //获取    
        //    try    
        //    {                  
        //        //正则表达式获取<a href></a>内容url        
        //        matches = Regex.Matches(str, "<a href=/"([^/"]*?)/".*?>(.*?)</a>", RegexOptions.IgnoreCase);        
        //        foreach (Match match in matches)        
        //        {            
        //            listBox1.Items.Add(match.Value.ToString());             
        //        }        
        //        //正则表达式获取<img src=>图片url        
        //        matches = Regex.Matches(str, @"<img/b[^<>]*?/bsrc[/s/t/r/n]*=[/s/t/r/n]*[""']?[/s/t/r/n]*(?<imgUrl>[^/s/t/r/n""'<>]*)[^<>]*?/?[/s/t/r/n]*>", 
        //            RegexOptions.IgnoreCase);        
        //        foreach (Match match in matches)        
        //        {            
        //            listBox2.Items.Add(match.Value.ToString());        
        //        }        
        //        //记录图片总数       
        //        num = listBox2.Items.Count;    
        //    }    
        //    catch (Exception msg)    
        //    {        MessageBox.Show(msg.Message);    //异常处理    
        //    }
        //}


        //private void button3_Click(object sender, EventArgs e)
        //{    
        //    string imgsrc = string.Empty;             //定义    //循环下载    
        //    for (int j = 0; j < num; j++)    
        //    {        
        //        string content = listBox2.Items[j].ToString();    //获取图片url        
        //        Regex reg = new Regex(@"<img.*?src=""(?<src>[^""]*)""[^>]*>", RegexOptions.IgnoreCase);        
        //        MatchCollection mc = reg.Matches(content);        //设定要查找的字符串        
        //        foreach (Match m in mc)        
        //        {                            
        //            try            
        //            {                
        //                WebRequest request = WebRequest.Create(m.Groups["src"].Value);//图片src内容                
        //                WebResponse response = request.GetResponse();                //文件流获取图片操作                
        //                Stream reader = response.GetResponseStream();                
        //                string path = "E://" + j.ToString() + ".jpg";        //图片路径命名                 
        //                FileStream writer = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);                
        //                byte[] buff = new byte[512];                
        //                int c = 0;                                           //实际读取的字节数                  
        //                while ((c = reader.Read(buff, 0, buff.Length)) > 0)                
        //                {                    
        //                    writer.Write(buff, 0, c);                
        //                }                //释放资源                
        //                writer.Close();               
        //                writer.Dispose();               
        //                reader.Close();               
        //                reader.Dispose();                
        //                response.Close();                //下载成功                
        //                listBox2.Items.Add(path + ":图片保存成功!");             
        //            }            
        //            catch (Exception msg)            
        //            {                
        //                MessageBox.Show(msg.Message);            
        //            }        
        //        }    
        //    }
        //}
        #endregion
    }
}
