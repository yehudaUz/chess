using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Chess.UserSettingForm;

namespace Chess {
    public partial class ChessGameForm : Form {
        bool isMousePressed;
        GameSetting gameSetting;
        int whiteTimePassedInSeconds = 0, blackTimePassedInSeconds = 0;
        readonly ChessLogic chessLogic = new ChessLogic();
        public ChessGameForm() {
            using (var gameSettingForm = new UserSettingForm()) {
                gameSettingForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                gameSettingForm.ShowDialog();
                gameSetting = gameSettingForm.gameSetting;
            }

            InitializeComponent();
            DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            SetBoardGraphics();

            whiteUserNameLabel.Text = gameSetting.whiteUserName;
            blackUserNameLabel.Text = gameSetting.blackUserName;

            whiteTimer.Interval = 1000;
            whiteTimer.Start();
            blackTimer.Interval = 1000;
            blackTimer.Start();
        }

        private void SetEventsForPictureBox(PictureBox pictureBox) {
            pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(Mouse_Down);
            pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(SaveStartPosition);
            pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(Mouse_Move);
            pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(Mouse_Up);
        }

        private void SetBoardGraphics() {
            var listOfChangesInBoard = chessLogic.GetBoardSquareThatChanged();
            for (var i = 0; i < listOfChangesInBoard.Count; i++) {
                var x = listOfChangesInBoard[i].x;
                var y = listOfChangesInBoard[i].y;
                var gameBoard = chessLogic.GetBoard();
                var pictureToCheckIfNeedToRemove = GetPictureBoxAtCoordinate((Point)(new Location(x, y)));

                var picture = new PictureBox {
                    BackColor = System.Drawing.Color.Transparent,
                    BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom,
                    Location = (Point)(new Location(x, y)),
                    Size = new System.Drawing.Size(55, 58),
                    TabIndex = 81,
                    TabStop = false
                };
                string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Resources\\";
                if (gameBoard[x][y] is Pawn) {
                    picture.Name = "Pawn";
                    picture.BackgroundImage = gameBoard[x][y].isWhite ? global::Chess.Properties.Resources.white_pawn : global::Chess.Properties.Resources.black_pawn;
                    picture.ImageLocation = gameBoard[x][y].isWhite ? projectDirectory + "white_pawn.png" : projectDirectory + "black_pawn.png";
                }
                else if (gameBoard[x][y] is Rook) {
                    picture.Name = "Rook";
                    picture.BackgroundImage = gameBoard[x][y].isWhite ? global::Chess.Properties.Resources.white_rook : global::Chess.Properties.Resources.black_rook;
                    picture.ImageLocation = gameBoard[x][y].isWhite ? projectDirectory + "white_rook.png" : projectDirectory + "black_rook.png";
                }
                else if (gameBoard[x][y] is Knight) {
                    picture.Name = "Knight";
                    picture.BackgroundImage = gameBoard[x][y].isWhite ? global::Chess.Properties.Resources.white_knight : global::Chess.Properties.Resources.black_knight;
                    picture.ImageLocation = gameBoard[x][y].isWhite ? projectDirectory + "white_knight.png" : projectDirectory + "black_knight.png";
                }
                else if (gameBoard[x][y] is Bishop) {
                    picture.Name = "Bishop";
                    picture.BackgroundImage = gameBoard[x][y].isWhite ? global::Chess.Properties.Resources.white_bishop : global::Chess.Properties.Resources.black_bishop;
                    picture.ImageLocation = gameBoard[x][y].isWhite ? projectDirectory + "white_bishop.png" : projectDirectory + "black_bishop.png";
                }
                else if (gameBoard[x][y] is Queen) {
                    picture.Name = "Queen";
                    picture.BackgroundImage = gameBoard[x][y].isWhite ? global::Chess.Properties.Resources.white_queen : global::Chess.Properties.Resources.black_queen;
                    picture.ImageLocation = gameBoard[x][y].isWhite ? projectDirectory + "white_queen.png" : projectDirectory + "black_queen.png";
                }
                else if (gameBoard[x][y] is King) {
                    picture.Name = "King";
                    picture.BackgroundImage = gameBoard[x][y].isWhite ? global::Chess.Properties.Resources.white_king : global::Chess.Properties.Resources.black_king;
                    picture.ImageLocation = gameBoard[x][y].isWhite ? projectDirectory + "white_king.png" : projectDirectory + "black_king.png";
                }
                if (pictureToCheckIfNeedToRemove == null) {
                    if (picture.Name != "") {
                        Controls.Add(picture);
                        SetEventsForPictureBox(picture);
                    }
                }
                else if (pictureToCheckIfNeedToRemove.ImageLocation != picture.ImageLocation) {
                    Controls.Remove(pictureToCheckIfNeedToRemove);
                    if (gameBoard[x][y] != null) {
                        Controls.Add(picture);
                        SetEventsForPictureBox(picture);
                    }
                }
            }
        }


