using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wechat
{
    public partial class 客户端界面 : Form
    {
        public 客户端界面()
        {
            InitializeComponent();
        }
        int  sum = 0;
        string K = null;
        int pages = 0;
        private void btn1_Click(object sender, EventArgs e)
        {
            //显示选择文件窗口
            this.openFileDialog1.ShowDialog();
            //获取文件绝对路径文件名
            string fileName = this.openFileDialog1.FileName;
            //返回指定路径字符串的文件名和扩展名
            string exFileName = System.IO.Path.GetFileName(fileName);
            string fileTime = (DateTime.Now.ToString());
            K = fileName;
            //选择文件后，用openFileDialog1的FileName属性获取文件的绝对路径
            ListViewItem lvi = new ListViewItem();

            lvi.Text = exFileName;
            //lvi.SubItems.Add(a);
            lvi.SubItems.Add(fileTime);
            this.listView1.Items.Add(lvi);
            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。


            Microsoft.Office.Interop.Word.Application myWordApp = new Microsoft.Office.Interop.Word.Application();
            myWordApp.Visible = false;
            object oMissing = System.Reflection.Missing.Value;
            object filePath = fileName; //这里是Word文件的路径
                                 //打开文件
            Document myWordDoc = myWordApp.Documents.Open(
                ref filePath, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            //下面是取得打开文件的页数
            int pages1 = myWordDoc.ComputeStatistics(WdStatistic.wdStatisticPages, ref oMissing);
            sum += pages1;
            string page = sum + "";
            Console.WriteLine(pages1);
            //this.richTextBox1 = myWordDoc.Content.Text;
            //关闭文件
            myWordDoc.Close(ref oMissing, ref oMissing, ref oMissing);
            myWordApp.Quit(ref oMissing, ref oMissing, ref oMissing);
          //  textBox1.Text = page;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //不现实调用程序窗口
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.CreateNoWindow = true;
            //采用系统操作系统自动识别的模式
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = K;
           // label3.Text = K;
            p.StartInfo.Verb = "open";
            p.Start();
        }
        private void setMessage(int sum)
        {
            this.pages = sum;
        }
        public int getMessage()
        {
            return pages;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            打印界面 print = new 打印界面();
            this.setMessage(sum);
            print.set(this.getMessage());
            print.Show();
            this.Hide();
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 客户端界面_Load(object sender, EventArgs e)
        {
            //button3.Enabled = false;
            this.listView1.Columns.Add("文件名", 220, HorizontalAlignment.Center);
           
            this.listView1.Columns.Add("时间", 210, HorizontalAlignment.Center);
            this.listView1.BeginUpdate();
            this.listView1.EndUpdate();

        }
    }
}
