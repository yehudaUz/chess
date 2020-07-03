namespace Chess {
    partial class UserSettingForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSettingForm));
            this.blackNameTextBox = new System.Windows.Forms.TextBox();
            this.whiteNameTextBox = new System.Windows.Forms.TextBox();
            this.whiteUserNameLabel = new System.Windows.Forms.Label();
            this.blackUserNameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gameTimeLabel = new System.Windows.Forms.Label();
            this.gameTimeInMinutesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.startGameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gameTimeInMinutesNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // blackNameTextBox
            // 
            this.blackNameTextBox.Location = new System.Drawing.Point(250, 27);
            this.blackNameTextBox.Name = "blackNameTextBox";
            this.blackNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.blackNameTextBox.TabIndex = 0;
            this.blackNameTextBox.TextChanged += new System.EventHandler(this.WhiteUserNameTextChanged);
            // 
            // whiteNameTextBox
            // 
            this.whiteNameTextBox.Location = new System.Drawing.Point(250, 64);
            this.whiteNameTextBox.Name = "whiteNameTextBox";
            this.whiteNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.whiteNameTextBox.TabIndex = 1;
            this.whiteNameTextBox.TextChanged += new System.EventHandler(this.blackNameTextBoxTextChanged);
            // 
            // whiteUserNameLabel
            // 
            this.whiteUserNameLabel.AutoSize = true;
            this.whiteUserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.whiteUserNameLabel.Location = new System.Drawing.Point(16, 59);
            this.whiteUserNameLabel.Name = "whiteUserNameLabel";
            this.whiteUserNameLabel.Size = new System.Drawing.Size(218, 25);
            this.whiteUserNameLabel.TabIndex = 2;
            this.whiteUserNameLabel.Text = "Black Player Name:";
            // 
            // blackUserNameLabel
            // 
            this.blackUserNameLabel.AutoSize = true;
            this.blackUserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.blackUserNameLabel.Location = new System.Drawing.Point(16, 22);
            this.blackUserNameLabel.Name = "blackUserNameLabel";
            this.blackUserNameLabel.Size = new System.Drawing.Size(220, 25);
            this.blackUserNameLabel.TabIndex = 3;
            this.blackUserNameLabel.Text = "White Player Name:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 11;
            // 
            // gameTimeLabel
            // 
            this.gameTimeLabel.AutoSize = true;
            this.gameTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.gameTimeLabel.Location = new System.Drawing.Point(12, 119);
            this.gameTimeLabel.Name = "gameTimeLabel";
            this.gameTimeLabel.Size = new System.Drawing.Size(138, 25);
            this.gameTimeLabel.TabIndex = 8;
            this.gameTimeLabel.Text = "Game Time:";
            // 
            // gameTimeInMinutesNumericUpDown
            // 
            this.gameTimeInMinutesNumericUpDown.Location = new System.Drawing.Point(157, 121);
            this.gameTimeInMinutesNumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.gameTimeInMinutesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gameTimeInMinutesNumericUpDown.Name = "gameTimeInMinutesNumericUpDown";
            this.gameTimeInMinutesNumericUpDown.Size = new System.Drawing.Size(41, 20);
            this.gameTimeInMinutesNumericUpDown.TabIndex = 9;
            this.gameTimeInMinutesNumericUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.gameTimeInMinutesNumericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // startGameButton
            // 
            this.startGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.startGameButton.Location = new System.Drawing.Point(327, 104);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(120, 45);
            this.startGameButton.TabIndex = 10;
            this.startGameButton.Text = "START!";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.StartGameButtonClicked);
            // 
            // UserSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 158);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.gameTimeInMinutesNumericUpDown);
            this.Controls.Add(this.gameTimeLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.blackUserNameLabel);
            this.Controls.Add(this.whiteUserNameLabel);
            this.Controls.Add(this.whiteNameTextBox);
            this.Controls.Add(this.blackNameTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserSettingForm";
            this.Text = "Game Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserSettingForm_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gameTimeInMinutesNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox blackNameTextBox;
        private System.Windows.Forms.TextBox whiteNameTextBox;
        private System.Windows.Forms.Label whiteUserNameLabel;
        private System.Windows.Forms.Label blackUserNameLabel;
        //private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        //private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label gameTimeLabel;
        private System.Windows.Forms.NumericUpDown gameTimeInMinutesNumericUpDown;
        private System.Windows.Forms.Button startGameButton;
    }
}