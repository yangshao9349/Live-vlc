using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace vlc.net
{
    public partial class Main : Form
    {
        private List<VlcPlayer> list;

        private bool is_playinig_;
        public string[] rtmp = new string[4] { "rtmp://101.200.81.145/hls/b002", "rtmp://58.222.20.131/hls/a3", "rtmp://58.222.20.131/hls/ccdb", "rtmp://58.222.20.131/hls/ce" };

        public Main()
        {
            InitializeComponent();





            init();
           

          
        }
        private void init() {
            PictureBox pic = new PictureBox();
            Bitmap b = new Bitmap(Application.StartupPath + @"//images/video.png");
            pic.Image = b;
            pic.SizeMode = PictureBoxSizeMode.AutoSize;
            pic.Width = 200;
           
           

            int height = 260;
            list = new List<VlcPlayer>();
            string pluginPath = System.Environment.CurrentDirectory + "\\plugins\\";
            int x = 0;
            int y = 0;
            int k = 0;
            for (int i = 0; i < 4; i++)
            {
             
                if (i % 2 == 0)
                {
                    x = 0;
                    if (i != 0) {
                        y = y + height;
                        if (k > 0)
                        {
                            x = x + this.Width / 2;
                        }
                        k++;
                    }
                
                 
                }
                else {
                   
                    x = this.Width / 2;
                }

                BackgroundPanel panel = new BackgroundPanel();
                panel.Location = new Point(x, y);
           
                
                panel.Width = this.Width / 2;
                panel.Height = height;
             
                panel.BackgroundImage = b;
                panel.BackgroundImageLayout = ImageLayout.Center;
              

                VlcPlayer vlc_player_ = new VlcPlayer(pluginPath);
                IntPtr render_wnd = panel.Handle;
                vlc_player_.SetRenderWindow((int)render_wnd);


               


                list.Add(vlc_player_);

                this.Controls.Add(panel);


            }
            
               
              
             
           
            this.ResumeLayout(false);
          
        }
        private void btnStart_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < list.Count; i++)
            {
                list[i].PlayFile(rtmp[i]);
            }
           
         
          
           
            is_playinig_ = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (is_playinig_)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Stop();
                }
                is_playinig_ = false;
            }
        }



        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (is_playinig_)
            {
               // vlc_player_.SetPlayTime(trackBar1.Value);
               // trackBar1.Value = (int)vlc_player_.GetPlayTime();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