        PictureBox currentCurserPicture = new PictureBox();
        int currentX, currentY;
        private Point startPosition;

        public void Mouse_Down(object sender, MouseEventArgs e) {
            isMousePressed = true;
            currentCurserPicture = ((PictureBox)sender).Name == "" ? null : (PictureBox)sender;
            currentX = e.X;
            currentY = e.Y;
        }


        private void Form1_Load(object sender, EventArgs e) {

        }

        public void Mouse_Move(object sender, MouseEventArgs e) {
            if (isMousePressed && currentCurserPicture != null) {
                currentCurserPicture.Top = currentCurserPicture.Top + (e.Y - currentY);
                currentCurserPicture.Left = currentCurserPicture.Left + (e.X - currentX);
            }
        }

        private void WhiteTimerTick(object sender, EventArgs e) {
            if (!(chessLogic.IsWhiteTurn()))//not white turn
                return;
            whiteTimePassedInSeconds += 1;
            var timeLeftMinuts = (int)(gameSetting.gameTimeInMinutes - Math.Ceiling((double)whiteTimePassedInSeconds / 60));
            var timeLeftSeconds = 60 - whiteTimePassedInSeconds % 60;
            var secStr = "";
            if (timeLeftSeconds < 10)
                secStr = "0" + timeLeftSeconds;
            else if (timeLeftSeconds == 60)
                secStr = "00";
            else
                secStr = timeLeftSeconds.ToString();
            whiteTimeLabel.Text = timeLeftMinuts + ":" + secStr;
            if (whiteTimePassedInSeconds >= gameSetting.gameTimeInMinutes * 60) {
                whiteTimer.Stop(); blackTimer.Stop();
                Console.Beep(); Console.Beep(); Console.Beep();
                MessageBox.Show("Game over!! " + gameSetting.whiteUserName + " WON BY TIME!!!");
                Environment.Exit(0);
            }
        }

        private void BlackTimerTick(object sender, EventArgs e) {
            if (chessLogic.IsWhiteTurn())//if white turn
                return;
            blackTimePassedInSeconds += 1;
            var timeLeftMinuts = (int)(gameSetting.gameTimeInMinutes - Math.Ceiling((double)blackTimePassedInSeconds / 60));
            var timeLeftSeconds = 60 - blackTimePassedInSeconds % 60;
            var secStr = "";
            if (timeLeftSeconds < 10)
                secStr = "0" + timeLeftSeconds;
            else if (timeLeftSeconds == 60)
                secStr = "00";
            else
                secStr = timeLeftSeconds.ToString();
            blackTimeLabel.Text = timeLeftMinuts + ":" + secStr;
            if (blackTimePassedInSeconds >= gameSetting.gameTimeInMinutes * 60) {
                blackTimer.Stop(); blackTimer.Stop();
                Console.Beep(); Console.Beep(); Console.Beep();
                MessageBox.Show("Game over!! " + gameSetting.blackUserName + " WON BY TIME!!!");
                Environment.Exit(0);
            }
        }

        public void Mouse_Up(object sender, MouseEventArgs e) {
            if (sender == null)
                return;
            isMousePressed = false;
            currentCurserPicture = null;
            var from = (Location)startPosition;
            var to = (Location)(((PictureBox)sender).Location);
            if (from == to) {
                ((PictureBox)sender).Location = ((Point)from);
                return;
            }
            var message = "";
            var isMove = chessLogic.DoMoveIfLegal(from, to, ref message);
            ((PictureBox)sender).Location = (Point)from;
            if (isMove)
                SetBoardGraphics();
            else
                (sender as PictureBox).Location = startPosition;
            if (message != "")
                MessageBox.Show(message);
            if (chessLogic.IsEndGame(ref message)) {
                MessageBox.Show(message);
                Environment.Exit(0);
            }
        }

        private void ChessGameForm_Load(object sender, EventArgs e) {

        }

        private PictureBox GetPictureBoxAtCoordinate(Point point) {
            foreach (var pictureBox in this.Controls.OfType<PictureBox>()) {
                if (pictureBox.Location == point)
                    return pictureBox;
            }
            return null;
        }
        internal void SaveStartPosition(object sender, MouseEventArgs e) {
            startPosition = ((PictureBox)sender).Location;
        }


    }
}

