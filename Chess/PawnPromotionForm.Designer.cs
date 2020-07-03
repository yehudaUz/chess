namespace Chess {
    partial class PawnPromotionForm {
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
            this.congratulationLabel = new System.Windows.Forms.Label();
            this.queenPictureBox = new System.Windows.Forms.PictureBox();
            this.bishopPictureBox = new System.Windows.Forms.PictureBox();
            this.horsePictureBox = new System.Windows.Forms.PictureBox();
            this.rookPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.queenPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bishopPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horsePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rookPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // congratulationLabel
            // 
            this.congratulationLabel.AutoSize = true;
            this.congratulationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.congratulationLabel.Location = new System.Drawing.Point(39, 26);
            this.congratulationLabel.Name = "congratulationLabel";
            this.congratulationLabel.Size = new System.Drawing.Size(449, 25);
            this.congratulationLabel.TabIndex = 0;
            this.congratulationLabel.Text = "Congrat!! Please choose the promotion piece:";
            // 
            // queenPictureBox
            // 
            this.queenPictureBox.BackColor = System.Drawing.Color.Yellow;
            this.queenPictureBox.BackgroundImage = global::Chess.Properties.Resources.white_queen;
            this.queenPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.queenPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.queenPictureBox.Location = new System.Drawing.Point(433, 102);
            this.queenPictureBox.Name = "queenPictureBox";
            this.queenPictureBox.Size = new System.Drawing.Size(55, 58);
            this.queenPictureBox.TabIndex = 60;
            this.queenPictureBox.TabStop = false;
            this.queenPictureBox.Click += new System.EventHandler(this.pictureBox12_Click);
            // 
            // bishopPictureBox
            // 
            this.bishopPictureBox.BackColor = System.Drawing.Color.Yellow;
            this.bishopPictureBox.BackgroundImage = global::Chess.Properties.Resources.white_bishop;
            this.bishopPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bishopPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bishopPictureBox.Location = new System.Drawing.Point(300, 102);
            this.bishopPictureBox.Name = "bishopPictureBox";
            this.bishopPictureBox.Size = new System.Drawing.Size(55, 58);
            this.bishopPictureBox.TabIndex = 59;
            this.bishopPictureBox.TabStop = false;
            this.bishopPictureBox.Click += new System.EventHandler(this.pictureBox11_Click);
            // 
            // horsePictureBox
            // 
            this.horsePictureBox.BackColor = System.Drawing.Color.Yellow;
            this.horsePictureBox.BackgroundImage = global::Chess.Properties.Resources.white_knight;
            this.horsePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.horsePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horsePictureBox.Location = new System.Drawing.Point(171, 102);
            this.horsePictureBox.Name = "horsePictureBox";
            this.horsePictureBox.Size = new System.Drawing.Size(55, 58);
            this.horsePictureBox.TabIndex = 58;
            this.horsePictureBox.TabStop = false;
            this.horsePictureBox.Click += new System.EventHandler(this.pictureBox10_Click);
            // 
            // rookPictureBox
            // 
            this.rookPictureBox.BackColor = System.Drawing.Color.Yellow;
            this.rookPictureBox.BackgroundImage = global::Chess.Properties.Resources.white_rook;
            this.rookPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rookPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rookPictureBox.Location = new System.Drawing.Point(38, 102);
            this.rookPictureBox.Name = "rookPictureBox";
            this.rookPictureBox.Size = new System.Drawing.Size(55, 58);
            this.rookPictureBox.TabIndex = 57;
            this.rookPictureBox.TabStop = false;
            this.rookPictureBox.Click += new System.EventHandler(this.pictureBox9_Click);
            // 
            // PawnPromotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 212);
            this.Controls.Add(this.queenPictureBox);
            this.Controls.Add(this.bishopPictureBox);
            this.Controls.Add(this.horsePictureBox);
            this.Controls.Add(this.rookPictureBox);
            this.Controls.Add(this.congratulationLabel);
            this.Name = "PawnPromotionForm";
            this.Text = "PawnPromotionForm";
            this.Load += new System.EventHandler(this.PawnPromotionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.queenPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bishopPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horsePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rookPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label congratulationLabel;
        public System.Windows.Forms.PictureBox queenPictureBox;
        public System.Windows.Forms.PictureBox bishopPictureBox;
        public System.Windows.Forms.PictureBox horsePictureBox;
        public System.Windows.Forms.PictureBox rookPictureBox;
    }
}