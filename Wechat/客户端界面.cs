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
        int  sum = 0;//总页数
        string K = null;
        int []pages =new int[10]; //浏览文件的页数
        string path1=null; //浏览文件的路径
        string filename1=null;//浏览文件的名称
        string datatime1=null;//系统当前时间
        int i = 0;//用了遍历pages
        private void btn1_Click(object sender, EventArgs e)
        {

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                 path1 = this.openFileDialog1.FileName;
                 filename1 = System.IO.Path.GetFileName(path1);
                datatime1 = (DateTime.Now.ToString());
                K = path1;
                //选择文件后，用openFileDialog1的FileName属性获取文件的绝对路径
                ListViewItem lvi = new ListViewItem();

                lvi.Text = filename1;
                //lvi.SubItems.Add(path);
                lvi.SubItems.Add(datatime1);
                this.listView1.Items.Add(lvi);
                this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。


                Microsoft.Office.Interop.Word.Application myWordApp = new Microsoft.Office.Interop.Word.Application();
                myWordApp.Visible = false;
                object oMissing = System.Reflection.Missing.Value;
                object filePath = path1; //这里是Word文件的路径
                                     //打开文件
                Document myWordDoc = myWordApp.Documents.Open(
                    ref filePath, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                //下面是取得打开文件的页数
                 pages[i] = myWordDoc.ComputeStatistics(WdStatistic.wdStatisticPages, ref oMissing);
                sum += pages[i];
                
              //  Console.WriteLine(pages);
                //this.richTextBox1 = myWordDoc.Content.Text;
                //关闭文件
                myWordDoc.Close(ref oMissing, ref oMissing, ref oMissing);
                myWordApp.Quit(ref oMissing, ref oMissing, ref oMissing);
                //  textBox1.Text = page;
                i++;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //不现实调用程序窗口
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.CreateNoWindow = true;
            //采用系统操作系统自动识别的模式
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = path1;
           // label3.Text = K;
            p.StartInfo.Verb = "open";
            p.Start();
        }

        //设置总页数
        private void setMessage(int sum)
        {
            this.sum = sum;
        }
        //获取总页数（为后面的界面传递使用）
        public int getMessage()
        {
            return sum;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("请浏览你所需要打印的文件。");
            }
            else
            {
                打印界面 print = new 打印界面();
                this.setMessage(sum);
                print.set(this.getMessage());   //传递word的页数
                print.Show();
                this.Hide();
            }
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

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            listView1.MultiSelect = false;
            //鼠标右击
            if (e.Button == MouseButtons.Right)
            {
                //filesList.ContextMenuStrip = contextMenuStrip1;
                //选中列表中数据才显示 空白处不显示
                String fileName = listView1.SelectedItems[0].Text; //获取选中文件名
                System.Drawing.Point p = new System.Drawing.Point(e.X, e.Y);
                contextMenuStrip1.Show(listView1, p);
            }
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //不现实调用程序窗口
            if (path1 != null)
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.CreateNoWindow = true;
                //采用系统操作系统自动识别的模式
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.FileName = path1;
                // label3.Text = K;
                p.StartInfo.Verb = "open";
                p.Start();
            }
            else
            {
                MessageBox.Show("没有文件，不能打开。");
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int Index = 0;
            if (this.listView1.SelectedItems.Count > 0)//判断listview有被选中项
            {
                Index = this.listView1.SelectedItems[0].Index;//取当前选中项的index,SelectedItems[0]这必须为0
              
                listView1.Items[Index].Remove();
                path1 = null;
                sum -= pages[Index];

           
           

            }
        }
    }
}
