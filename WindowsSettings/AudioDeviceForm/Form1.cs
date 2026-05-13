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

namespace AudioDeviceForm
{
    public partial class Form1 : Form
    {
        AudioDeviceManager aDM;
        private AudioDeviceCollection playbackAudioDevices { get { return aDM.PlaybackAudioDevices; } }
        private AudioDeviceCollection recordingAudioDevices { get { return aDM.RecordingAudioDevices; } }

        public Form1()
        {
            InitializeComponent();
            //tableLayoutPanelの初期化
            //AudioDevicesを取得
            this.aDM = AudioDeviceManager.Get_Instance();

            this.audioDeviceTable1.AudioDeviceManager = this.aDM;
            this.audioDeviceTable2.AudioDeviceManager = this.aDM;

            this.ControlBox = false;
            this.Text = string.Empty;

            foreach(Control control in tabControl1.TabPages)
            {
                control.BackColor = Color.Maroon;
            }

            //画面右下で表示
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                workingArea.Bottom - Size.Height);

            //tabControl1_Selected(tabPlayback, new TabControlEventArgs(tabPlayback,tabPlayback.ImageIndex,TabControlAction.Selected));
        }

        //private void tabControl1_Selected(object sender, TabControlEventArgs e)
        //{
        //    this.Text = e.TabPage.Text;
        //}

        private void AudioDeviceButtonClick(object sender, EventArgs e)
        {
            AudioDeviceButton deviceButton = (AudioDeviceButton)sender;
            aDM.Change_Device(deviceButton.audioDevice);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkBox1.Checked;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
