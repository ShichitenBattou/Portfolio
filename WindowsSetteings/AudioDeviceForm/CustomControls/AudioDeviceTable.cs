using AudioDeviceSetting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioDeviceForm
{
    public partial class AudioDeviceTable : UserControl
    {
        #region 変数・プロパティ
        private AudioDeviceCollection _audioDevices;
        private AudioDeviceManager aDM;

        /// <summary>
        /// AudioDeviceManagerを設定、更新時にボタンも更新
        /// </summary>
        public AudioDeviceManager AudioDeviceManager
        {
            set
            {
                this.aDM = value;
                if (this.aDM != null) SetDeviceCollection(this._deviceType);
            }
            get { return this.aDM; }
        }

        private DeviceType _deviceType = DeviceType.Playback;
        /// <summary>
        /// DeviceTypeを設定、更新時にボタンも更新
        /// </summary>
        public DeviceType DeviceType
        {
            set
            {
                _deviceType = value;
                if (this.aDM != null) SetDeviceCollection(value);
            }
            get { return _deviceType; }
        }
        #endregion

        #region コンストラクタ
        public AudioDeviceTable()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// 管理するコレクションを設定 + ボタンを追加
        /// </summary>
        /// <param name="type"></param>
        private void SetDeviceCollection(DeviceType type)
        {
            switch (type)
            {
                case DeviceType.Playback:
                    _audioDevices = this.aDM.PlaybackAudioDevices;
                    fillButtons(this.aDM.PlaybackAudioDevices);
                    break;
                case DeviceType.Recording:
                    _audioDevices = this.aDM.RecordingAudioDevices;
                    fillButtons(this.aDM.RecordingAudioDevices);
                    break;
                default:
                    break;
            }
        }

        public AudioDeviceTable(AudioDeviceCollection audioDeviceCollection)
        {
            this._audioDevices = audioDeviceCollection;
            fillButtons(this._audioDevices);
        }

        private void fillButtons(AudioDeviceCollection audioDevices)
        {
            this.tableLayoutPanel1.ColumnCount = audioDevices.Count();
            this.tableLayoutPanel1.ColumnStyles.Clear();
            for (int i = 0; i < audioDevices.Count(); i++)
            {
                AudioDeviceButton button = new AudioDeviceButton(audioDevices[i]);
                button.Text = audioDevices[i].Name;
                button.Dock = DockStyle.Fill;
                button.Visible = true;
                button.Click += AudioDeviceButtonClick;
                button.Margin = new Padding(1, 1, 1, 1);
                this.tableLayoutPanel1.Controls.Add(button, i, 0);
                ColumnStyle columnStyle = new ColumnStyle(SizeType.Percent, 100);
                this.tableLayoutPanel1.ColumnStyles.Add(columnStyle);
            }
        }

        private void AudioDeviceButtonClick(object sender, EventArgs e)
        {
            AudioDeviceButton deviceButton = (AudioDeviceButton)sender;
            aDM.Change_Device(deviceButton.audioDevice);
            AllStateCheck();
        }

        protected void AllStateCheck()
        {
            AudioDeviceButton deviceButton;
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control.GetType() != typeof(AudioDeviceButton)) return;
                deviceButton = (AudioDeviceButton)control;
                deviceButton.ColorChange();
            }
        }
    }
}
