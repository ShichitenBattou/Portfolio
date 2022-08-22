using AudioDeviceSetting;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AudioDeviceForm
{
    public partial class AudioDeviceButton : System.Windows.Forms.Button
    {
        public AudioDevice audioDevice;
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

        protected override void OnCursorChanged(EventArgs e)
        {
            base.OnCursorChanged(e);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            ColorChange();
        }

        public void ColorChange()
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
