using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CA310_410_Optical_Tool
{
   public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;
            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
               {
                    case Keys.Escape:
                        this.WindowState = FormWindowState.Normal;
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                        break;
                    case Keys.F12:
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;// 邊框設定 None
                        this.WindowState = FormWindowState.Maximized;// 最大化
                        break;
                }
            }
            return false;
        }
        public void f_ChangeColor(int rr, int gg, int bb)
        {
                if (rr < 0 || rr > 255)
                {
                    rr = 255;
                }
                if (gg < 0 || gg > 255)
                {
                    gg = 255;
                }
                if (bb < 0 || bb > 255)
                {
                    bb = 255;
                }
                pictureBox1.BackColor = System.Drawing.Color.FromArgb(rr, gg, bb);
                Application.DoEvents();
        }
        private void Form2_Resize(object sender)
        {
            int xw, yw;
            yw = this.Height;
            xw = this.Width;
            pictureBox1.Left = 0;
            pictureBox1.Top = 0;
            pictureBox1.Width = xw;
            pictureBox1.Height = yw;
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fullScreenToolStripMenuItem.Text=="Full Screen")
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;// 邊框設定 None
                this.WindowState = FormWindowState.Maximized;// 最大化
                this.fullScreenToolStripMenuItem.Text = "Reduction Screen";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.fullScreenToolStripMenuItem.Text = "Full Screen";
            }
        }
    }
}
