namespace WF_H_010_TypewritingGaming
{
    partial class RankForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.plRecords = new System.Windows.Forms.Panel();
            this.lblAnchorId = new System.Windows.Forms.Label();
            this.lblAnchorName = new System.Windows.Forms.Label();
            this.lblAnchorScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // plRecords
            // 
            this.plRecords.AutoScroll = true;
            this.plRecords.BackColor = System.Drawing.Color.WhiteSmoke;
            this.plRecords.Location = new System.Drawing.Point(12, 83);
            this.plRecords.Name = "plRecords";
            this.plRecords.Size = new System.Drawing.Size(503, 532);
            this.plRecords.TabIndex = 1;
            // 
            // lblAnchorId
            // 
            this.lblAnchorId.AutoSize = true;
            this.lblAnchorId.BackColor = System.Drawing.Color.Transparent;
            this.lblAnchorId.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAnchorId.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblAnchorId.Location = new System.Drawing.Point(64, 29);
            this.lblAnchorId.Name = "lblAnchorId";
            this.lblAnchorId.Size = new System.Drawing.Size(77, 38);
            this.lblAnchorId.TabIndex = 1;
            this.lblAnchorId.Text = "排名";
            // 
            // lblAnchorName
            // 
            this.lblAnchorName.AutoSize = true;
            this.lblAnchorName.BackColor = System.Drawing.Color.Transparent;
            this.lblAnchorName.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAnchorName.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblAnchorName.Location = new System.Drawing.Point(216, 29);
            this.lblAnchorName.Name = "lblAnchorName";
            this.lblAnchorName.Size = new System.Drawing.Size(77, 38);
            this.lblAnchorName.TabIndex = 2;
            this.lblAnchorName.Text = "名字";
            // 
            // lblAnchorScore
            // 
            this.lblAnchorScore.AutoSize = true;
            this.lblAnchorScore.BackColor = System.Drawing.Color.Transparent;
            this.lblAnchorScore.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAnchorScore.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblAnchorScore.Location = new System.Drawing.Point(386, 29);
            this.lblAnchorScore.Name = "lblAnchorScore";
            this.lblAnchorScore.Size = new System.Drawing.Size(77, 38);
            this.lblAnchorScore.TabIndex = 3;
            this.lblAnchorScore.Text = "得分";
            // 
            // RankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WF_H_010_TypewritingGaming.Properties.Resources.bg_rank;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(527, 627);
            this.Controls.Add(this.lblAnchorScore);
            this.Controls.Add(this.lblAnchorName);
            this.Controls.Add(this.lblAnchorId);
            this.Controls.Add(this.plRecords);
            this.Name = "RankForm";
            this.Text = "RankForm";
            this.Load += new System.EventHandler(this.RankForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel plRecords;
        private System.Windows.Forms.Label lblAnchorId;
        private System.Windows.Forms.Label lblAnchorName;
        private System.Windows.Forms.Label lblAnchorScore;
    }
}