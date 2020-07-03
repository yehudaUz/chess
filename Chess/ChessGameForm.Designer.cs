namespace Chess {
    partial class ChessGameForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessGameForm));
            this.whiteTimer = new System.Windows.Forms.Timer(this.components);
            this.blackTimer = new System.Windows.Forms.Timer(this.components);
            this.whiteTimeLabel = new System.Windows.Forms.Label();
            this.blackTimeLabel = new System.Windows.Forms.Label();
            this.whiteUserNameLabel = new System.Windows.Forms.Label();
            this.blackUserNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // whiteTimer
            // 
            this.whiteTimer.Tick += new System.EventHandler(this.WhiteTimerTick);
            // 
            // blackTimer
            // 
            this.blackTimer.Tick += new System.EventHandler(this.BlackTimerTick);
            // 
            // whiteTimeLabel
            // 
            this.whiteTimeLabel.AutoSize = true;
            this.whiteTimeLabel.Location = new System.Drawing.Point(752, 685);
            this.whiteTimeLabel.Name = "whiteTimeLabel";
            this.whiteTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.whiteTimeLabel.TabIndex = 87;
            // 
            // blackTimeLabel
            // 
            this.blackTimeLabel.AutoSize = true;
            this.blackTimeLabel.Location = new System.Drawing.Point(752, 9);
            this.blackTimeLabel.Name = "blackTimeLabel";
            this.blackTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.blackTimeLabel.TabIndex = 86;
            // 
            // whiteUserNameLabel
            // 
            this.whiteUserNameLabel.AutoSize = true;
            this.whiteUserNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.whiteUserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.whiteUserNameLabel.Location = new System.Drawing.Point(2, 685);
            this.whiteUserNameLabel.Name = "whiteUserNameLabel";
            this.whiteUserNameLabel.Size = new System.Drawing.Size(0, 13);
            this.whiteUserNameLabel.TabIndex = 85;
            // 
            // blackUserNameLabel
            // 
            this.blackUserNameLabel.AutoSize = true;
            this.blackUserNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.blackUserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.blackUserNameLabel.Location = new System.Drawing.Point(1, 9);
            this.blackUserNameLabel.Name = "blackUserNameLabel";
            this.blackUserNameLabel.Size = new System.Drawing.Size(0, 13);
            this.blackUserNameLabel.TabIndex = 84;
            // 
            // ChessGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BackgroundImage = global::Chess.Properties.Resources._16_wooden_chess_board_with_coordinates_21183957249_1024x1024__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 707);
            this.Controls.Add(this.whiteTimeLabel);
            this.Controls.Add(this.blackTimeLabel);
            this.Controls.Add(this.whiteUserNameLabel);
            this.Controls.Add(this.blackUserNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChessGameForm";
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.ChessGameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer whiteTimer;
        private System.Windows.Forms.Timer blackTimer;
        private System.Windows.Forms.Label whiteTimeLabel;
        private System.Windows.Forms.Label blackTimeLabel;
        private System.Windows.Forms.Label whiteUserNameLabel;
        private System.Windows.Forms.Label blackUserNameLabel;
    }
}

