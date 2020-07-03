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
    public partial class PawnPromotionForm : Form {
        ChessPiece pawn;
        ChessLogic board;
        public PawnPromotionForm(ChessPiece pawn,ChessLogic board) {
            this.board = board;
            this.pawn = pawn;
            InitializeComponent();
            //Sound.Play("");
            if (!pawn.isWhite) {
                this.queenPictureBox.BackgroundImage = global::Chess.Properties.Resources.black_queen;
                this.bishopPictureBox.BackgroundImage = global::Chess.Properties.Resources.black_bishop;
                this.horsePictureBox.BackgroundImage = global::Chess.Properties.Resources.black_knight;
                this.rookPictureBox.BackgroundImage = global::Chess.Properties.Resources.black_rook;
            }
        }

        private void PawnPromotionForm_Load(object sender, EventArgs e) {

        }

        private void pictureBox9_Click(object sender, EventArgs e) {
            board.DoPawnPromotion<Rook>(pawn);
            this.Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e) {
            board.DoPawnPromotion<Knight>(pawn);
            this.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e) {
            board.DoPawnPromotion<Bishop>(pawn);
            this.Close();
        }

        private void pictureBox12_Click(object sender, EventArgs e) {
            board.DoPawnPromotion<Queen>(pawn);
            this.Close();
        }
    }
}
