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

namespace WindowsSetteings
{
    public partial class AudioDeviceButton : System.Windows.Forms.Button
    {
        private AudioDevice audioDevice;
        private Color defaultBackColor = Color.Gray;
        private Color activeBackColor = Color.AliceBlue;
        public AudioDeviceButton()
        {
            InitializeComponent();
        }

        public AudioDeviceButton(AudioDevice device)
        {
            this.audioDevice = device;
            this.ColorChange();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnClick(EventArgs e)
        {
            try
            {
                AudioDeviceManager.Set_AudioDevice(this.audioDevice);
                this.audioDevice.Default = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("オーディオの設定に失敗しました。\nこのボタンを一時的にロックします。");
                this.Enabled = false;
            }
            this.ColorChange();
        }

        protected override void OnCursorChanged(EventArgs e)
        {
            base.OnCursorChanged(e);
            ColorChange();
        }

        protected void ColorChange()
        {
            if (this.audioDevice.Default)
            {
                this.BackColor = activeBackColor;
            }
            else
            {
                this.BackColor = defaultBackColor;
            }
        }
    }
}
