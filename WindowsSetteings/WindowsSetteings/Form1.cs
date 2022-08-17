using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioDeviceSetting;

namespace WindowsSetteings
{
    public partial class Form1 : Form
    {
        AudioDeviceCollection audioDevices;
        public Form1()
        {
            InitializeComponent();
            //tableLayoutPanelの初期化
            this.tableLayoutPanel1.ColumnCount = 0;
            //AudioDevicesを取得
            this.audioDevices = AudioDeviceManager.Get_AllAudioDevices();
            this.tableLayoutPanel1.ColumnCount = this.audioDevices.Count();
            tableLayoutPanel1.ColumnStyles.Clear();
            for (int i = 0; i < this.audioDevices.Count(); i++)
            {
                AudioDeviceButton button = new AudioDeviceButton(this.audioDevices[i]);
                button.Text = this.audioDevices[i].Name;
                button.Dock = DockStyle.Fill;
                button.Visible = true;
                tableLayoutPanel1.Controls.Add(button, i, 0);
                ColumnStyle columnStyle = new ColumnStyle(SizeType.Percent,100);
                tableLayoutPanel1.ColumnStyles.Add(columnStyle);
            }
            //画面右下で表示
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                workingArea.Bottom - Size.Height);

            tabControl1_Selected(tabPlayback, new TabControlEventArgs(tabPlayback,tabPlayback.ImageIndex,TabControlAction.Selected));
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            this.Text = e.TabPage.Text;
        }
    }
}
