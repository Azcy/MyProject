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
    public partial class WelcomeUI : Form
    {
        public WelcomeUI()
        {
            InitializeComponent();
        }
        //跳转打印界面
        private void button1_Click(object sender, EventArgs e)
        {
            new ClientUI().Show();
            this.Hide();
        }
        //退出使用
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
