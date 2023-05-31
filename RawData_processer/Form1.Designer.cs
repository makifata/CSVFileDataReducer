namespace RawData_processer
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
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            this.Trim_Start = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.CompressTbox = new System.Windows.Forms.TextBox();
            this.StatisticsBTN = new System.Windows.Forms.Button();
            this.InfoTbox = new System.Windows.Forms.TextBox();
            this.RDPDecimation = new System.Windows.Forms.CheckBox();
            this.TargetCbox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Panel_decimate = new System.Windows.Forms.Panel();
            this.SkipcolTbox = new System.Windows.Forms.TextBox();
            this.Panel_RDP = new System.Windows.Forms.Panel();
            this.Compress_mode = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.EpsilonTbox = new System.Windows.Forms.TextBox();
            this.Epsilon_mode = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cropbytime_cBox = new System.Windows.Forms.CheckBox();
            this.Starttime_tBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Endtime_tBox = new System.Windows.Forms.TextBox();
            this.Panel_Timecrop = new System.Windows.Forms.Panel();
            this.CHKBOX_simple = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.Panel_decimate.SuspendLayout();
            this.Panel_RDP.SuspendLayout();
            this.Panel_Timecrop.SuspendLayout();
            this.SuspendLayout();
            // 
            // Trim_Start
            // 
            this.Trim_Start.Enabled = false;
            this.Trim_Start.Location = new System.Drawing.Point(402, 357);
            this.Trim_Start.Name = "Trim_Start";
            this.Trim_Start.Size = new System.Drawing.Size(223, 62);
            this.Trim_Start.TabIndex = 0;
            this.Trim_Start.Text = "Trim it!";
            this.Trim_Start.UseVisualStyleBackColor = true;
            this.Trim_Start.Click += new System.EventHandler(this.Trim_Start_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 10);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(386, 321);
            this.textBox1.TabIndex = 1;
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(21, 83);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(190, 25);
            this.trackBar1.SmallChange = 5;
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // CompressTbox
            // 
            this.CompressTbox.Location = new System.Drawing.Point(158, 55);
            this.CompressTbox.Name = "CompressTbox";
            this.CompressTbox.Size = new System.Drawing.Size(52, 20);
            this.CompressTbox.TabIndex = 5;
            this.CompressTbox.Text = "50";
            this.CompressTbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CompressTbox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // StatisticsBTN
            // 
            this.StatisticsBTN.Enabled = false;
            this.StatisticsBTN.Location = new System.Drawing.Point(402, 317);
            this.StatisticsBTN.Name = "StatisticsBTN";
            this.StatisticsBTN.Size = new System.Drawing.Size(115, 34);
            this.StatisticsBTN.TabIndex = 8;
            this.StatisticsBTN.Text = "Statistics";
            this.StatisticsBTN.UseVisualStyleBackColor = true;
            this.StatisticsBTN.Click += new System.EventHandler(this.StatisticsBTN_Click);
            // 
            // InfoTbox
            // 
            this.InfoTbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InfoTbox.Location = new System.Drawing.Point(5, 339);
            this.InfoTbox.Multiline = true;
            this.InfoTbox.Name = "InfoTbox";
            this.InfoTbox.Size = new System.Drawing.Size(386, 80);
            this.InfoTbox.TabIndex = 9;
            // 
            // RDPDecimation
            // 
            this.RDPDecimation.AutoSize = true;
            this.RDPDecimation.Location = new System.Drawing.Point(402, 147);
            this.RDPDecimation.Name = "RDPDecimation";
            this.RDPDecimation.Size = new System.Drawing.Size(192, 17);
            this.RDPDecimation.TabIndex = 11;
            this.RDPDecimation.Text = "Ramer–Douglas–Peucker Algorithm";
            this.RDPDecimation.UseVisualStyleBackColor = true;
            this.RDPDecimation.CheckedChanged += new System.EventHandler(this.RDPDecimation_CheckedChanged);
            // 
            // TargetCbox
            // 
            this.TargetCbox.FormattingEnabled = true;
            this.TargetCbox.Location = new System.Drawing.Point(108, 8);
            this.TargetCbox.Name = "TargetCbox";
            this.TargetCbox.Size = new System.Drawing.Size(102, 21);
            this.TargetCbox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Skip_interval";
            // 
            // Panel_decimate
            // 
            this.Panel_decimate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_decimate.Controls.Add(this.SkipcolTbox);
            this.Panel_decimate.Controls.Add(this.label3);
            this.Panel_decimate.Location = new System.Drawing.Point(403, 112);
            this.Panel_decimate.Name = "Panel_decimate";
            this.Panel_decimate.Size = new System.Drawing.Size(223, 29);
            this.Panel_decimate.TabIndex = 14;
            // 
            // SkipcolTbox
            // 
            this.SkipcolTbox.Location = new System.Drawing.Point(158, 3);
            this.SkipcolTbox.Name = "SkipcolTbox";
            this.SkipcolTbox.Size = new System.Drawing.Size(52, 20);
            this.SkipcolTbox.TabIndex = 16;
            this.SkipcolTbox.Text = "10";
            this.SkipcolTbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Panel_RDP
            // 
            this.Panel_RDP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_RDP.Controls.Add(this.Compress_mode);
            this.Panel_RDP.Controls.Add(this.label4);
            this.Panel_RDP.Controls.Add(this.TargetCbox);
            this.Panel_RDP.Controls.Add(this.EpsilonTbox);
            this.Panel_RDP.Controls.Add(this.Epsilon_mode);
            this.Panel_RDP.Controls.Add(this.trackBar1);
            this.Panel_RDP.Controls.Add(this.CompressTbox);
            this.Panel_RDP.Location = new System.Drawing.Point(403, 166);
            this.Panel_RDP.Name = "Panel_RDP";
            this.Panel_RDP.Size = new System.Drawing.Size(223, 118);
            this.Panel_RDP.TabIndex = 15;
            // 
            // Compress_mode
            // 
            this.Compress_mode.AutoSize = true;
            this.Compress_mode.Checked = true;
            this.Compress_mode.Location = new System.Drawing.Point(9, 57);
            this.Compress_mode.Name = "Compress_mode";
            this.Compress_mode.Size = new System.Drawing.Size(126, 17);
            this.Compress_mode.TabIndex = 17;
            this.Compress_mode.TabStop = true;
            this.Compress_mode.Text = "Compression_rate [%]";
            this.Compress_mode.UseVisualStyleBackColor = true;
            this.Compress_mode.CheckedChanged += new System.EventHandler(this.Compress_mode_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Target column";
            // 
            // EpsilonTbox
            // 
            this.EpsilonTbox.Enabled = false;
            this.EpsilonTbox.Location = new System.Drawing.Point(158, 32);
            this.EpsilonTbox.Name = "EpsilonTbox";
            this.EpsilonTbox.Size = new System.Drawing.Size(52, 20);
            this.EpsilonTbox.TabIndex = 15;
            this.EpsilonTbox.Text = "0.01";
            this.EpsilonTbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Epsilon_mode
            // 
            this.Epsilon_mode.AutoSize = true;
            this.Epsilon_mode.Location = new System.Drawing.Point(9, 32);
            this.Epsilon_mode.Name = "Epsilon_mode";
            this.Epsilon_mode.Size = new System.Drawing.Size(92, 17);
            this.Epsilon_mode.TabIndex = 16;
            this.Epsilon_mode.Text = "Force_Epsilon";
            this.Epsilon_mode.UseVisualStyleBackColor = true;
            this.Epsilon_mode.CheckedChanged += new System.EventHandler(this.Epsilon_mode_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(5, 426);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(620, 26);
            this.progressBar1.TabIndex = 16;
            // 
            // cropbytime_cBox
            // 
            this.cropbytime_cBox.AutoSize = true;
            this.cropbytime_cBox.Location = new System.Drawing.Point(403, 12);
            this.cropbytime_cBox.Name = "cropbytime_cBox";
            this.cropbytime_cBox.Size = new System.Drawing.Size(84, 17);
            this.cropbytime_cBox.TabIndex = 17;
            this.cropbytime_cBox.Text = "Crop by time";
            this.cropbytime_cBox.UseVisualStyleBackColor = true;
            this.cropbytime_cBox.CheckedChanged += new System.EventHandler(this.cropbytime_cBox_CheckedChanged);
            // 
            // Starttime_tBox
            // 
            this.Starttime_tBox.Location = new System.Drawing.Point(108, 3);
            this.Starttime_tBox.Name = "Starttime_tBox";
            this.Starttime_tBox.Size = new System.Drawing.Size(102, 20);
            this.Starttime_tBox.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Start time [s]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "End time [s]";
            // 
            // Endtime_tBox
            // 
            this.Endtime_tBox.Location = new System.Drawing.Point(108, 28);
            this.Endtime_tBox.Name = "Endtime_tBox";
            this.Endtime_tBox.Size = new System.Drawing.Size(102, 20);
            this.Endtime_tBox.TabIndex = 21;
            // 
            // Panel_Timecrop
            // 
            this.Panel_Timecrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_Timecrop.Controls.Add(this.Endtime_tBox);
            this.Panel_Timecrop.Controls.Add(this.label2);
            this.Panel_Timecrop.Controls.Add(this.label1);
            this.Panel_Timecrop.Controls.Add(this.Starttime_tBox);
            this.Panel_Timecrop.Location = new System.Drawing.Point(403, 32);
            this.Panel_Timecrop.Name = "Panel_Timecrop";
            this.Panel_Timecrop.Size = new System.Drawing.Size(223, 55);
            this.Panel_Timecrop.TabIndex = 22;
            // 
            // CHKBOX_simple
            // 
            this.CHKBOX_simple.AutoSize = true;
            this.CHKBOX_simple.Location = new System.Drawing.Point(402, 92);
            this.CHKBOX_simple.Name = "CHKBOX_simple";
            this.CHKBOX_simple.Size = new System.Drawing.Size(110, 17);
            this.CHKBOX_simple.TabIndex = 23;
            this.CHKBOX_simple.Text = "SimpleDecimation";
            this.CHKBOX_simple.UseVisualStyleBackColor = true;
            this.CHKBOX_simple.CheckedChanged += new System.EventHandler(this.CHKBOX_simple_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(402, 290);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 17);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Crop by time";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 460);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.CHKBOX_simple);
            this.Controls.Add(this.Panel_Timecrop);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Panel_decimate);
            this.Controls.Add(this.cropbytime_cBox);
            this.Controls.Add(this.InfoTbox);
            this.Controls.Add(this.StatisticsBTN);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Trim_Start);
            this.Controls.Add(this.Panel_RDP);
            this.Controls.Add(this.RDPDecimation);
            this.Name = "Form1";
            this.Text = "Data Compressor Ver 0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.Panel_decimate.ResumeLayout(false);
            this.Panel_decimate.PerformLayout();
            this.Panel_RDP.ResumeLayout(false);
            this.Panel_RDP.PerformLayout();
            this.Panel_Timecrop.ResumeLayout(false);
            this.Panel_Timecrop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Trim_Start;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox CompressTbox;
        private System.Windows.Forms.Button StatisticsBTN;
        private System.Windows.Forms.TextBox InfoTbox;
        private System.Windows.Forms.CheckBox RDPDecimation;
        private System.Windows.Forms.ComboBox TargetCbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel Panel_decimate;
        private System.Windows.Forms.Panel Panel_RDP;
        private System.Windows.Forms.TextBox EpsilonTbox;
        private System.Windows.Forms.TextBox SkipcolTbox;
        private System.Windows.Forms.RadioButton Compress_mode;
        private System.Windows.Forms.RadioButton Epsilon_mode;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox cropbytime_cBox;
        private System.Windows.Forms.TextBox Starttime_tBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Endtime_tBox;
        private System.Windows.Forms.Panel Panel_Timecrop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CHKBOX_simple;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

