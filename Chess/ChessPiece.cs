using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Chess.UserSettingForm;

namespace Chess {

    public struct Location {
        public int x;
        public int y;
        public Location(int x, int y) { this.x = x; this.y = y; }

        public static explicit operator Point(Location pos) {
            var point = new Point();
            point.X = 114 + pos.x * 74;
            point.Y = 63 + pos.y * 74;
            return point;
        }

        public static explicit operator Location(Point point) {
            var location = new Location();
            var x = Math.Round((double)(point.X - 114) / 74);
            var y = Math.Round((double)(point.Y - 63) / 74);
            location.x = (int)x;
            location.y = (int)y;
            return location;
        }
        public static bool operator ==(Location location1, Location location2) {
            if (location1.x == location2.x && location1.y == location2.y)
                return true;
            return false;
        }
        public static bool operator !=(Location location1, Location location2) {
            return (!(location1 == location2));
        }

        public override bool Equals(object obj) {
            return (Location)obj == this;
        }

        public override int GetHashCode() {
            unchecked {
                return 17 * 23 * x + y;
            }
        }
    }

    public abstract class ChessPiece {
        internal bool isWhite;
        internal Location location;
        protected Board board;

        public ChessPiece(bool isWhite, Location location, Board board) {
            this.isWhite = isWhite;
            this.location = location;
            this.board = board;
        }

        public abstract bool IsLegalMove(Location target);

        protected bool IsBlocked(List<ChessPiece> targetSequenceLine) {
            for (var i = 0; i < targetSequenceLine.Count - 1; i++)
                if (targetSequenceLine[i] != null)
                    return true;
            return false;
        }
        internal bool IsInCheck() {
            // return board.IsInCheck(this.isWhite);
            var gameBoard = this.board.GetBoard();
            var king = board.GetKing(isWhite);
            for (var i = 0; i < 8; i++) {
                for (var j = 0; j < 8; j++) {
                    if (gameBoard[i][j] == null || gameBoard[i][j].isWhite == isWhite)
                        continue;
                    var currentChessPiece = gameBoard[i][j];
                    for (var i2 = 0; i2 < 8; i2++) {
                        for (var j2 = 0; j2 < 8; j2++) {
                            var threatingLocation = new Location(i2, j2);
                            if (threatingLocation == king.location && currentChessPiece.IsLegalMove(threatingLocation))
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        internal bool IsMoveMakeCheck(Location target) {
            var boardCopy = board.GetBoardCopy();
            var gameBoard = board.GetBoard();
            var temp_source_pos = new Location();
            temp_source_pos.x = location.x;
            temp_source_pos.y = location.y;
            gameBoard[target.x][target.y] = gameBoard[location.x][location.y];
            gameBoard[location.x][location.y] = null;
            gameBoard[target.x][target.y].location = target;
            var isInCheck = IsInCheck();
            gameBoard[target.x][target.y] = null;
            gameBoard[temp_source_pos.x][temp_source_pos.y] = boardCopy[temp_source_pos.x][temp_source_pos.y];
            gameBoard[temp_source_pos.x][temp_source_pos.y].location = temp_source_pos;
            gameBoard[target.x][target.y] = boardCopy[target.x][target.y];
            if (isInCheck)
                return true;
            return false;
        }
        internal bool IsMoveBlockCheck(Location locationTarget) {
            return !IsMoveMakeCheck(locationTarget);
        }
    }
}
