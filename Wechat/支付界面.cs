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

namespace Wechat
{
    public partial class 支付界面 : Form
    {
        int page = 0;
        private string a = null, b = null;
        int c = 0;
        public 支付界面()
        {
            InitializeComponent();
        }

        private void 支付界面_Load(object sender, EventArgs e)
        {
            NativePay nativePay = new NativePay();
            //生成扫码支付模式二url
            if (page == 0)
            {
                MessageBox.Show("请先加入你想要打印的文件。");
            }
            else
            {


                string url2 = nativePay.GetPayUrl(page * 15, "123456789", "商品名称", "商品标记", "商品描述");
                //初始化二维码生成工具
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                qrCodeEncoder.QRCodeVersion = 0;
                qrCodeEncoder.QRCodeScale = 4;

                //将字符串生成二维码图片
                pictureBox1.Image = qrCodeEncoder.Encode(url2, Encoding.Default);

                //回调结果
                //NativeNotify notify = new NativeNotify(this);


                //if (nativePay.Getresult(page * 15, "123456789", "商品名称", "商品标记", "商品描述"))
                // {
                //    MessageBox.Show("");
                // }

                // if (nativePay.GetValue("return_code").ToString() == "SUCCESS" &&
                //nativePay.GetValue("result_code").ToString() == "SUCCESS")
                //  Boolean result1 = nativePay.Getresult(sum * 15, "123456789", "商品名称", "商品标记", "商品描述");
                // if (result1)

                //  if(data.GetValue("trade_state").ToString()== "SUCCESS")
                //   {
                //     System.Console.WriteLine("支付成功");
                //  result = nativePay.Body;
                //MessageBox.Show(result);
                //     MessageBox.Show("支付成功");
                //  }
                //  else
                // {
                //     MessageBox.Show("支付失败");
                //  }
                //label2显示页数和价格
                label2.Text = "页数:" + page+"\n"+"总价："+page*0.15+"元";
            }
        }
        public void setpage(int sum)
        {
            this.page = sum;
        }
        public int getpage()
        {
            return this.page;
        }
        public void payset1(string a)
        {
            this.a = a;
        }
        public string payget1()
        {
            return this.a;
        }
        public void payset2(string b)
        {
            this.b = b;
        }
        public string payget2()
        {
            return this.b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        public void payset3(int c)
        {
            this.c = c;
        }
        public int payget3()
        {
            return this.c;
        }
    }
}
