namespace WF_H_010_TypewritingGaming
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.plGameRegion = new System.Windows.Forms.Panel();
            this.btnRank = new System.Windows.Forms.Button();
            this.plGameInfo = new System.Windows.Forms.Panel();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLastTime = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tmCountdown = new System.Windows.Forms.Timer(this.components);
            this.tmFall = new System.Windows.Forms.Timer(this.components);
            this.plGameInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // plGameRegion
            // 
            this.plGameRegion.Location = new System.Drawing.Point(265, 12);
            this.plGameRegion.Name = "plGameRegion";
            this.plGameRegion.Size = new System.Drawing.Size(618, 479);
            this.plGameRegion.TabIndex = 0;
            // 
            // btnRank
            // 
            this.btnRank.BackColor = System.Drawing.Color.SandyBrown;
            this.btnRank.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRank.Location = new System.Drawing.Point(12, 12);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(233, 68);
            this.btnRank.TabIndex = 0;
            this.btnRank.Text = "排行榜";
            this.btnRank.UseVisualStyleBackColor = false;
            this.btnRank.Click += new System.EventHandler(this.btnRank_Click);
            // 
            // plGameInfo
            // 
            this.plGameInfo.Controls.Add(this.lblScore);
            this.plGameInfo.Controls.Add(this.lblLastTime);
            this.plGameInfo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.plGameInfo.Location = new System.Drawing.Point(12, 167);
            this.plGameInfo.Name = "plGameInfo";
            this.plGameInfo.Size = new System.Drawing.Size(233, 106);
            this.plGameInfo.TabIndex = 1;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(14, 61);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(136, 25);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "得分：{{得分}}";
            // 
            // lblLastTime
            // 
            this.lblLastTime.AutoSize = true;
            this.lblLastTime.Location = new System.Drawing.Point(14, 24);
            this.lblLastTime.Name = "lblLastTime";
            this.lblLastTime.Size = new System.Drawing.Size(156, 25);
            this.lblLastTime.TabIndex = 0;
            this.lblLastTime.Text = "倒數：{{秒數}}秒";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LightGreen;
            this.btnStart.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStart.Location = new System.Drawing.Point(12, 86);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(233, 68);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "開始遊戲";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tmCountdown
            // 
            this.tmCountdown.Enabled = true;
            this.tmCountdown.Interval = 1000;
            this.tmCountdown.Tick += new System.EventHandler(this.tmCountdown_Tick);
            // 
            // tmFall
            // 
            this.tmFall.Interval = 1000;
            this.tmFall.Tick += new System.EventHandler(this.tmFall_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WF_H_010_TypewritingGaming.Properties.Resources.bg_main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(895, 503);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.plGameInfo);
            this.Controls.Add(this.btnRank);
            this.Controls.Add(this.plGameRegion);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.plGameInfo.ResumeLayout(false);
            this.plGameInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plGameRegion;
        private System.Windows.Forms.Button btnRank;
        private System.Windows.Forms.Panel plGameInfo;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblLastTime;
        private System.Windows.Forms.Timer tmCountdown;
        private System.Windows.Forms.Timer tmFall;
    }
}

