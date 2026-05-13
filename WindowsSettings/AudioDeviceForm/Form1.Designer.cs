
namespace AudioDeviceForm
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPlayback = new System.Windows.Forms.TabPage();
            this.audioDeviceTable1 = new AudioDeviceForm.AudioDeviceTable();
            this.tabRecording = new System.Windows.Forms.TabPage();
            this.audioDeviceTable2 = new AudioDeviceForm.AudioDeviceTable();
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPlayback.SuspendLayout();
            this.tabRecording.SuspendLayout();
            this.tabSetting.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPlayback);
            this.tabControl1.Controls.Add(this.tabRecording);
            this.tabControl1.Controls.Add(this.tabSetting);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(465, 97);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPlayback
            // 
            this.tabPlayback.Controls.Add(this.audioDeviceTable1);
            this.tabPlayback.Location = new System.Drawing.Point(4, 22);
            this.tabPlayback.Name = "tabPlayback";
            this.tabPlayback.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlayback.Size = new System.Drawing.Size(457, 71);
            this.tabPlayback.TabIndex = 0;
            this.tabPlayback.Text = "スピーカー";
            this.tabPlayback.UseVisualStyleBackColor = true;
            // 
            // audioDeviceTable1
            // 
            this.audioDeviceTable1.AudioDeviceManager = null;
            this.audioDeviceTable1.BackColor = System.Drawing.Color.Maroon;
            this.audioDeviceTable1.DeviceType = AudioDeviceSetting.DeviceType.Playback;
            this.audioDeviceTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.audioDeviceTable1.Location = new System.Drawing.Point(3, 3);
            this.audioDeviceTable1.Margin = new System.Windows.Forms.Padding(0);
            this.audioDeviceTable1.Name = "audioDeviceTable1";
            this.audioDeviceTable1.Size = new System.Drawing.Size(451, 65);
            this.audioDeviceTable1.TabIndex = 0;
            // 
            // tabRecording
            // 
            this.tabRecording.Controls.Add(this.audioDeviceTable2);
            this.tabRecording.Location = new System.Drawing.Point(4, 22);
            this.tabRecording.Name = "tabRecording";
            this.tabRecording.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecording.Size = new System.Drawing.Size(457, 71);
            this.tabRecording.TabIndex = 1;
            this.tabRecording.Text = "マイク";
            this.tabRecording.UseVisualStyleBackColor = true;
            // 
            // audioDeviceTable2
            // 
            this.audioDeviceTable2.AudioDeviceManager = null;
            this.audioDeviceTable2.DeviceType = AudioDeviceSetting.DeviceType.Recording;
            this.audioDeviceTable2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.audioDeviceTable2.Location = new System.Drawing.Point(3, 3);
            this.audioDeviceTable2.Name = "audioDeviceTable2";
            this.audioDeviceTable2.Size = new System.Drawing.Size(451, 65);
            this.audioDeviceTable2.TabIndex = 0;
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.panel1);
            this.tabSetting.Location = new System.Drawing.Point(4, 22);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Size = new System.Drawing.Size(457, 71);
            this.tabSetting.TabIndex = 2;
            this.tabSetting.Text = "設定";
            this.tabSetting.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(5, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(186, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "他ウインドウで隠れないようにする。";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 71);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(5, 25);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "画面を閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(465, 97);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(481, 136);
            this.MinimumSize = new System.Drawing.Size(481, 136);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.TopMost = true;
            this.tabControl1.ResumeLayout(false);
            this.tabPlayback.ResumeLayout(false);
            this.tabRecording.ResumeLayout(false);
            this.tabSetting.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPlayback;
        private System.Windows.Forms.TabPage tabRecording;
        private AudioDeviceTable audioDeviceTable1;
        private AudioDeviceTable audioDeviceTable2;
        private System.Windows.Forms.TabPage tabSetting;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
    }
}

