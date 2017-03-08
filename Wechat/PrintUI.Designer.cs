namespace Wechat
{
    partial class PrintUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.single = new System.Windows.Forms.Button();
            this.pure = new System.Windows.Forms.Button();
            this.coloful = new System.Windows.Forms.Button();
            this.doub = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Wechat.Properties.Resources.确定;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(147, 328);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 36);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Wechat.Properties.Resources.back1;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 45);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // single
            // 
            this.single.BackgroundImage = global::Wechat.Properties.Resources.单面;
            this.single.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.single.FlatAppearance.BorderSize = 0;
            this.single.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.single.Location = new System.Drawing.Point(147, 48);
            this.single.Name = "single";
            this.single.Size = new System.Drawing.Size(88, 102);
            this.single.TabIndex = 8;
            this.single.UseVisualStyleBackColor = true;
            this.single.Click += new System.EventHandler(this.single_Click);
            // 
            // pure
            // 
            this.pure.BackgroundImage = global::Wechat.Properties.Resources.黑白;
            this.pure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pure.FlatAppearance.BorderSize = 0;
            this.pure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pure.Location = new System.Drawing.Point(147, 161);
            this.pure.Name = "pure";
            this.pure.Size = new System.Drawing.Size(88, 102);
            this.pure.TabIndex = 10;
            this.pure.UseVisualStyleBackColor = true;
            this.pure.Click += new System.EventHandler(this.pure_Click);
            // 
            // coloful
            // 
            this.coloful.BackgroundImage = global::Wechat.Properties.Resources.彩色;
            this.coloful.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.coloful.FlatAppearance.BorderSize = 0;
            this.coloful.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.coloful.Location = new System.Drawing.Point(249, 161);
            this.coloful.Name = "coloful";
            this.coloful.Size = new System.Drawing.Size(88, 102);
            this.coloful.TabIndex = 11;
            this.coloful.UseVisualStyleBackColor = true;
            this.coloful.Click += new System.EventHandler(this.coloful_Click);
            // 
            // doub
            // 
            this.doub.BackgroundImage = global::Wechat.Properties.Resources.双面;
            this.doub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.doub.FlatAppearance.BorderSize = 0;
            this.doub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doub.Location = new System.Drawing.Point(248, 48);
            this.doub.Name = "doub";
            this.doub.Size = new System.Drawing.Size(88, 102);
            this.doub.TabIndex = 12;
            this.doub.UseVisualStyleBackColor = true;
            this.doub.Click += new System.EventHandler(this.doub_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("黑体", 17F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.textBox1.Location = new System.Drawing.Point(229, 282);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 26);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.KeyPress += TextBox1_KeyPress;
            // 
            // PrintUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Wechat.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.doub);
            this.Controls.Add(this.coloful);
            this.Controls.Add(this.pure);
            this.Controls.Add(this.single);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PrintUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印界面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button single;
        private System.Windows.Forms.Button @double;
        private System.Windows.Forms.Button pure;
        private System.Windows.Forms.Button coloful;
        private System.Windows.Forms.Button doub;
        private System.Windows.Forms.TextBox textBox1;
    }
}