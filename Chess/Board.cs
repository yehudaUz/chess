using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    public class Board {
        ChessPiece[][] board = new ChessPiece[8][];
        readonly List<Tuple<bool, ChessPiece[][]>> boardHistory = new List<Tuple<bool, ChessPiece[][]>>();
        List<Move> movesHistory = new List<Move>();

        internal Board() {
            for (var i = 0; i < board.Length; i++)
                board[i] = new ChessPiece[8];
            SetBoard();
        }

        public void SetBoard() {
            SetBoardSquare<Pawn>(true, 0, 6);
            SetBoardSquare<Pawn>(true, 1, 6);
            SetBoardSquare<Pawn>(true, 2, 6);
            SetBoardSquare<Pawn>(true, 3, 6);
            SetBoardSquare<Pawn>(true, 4, 6);
            SetBoardSquare<Pawn>(true, 5, 6);
            SetBoardSquare<Pawn>(true, 6, 6);
            SetBoardSquare<Pawn>(true, 7, 6);
            SetBoardSquare<Pawn>(false, 0, 1);
            SetBoardSquare<Pawn>(false, 1, 1);
            SetBoardSquare<Pawn>(false, 2, 1);
            SetBoardSquare<Pawn>(false, 3, 1);
            SetBoardSquare<Pawn>(false, 4, 1);
            SetBoardSquare<Pawn>(false, 5, 1);
            SetBoardSquare<Pawn>(false, 6, 1);
            SetBoardSquare<Pawn>(false, 7, 1);

            SetBoardSquare<Rook>(true, 0, 7);
            SetBoardSquare<Rook>(true, 7, 7);
            SetBoardSquare<Rook>(false, 0, 0);
            SetBoardSquare<Rook>(false, 7, 0);

            SetBoardSquare<Knight>(true, 1, 7);
            SetBoardSquare<Knight>(true, 6, 7);
            SetBoardSquare<Knight>(false, 1, 0);
            SetBoardSquare<Knight>(false, 6, 0);

            SetBoardSquare<Bishop>(true, 5, 7);
            SetBoardSquare<Bishop>(true, 2, 7);
            SetBoardSquare<Bishop>(false, 5, 0);
            SetBoardSquare<Bishop>(false, 2, 0);

            SetBoardSquare<Queen>(true, 3, 7);
            SetBoardSquare<King>(true, 4, 7);
            SetBoardSquare<Queen>(false, 3, 0);
            SetBoardSquare<King>(false, 4, 0);

            AddCurrentBoardToBoardHistory(true);
        }

        internal ChessPiece[][] GetBoard() {
            return board;
        }

        public void SetBoardSquare<T>(bool isWhite, int x, int y) {
            board[x][y] = ((T)Activator.CreateInstance(typeof(T), isWhite, new Location(x, y), this)) as ChessPiece;
        }

        internal ChessPiece GetSquareData(Location pos) {
            if (board[pos.x][pos.y] == null)
                return null;
            else
                return board[pos.x][pos.y];
        }

        public void UpdateBoard(Location location, Location target, bool isPawnSpecialEatUpdate = false) {
            movesHistory.Add(new Move(location, target));
            if (board[target.x][target.y] != null) { //eating
                Sound.Play("eatSound");
                board[target.x][target.y] = null;
            }
            board[target.x][target.y] = board[location.x][location.y];
            board[location.x][location.y] = null;
            if (isPawnSpecialEatUpdate) {
                var lastMove = (Move)GetLastMove();
                Sound.Play("eatSound");
                if (board[lastMove.to.x][lastMove.to.y].isWhite)
                    board[lastMove.to.x][lastMove.to.y + 1] = null;
                else
                    board[lastMove.to.x][lastMove.to.y - 1] = null;
            }
            board[target.x][target.y].location = new Location(target.x, target.y);
        }

        public Move? GetLastMove() {
            if (movesHistory.Count == 0)
                return null;
            return movesHistory.Last();
        }
        public List<ChessPiece> GetStrightSequence(Location location, Location target) {
            var sequence = new List<ChessPiece>();
            if (location.y == target.y) {
                if (location.x < target.x)
                    for (int i = location.x + 1; i <= target.x; i++)
                        sequence.Add(board[i][target.y]);
                else
                    for (int i = location.x - 1; i >= target.x; i--)
                        sequence.Add(board[i][target.y]);
            }
            else if (location.x == target.x) {
                if (location.y < target.y)
                    for (int i = location.y + 1; i <= target.y; i++)
                        sequence.Add(board[target.x][i]);
                else
                    for (int i = location.y - 1; i >= target.y; i--)
                        sequence.Add(board[target.x][i]);
            }
            return sequence;
        }

        public void AddCurrentBoardToBoardHistory(bool isWhite) {
            var copyOf_board = GetBoardCopy();
            boardHistory.Add(new Tuple<bool, ChessPiece[][]>(isWhite, copyOf_board));
        }

        public List<Location> GetBoardSquareThatChanged() {
            var boardSquareThatChanged = new List<Location>();
            if (boardHistory.Count <= 1) {
                for (var i = 0; i < 8; i++)
                    for (var j = 0; j < 8; j++)
                        boardSquareThatChanged.Add(new Location(i, j));
                return boardSquareThatChanged;
            }
            else {
                for (var i = 0; i < 8; i++)
                    for (var j = 0; j < 8; j++)
                        if (boardHistory.Last().Item2[i][j] != boardHistory[boardHistory.Count - 2].Item2[i][j])
                            boardSquareThatChanged.Add(new Location(i, j));
                return boardSquareThatChanged;
            }

        }

        public ChessPiece[][] GetBoardCopy() {
            var copyOfBoard = new ChessPiece[8][];
            for (var i = 0; i < copyOfBoard.Length; i++)
                copyOfBoard[i] = new ChessPiece[8];
            var cloneOfBoardAsList = new List<ChessPiece[]>(board);
            for (var i = 0; i < copyOfBoard.Length; i++) {
                for (var j = 0; j < copyOfBoard.Length; j++) {
                    copyOfBoard[i][j] = cloneOfBoardAsList[i][j];
                }
            }
            return copyOfBoard;
        }

        public void MakePawnPromotion<T>(ChessPiece pawn) {
            SetBoardSquare<T>(pawn.isWhite, pawn.location.x, pawn.location.y);
        }

        public List<Tuple<bool, ChessPiece[][]>> GetBoardHistory() {
            return boardHistory;
        }

        internal List<Move> GetMovesHistory() {
            return movesHistory;
        }

        public List<ChessPiece> GetDiagonalSequence(Location location, Location target) {
            var sequence = new List<ChessPiece>();
            if (Math.Abs(target.x - location.x) != Math.Abs(target.y - location.y)) //not a diagonal move
                return sequence;
            if (location.x != target.x && location.y != target.y) {
                if (target.x > location.x && target.y < location.y) { //upRight digonal
                    for (int i = location.x + 1, j = location.y - 1; i <= target.x && j >= target.y; i++, j--)
                        sequence.Add(board[i][j]);
                }
                else if (target.x < location.x && target.y < location.y) { //upLeft digonal
                    for (int i = location.x - 1, j = location.y - 1; i >= target.x && j >= target.y; i--, j--)
                        sequence.Add(board[i][j]);
                }
                else if (target.x > location.x && target.y > location.y) { //downRight digonal
                    for (int i = location.x + 1, j = location.y + 1; i <= target.x && j <= target.y; i++, j++)
                        sequence.Add(board[i][j]);
                }
                else if (target.x < location.x && target.y > location.y) { //downLeft digonal
                    for (int i = location.x - 1, j = location.y + 1; i >= target.x && j <= target.y; i--, j++)
                        sequence.Add(board[i][j]);
                }
            }

            return sequence;
        }
        public ChessPiece GetKing(bool isWhite) {
            for (var i = 0; i < board.Length; i++) {
                for (var j = 0; j < board.Length; j++) {
                    if (board[i][j] is King && (board[i][j] as King).isWhite == isWhite)
                        return board[i][j];
                }
            }
            throw new Exception("King not found!");
        }
    }
}
