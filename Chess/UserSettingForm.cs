using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess {
    public partial class UserSettingForm : Form {
        public struct GameSetting {
            public string whiteUserName { get; set; }
            public string blackUserName { get; set; }
            public int gameTimeInMinutes { get; set; }

        }
        public GameSetting gameSetting;

        public UserSettingForm() {
            InitializeComponent();
            Sound.Play("startSound");
            this.Text = "Chess Game Set";
        }

        private void blackNameTextBoxTextChanged(object sender, EventArgs e) {
            gameSetting.blackUserName = (sender as TextBox).Text;
            if (gameSetting.blackUserName == gameSetting.whiteUserName) {
                MessageBox.Show("Can't both be the same name!!!");
                gameSetting.blackUserName = "";
            }
        }

        private void StartGameButtonClicked(object sender, EventArgs e) {
            if (gameSetting.whiteUserName != gameSetting.blackUserName) {
                gameSetting.gameTimeInMinutes = (int)gameTimeInMinutesNumericUpDown.Value;
                this.Close();
            }
            else
                MessageBox.Show("Please fill filed correctly!");
        }

        private void Form2_Load(object sender, EventArgs e) {

        }

        private void WhiteUserNameTextChanged(object sender, EventArgs e) {
            gameSetting.whiteUserName = (sender as TextBox).Text;
            if (gameSetting.blackUserName == gameSetting.whiteUserName) {
                MessageBox.Show("Can't both be the same name!!!");
                gameSetting.whiteUserName = "";
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {

        }

        private void UserSettingForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (gameSetting.whiteUserName == null || gameSetting.blackUserName == null) {
                Console.Beep();
               var result = MessageBox.Show("Can't start game without set it first. R U sure U want to exit??", "Exit Game?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    Environment.Exit(0);
                else {
                    e.Cancel = true;
                }
            }               
        }
    }
}
