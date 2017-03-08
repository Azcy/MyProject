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
   
    public partial class PrintUI : Form
    {   private int pages=0;
        private string filePath;
        public PrintUI()
        {
            InitializeComponent();
        }
       
        public void setPages(int totalPages)
        {
            this.pages = totalPages;
        }
        public int getPages()
        {
            return this.pages;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
            {
                MessageBox.Show("您还有信息未填写完，请仔细填写！");
            }
            else
            {
                this.setPrintType(this.comboBox1.Text);
                this.setPrintColor(this.comboBox2.Text);
                this.setPrintCounts(Convert.ToInt32(this.comboBox3.Text));
                NativePayUI nativePayUI = new NativePayUI();
                nativePayUI.FilePath = FilePath;
                nativePayUI.setPrintType(this.getPrintType());
                nativePayUI.setPrintColor(this.getPrintColor());
                nativePayUI.setPrintCounts(this.getPrintCounts());
                nativePayUI.setPages(this.getPages() * this.getPrintCounts());
                nativePayUI.Show();
                this.Hide();
            }
        }
        string printType = null, printColor = null;
        int printCounts = 0;
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

        private void button2_Click(object sender, EventArgs e)
        {
            new ClientUI().Show();
            this.Hide();
        }

        public int getPrintCounts()
        {
            return this.printCounts;
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
