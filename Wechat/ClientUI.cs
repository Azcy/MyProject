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
    public partial class ClientUI : Form
    {
        public ClientUI()
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
                //获取打开文件的名字和打开时间，用于显示在listView上
                path1 = this.openFileDialog1.FileName;
                filename1 = System.IO.Path.GetFileName(path1);
                datatime1 = (DateTime.Now.ToString());
                K = path1;
                //选择文件后，用openFileDialog1的FileName属性获取文件的绝对路径
                ListViewItem lvi = new ListViewItem();
                //将文件名字和时间显示到listView上
                lvi.Text = filename1;
                lvi.SubItems.Add(datatime1);
                this.listView1.Items.Add(lvi);
                this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。
                //开放修改按钮和下一步按钮
                button1.Enabled = true;
                button2.Enabled = true;

                Microsoft.Office.Interop.Word.Application myWordApp = new Microsoft.Office.Interop.Word.Application();
                myWordApp.Visible = false;
                object oMissing = System.Reflection.Missing.Value;
                object filePath = path1; //这里是Word文件的路径
                //打开word文档
                Document myWordDoc = myWordApp.Documents.Open(
                    ref filePath, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                //取得打开文件的页数
                pages[i] = myWordDoc.ComputeStatistics(WdStatistic.wdStatisticPages, ref oMissing);
                sum += pages[i];
                
                //关闭文件
                myWordDoc.Close(ref oMissing, ref oMissing, ref oMissing);
                myWordApp.Quit(ref oMissing, ref oMissing, ref oMissing);

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
                PrintUI print = new PrintUI();
                this.setMessage(sum);
                print.set(this.getMessage());   //传递word的页数
                print.Show();
                this.Hide();
            
        }

        private void 客户端界面_Load(object sender, EventArgs e)
        {
            this.listView1.Columns.Add("文件名", 220, HorizontalAlignment.Center);
           
            this.listView1.Columns.Add("时间", 210, HorizontalAlignment.Center);
            this.listView1.BeginUpdate();
            this.listView1.EndUpdate();
            //没加文件之前按钮不可点击
            if(this.listView1.Items.Count == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }

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
