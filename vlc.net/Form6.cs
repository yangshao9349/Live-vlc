using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vlc.net
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            Ini();
        }


        UcPlayer player1 = new UcPlayer("rtmp://192.168.12.201/live/1");
        UcPlayer player2 = new UcPlayer("rtmp://192.168.12.201/live/2");

        private void Ini()
        {
            foreach (TabPage page in tabControl1.TabPages)
            {
                if (page.Text == "tabPage1")
                {
                    player1.Dock = DockStyle.Fill;
                    page.Controls.Add(player1);
                    player1.BringToFront();
                }
                else
                {
                    player2.Dock = DockStyle.Fill;
                    page.Controls.Add(player2);
                    player2.BringToFront();
                }
            }
        }
    }
}
