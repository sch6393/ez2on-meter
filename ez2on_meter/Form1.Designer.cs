namespace ez2on_meter
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.trackBar_refresh = new System.Windows.Forms.TrackBar();
            this.label_message = new System.Windows.Forms.Label();
            this.label_ez2on = new System.Windows.Forms.Label();
            this.label_refresh = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timer_position = new System.Windows.Forms.Timer(this.components);
            this.trackBar_opacity = new System.Windows.Forms.TrackBar();
            this.label_opacity = new System.Windows.Forms.Label();
            this.label_version = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_opacity)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar_refresh
            // 
            this.trackBar_refresh.LargeChange = 1;
            this.trackBar_refresh.Location = new System.Drawing.Point(12, 40);
            this.trackBar_refresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar_refresh.Minimum = 1;
            this.trackBar_refresh.Name = "trackBar_refresh";
            this.trackBar_refresh.Size = new System.Drawing.Size(227, 45);
            this.trackBar_refresh.TabIndex = 2;
            this.trackBar_refresh.Value = 10;
            this.trackBar_refresh.Scroll += new System.EventHandler(this.trackBar_refresh_Scroll);
            // 
            // label_message
            // 
            this.label_message.AutoSize = true;
            this.label_message.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_message.Location = new System.Drawing.Point(12, 131);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(62, 15);
            this.label_message.TabIndex = 7;
            this.label_message.Text = "MESSAGE";
            // 
            // label_ez2on
            // 
            this.label_ez2on.AutoSize = true;
            this.label_ez2on.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_ez2on.Location = new System.Drawing.Point(12, 109);
            this.label_ez2on.Name = "label_ez2on";
            this.label_ez2on.Size = new System.Drawing.Size(260, 15);
            this.label_ez2on.TabIndex = 6;
            this.label_ez2on.Text = "EZ2ON X : 0000, Y : 0000, W : 0000, H : 0000";
            // 
            // label_refresh
            // 
            this.label_refresh.AutoSize = true;
            this.label_refresh.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_refresh.Location = new System.Drawing.Point(12, 87);
            this.label_refresh.Name = "label_refresh";
            this.label_refresh.Size = new System.Drawing.Size(107, 15);
            this.label_refresh.TabIndex = 4;
            this.label_refresh.Text = "REFRESH : 100 ms";
            // 
            // button_start
            // 
            this.button_start.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_start.Location = new System.Drawing.Point(12, 12);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "START";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_stop
            // 
            this.button_stop.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_stop.Location = new System.Drawing.Point(93, 12);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 1;
            this.button_stop.Text = "STOP";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timer_position
            // 
            this.timer_position.Interval = 1000;
            this.timer_position.Tick += new System.EventHandler(this.timer_position_Tick);
            // 
            // trackBar_opacity
            // 
            this.trackBar_opacity.LargeChange = 1;
            this.trackBar_opacity.Location = new System.Drawing.Point(245, 40);
            this.trackBar_opacity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar_opacity.Minimum = 1;
            this.trackBar_opacity.Name = "trackBar_opacity";
            this.trackBar_opacity.Size = new System.Drawing.Size(227, 45);
            this.trackBar_opacity.TabIndex = 3;
            this.trackBar_opacity.Value = 5;
            this.trackBar_opacity.Scroll += new System.EventHandler(this.trackBar_opacity_Scroll);
            // 
            // label_opacity
            // 
            this.label_opacity.AutoSize = true;
            this.label_opacity.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_opacity.Location = new System.Drawing.Point(245, 87);
            this.label_opacity.Name = "label_opacity";
            this.label_opacity.Size = new System.Drawing.Size(94, 15);
            this.label_opacity.TabIndex = 5;
            this.label_opacity.Text = "OPACITY : 50 %";
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_version.Location = new System.Drawing.Point(426, 9);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(46, 15);
            this.label_version.TabIndex = 8;
            this.label_version.Text = "Ver 1.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.label_opacity);
            this.Controls.Add(this.trackBar_opacity);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.trackBar_refresh);
            this.Controls.Add(this.label_message);
            this.Controls.Add(this.label_ez2on);
            this.Controls.Add(this.label_refresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "EZ2ON METER";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_opacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar trackBar_refresh;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.Label label_ez2on;
        private System.Windows.Forms.Label label_refresh;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timer_position;
        private System.Windows.Forms.TrackBar trackBar_opacity;
        private System.Windows.Forms.Label label_opacity;
        private System.Windows.Forms.Label label_version;
    }
}

