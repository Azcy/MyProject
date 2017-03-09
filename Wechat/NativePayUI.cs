using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;
using WxPayAPI;
using System.Threading;
namespace Wechat
{
    public partial class NativePayUI : Form
    {
        private int pages = 1;
        private string printType = null, printColor = null;
        private string filePath;
        int printCounts = 0;
        Thread queryOrder;
        bool isNotPay = false;
        WxPayData queryOrderInput = new WxPayData();
        WxPayData result;

        private string out_trade_no1 = null;//用来接收商品号

        public NativePayUI()
        {
            InitializeComponent();
        }
        private void ThreadMethod()
        {
            while (!isNotPay)
            {
                queryOrderInput.SetValue("out_trade_no", out_trade_no1);
                result = WxPayApi.OrderQuery(queryOrderInput);

                Thread.Sleep(1000);
                if (result.GetValue("return_code").ToString() == "SUCCESS" && result.GetValue("result_code").ToString() == "SUCCESS")
                {
                    //支付成功
                    //------------暂时未写付款后的操作-------------------
                    if (result.GetValue("trade_state").ToString() == "SUCCESS")
                    {
                        isNotPay = true;
                        if (printFile(FilePath))
                        {
                            MessageBox.Show("打印成功！");
                        }
                        else
                        {
                            MessageBox.Show("打印失败！");
                        }
                    }
                }
            }
        }
        //调用打印机打印文档
        public bool printFile(string path)
        {
            //不现实调用程序窗口
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.CreateNoWindow = true;
            //采用系统操作系统自动识别的模式
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = path;
            // label3.Text = K;
            p.StartInfo.Verb = "print";
            if (p.Start())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void NativePayUI_Load(object sender, EventArgs e)
        {
            //设置label（价格、页数）的文本信息
            label1.Text = "共" + getpages() + "页";
            label3.Text = "需付" + getpages() * 0.15 + "元";
            NativePay nativePay = new NativePay();
            //生成扫码支付模式二url
            //page * 15 为了测试改成1
            string url2 = nativePay.GetPayUrl(/*getpages()*15*/1, "123456789", "商品名称", "商品标记", "商品描述");


            out_trade_no1 = nativePay.getout_trade_no();
            //初始化二维码生成工具
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            qrCodeEncoder.QRCodeVersion = 0;
            qrCodeEncoder.QRCodeScale = 4;

            //将字符串生成二维码图片
            pictureBox1.Image = qrCodeEncoder.Encode(url2, Encoding.Default);
            //回调结果

            queryOrder = new Thread(new ThreadStart(ThreadMethod));
            queryOrder.Start();
        }
        public void setPages(int pages)
        {
            this.pages = pages;
        }
        public int getpages()
        {
            return this.pages;
        }
        public void setPrintType(string type)
        {
            this.printType = type;
        }
        public string getPrintType()
        {
            return this.printType;
        }
        public void setPrintColor(string color)
        {
            this.printColor = color;
        }
        public string getPrintColor()
        {
            return this.printColor;
        }

        public void setPrintCounts(int counts)
        {
            this.printCounts = counts;
        }

        public int getPrintCounts()
        {
            return this.printCounts;
        }

        private void back_Click(object sender, EventArgs e)
        {
            //关闭查单线程
            queryOrder.Abort();
            new ClientUI().Show();
            this.Close();
        }

        //文件路径属性
        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                filePath = value;
            }
        }
    }
}
