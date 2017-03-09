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
            setPrintCounts(Convert.ToInt32(textBox1.Text));
            if (getPrintCounts() == 0 || getPrintCounts() > 10000)
            {
                MessageBox.Show("超出打印份数的范围");
            }
            else
            {
                if (getPrintType() == null || getPrintColor() == null)
                {
                    MessageBox.Show("请选择单双面和黑白、彩印");
                }
                else
                {
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
            this.Close();
        }

        public int getPrintCounts()
        {
            return this.printCounts;
        }

        private void single_Click(object sender, EventArgs e)
        {
            setPrintType("单面");
            single.BackgroundImage = Properties.Resources.单面灰;
            doub.BackgroundImage = Properties.Resources.双面;
        }

        private void doub_Click(object sender, EventArgs e)
        {
            setPrintType("双面");
            single.BackgroundImage = Properties.Resources.单面;
            doub.BackgroundImage = Properties.Resources.双面灰;
        }

        private void pure_Click(object sender, EventArgs e)
        {
            setPrintColor("黑白");
            pure.BackgroundImage = Properties.Resources.黑白灰;
            coloful.BackgroundImage = Properties.Resources.彩色;
        }

        private void coloful_Click(object sender, EventArgs e)
        {
            setPrintColor("彩色");
            pure.BackgroundImage = Properties.Resources.黑白;
            coloful.BackgroundImage = Properties.Resources.彩色灰;
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

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
