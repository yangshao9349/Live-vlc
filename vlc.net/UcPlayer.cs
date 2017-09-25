using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace vlc.net
{
    public partial class UcPlayer : UserControl
    {
       

        public UcPlayer()
        {
            InitializeComponent();
            player.SetRenderWindow((int)plMain.Handle);
        }

        public UcPlayer(string Url)
        {
            InitializeComponent();
            this.Url = Url;
            player.SetRenderWindow((int)plMain.Handle);
            Play(Url);
        }


        #region 私有变量

        static string pluginPath = System.Environment.CurrentDirectory + "\\plugins\\";
        VlcPlayer player = new VlcPlayer(pluginPath);

        #endregion

        #region 属性

        public String Url { get; set; }

        public int Vol
        {
            get
            {
                return player.GetVolume();;
            }
            set
            {
                player.SetPlayTime(value);
            }
        }

        #endregion

        #region 方法

        public void SetPlayTime(double seekTime)
        {
            player.SetPlayTime(seekTime);
        }

        public double GetPlayTime()
        {
            return player.GetPlayTime();
        }

        public void Play(string url)
        {
            player.PlayFile(url);
        }

        /// <summary>
        /// 调用此方法建议捕获异常，当未初始化URL的时候会捕捉到异常
        /// </summary>
        public void Play()
        {
            if (!string.IsNullOrEmpty(Url))
            {
                player.PlayFile(Url);
            }
            else
            {
                throw new Exception("未设置URL");
            }
        }

        public void Pause()
        {
            player.Pause();
        }

        public void Stop()
        {
            player.Stop();
        }

        #endregion
    }
}
