using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Newtonsoft.Json;
using static Chess.UserSettingForm;

namespace Chess {
    public struct Move {
        public Location from;
        public Location to;
        public Move(Location from, Location to) {
            this.from = from;
            this.to = to;
        }
    }
    public class ChessLogic {
        Board board = new Board();
        bool isWhiteTurn = true;
        public ChessLogic() { }

        internal bool IsWhiteTurn() {
            return isWhiteTurn;
        }

        internal bool DoMoveIfLegal(Location from, Location to, ref string message) {
            var pieceUserWantToMove = board.GetSquareData(from);
            if (!IsLegalMove(pieceUserWantToMove, to, ref message))
                return false;
            Sound.Play("moveSound");
            DeniedFutureCastlingIfNeedTo(pieceUserWantToMove);
            if (pieceUserWantToMove is King && Math.Abs(to.x - from.x) == 2)  //castling move
                DoCastling(from, to, pieceUserWantToMove.isWhite);
            else if (pieceUserWantToMove is Pawn && Math.Abs(to.y - from.y) == 1 && Math.Abs(to.x - from.x) == 1 && board.GetSquareData(to) == null)  //Pawn special eat
                board.UpdateBoard(from, to, true);
            else  //normal move
                board.UpdateBoard(from, to);
            isWhiteTurn = !isWhiteTurn; //set next user turn
            board.AddCurrentBoardToBoardHistory(!pieceUserWantToMove.isWhite);
            if (pieceUserWantToMove is ChessPiece && pieceUserWantToMove is Pawn &&  //Pawn promotion
               ((pieceUserWantToMove.isWhite && to.y == 0) || (!pieceUserWantToMove.isWhite && to.y == 7))) {
                Sound.Play("promotionSoundEffect");
                var promotionForm = new PawnPromotionForm(pieceUserWantToMove as ChessPiece, this);
                promotionForm.ShowDialog();
            }
            return true;
        }

        internal ChessPiece[][] GetBoard() {
            return board.GetBoard();
        }

        internal List<Location> GetBoardSquareThatChanged() {
            return board.GetBoardSquareThatChanged();
        }

        bool IsLegalMove(ChessPiece pieceUserWantToMove, Location target, ref string message) {

            if ((IsWhiteTurn() && !pieceUserWantToMove.isWhite) || (!IsWhiteTurn() && pieceUserWantToMove.isWhite)) {
                message = "Not your turn!!!";
                return false;
            }
            else if (target.x > 7 || target.x < 0 || target.y < 0 || target.y > 7) {
                message = "Stay in game boundries!!";
                return false;
            }
            else if (board.GetSquareData(target) != null && board.GetSquareData(target).isWhite == pieceUserWantToMove.isWhite) {
                message = "Can't put piece on your own piece!!!";
                return false;
            }
            else if (!pieceUserWantToMove.IsLegalMove(target)) {
                message = "Iligal move!";
                return false;
            }
            else if ((pieceUserWantToMove.IsInCheck() && !pieceUserWantToMove.IsMoveBlockCheck(target)) || pieceUserWantToMove.IsMoveMakeCheck(target)) {
                message = "CHECK BLAT!!";
                return false;
            }
            return true;
        }

        void DoCastling(Location from, Location target, bool isWhite) {
            //king moving
            board.UpdateBoard(from, target);
            //castle moving
            var rook = new Rook(isWhite, new Location(0, 0), board);
            if (target.x > from.x) { //right castle
                if (isWhite)
                    rook = (Rook)board.GetSquareData(new Location(7, 7));
                else
                    rook = (Rook)board.GetSquareData(new Location(7, 0));
                target.x -= 1;
            }
            else { //left castle
                if (isWhite)
                    rook = (Rook)board.GetSquareData(new Location(0, 7));
                else
                    rook = (Rook)board.GetSquareData(new Location(0, 0));
                target.x += 1;
            }
            board.UpdateBoard(rook.location, target);
        }

        void DeniedFutureCastlingIfNeedTo(ChessPiece pieceUserWantToMove) {
            if (pieceUserWantToMove is King)
                (pieceUserWantToMove as King).DeniedallCastling();
            else if (pieceUserWantToMove is Rook) {
                if (pieceUserWantToMove.location.x == 7 && pieceUserWantToMove.location.y == 7)
                    (board.GetKing(pieceUserWantToMove.isWhite) as King).DeniedRightCastling();
                else if (pieceUserWantToMove.location.x == 0 && pieceUserWantToMove.location.y == 7)
                    (board.GetKing(pieceUserWantToMove.isWhite) as King).DeniedaLeftCastling();
                else if (pieceUserWantToMove.location.x == 0 && pieceUserWantToMove.location.y == 0)
                    (board.GetKing(pieceUserWantToMove.isWhite) as King).DeniedaLeftCastling();
                else if (pieceUserWantToMove.location.x == 7 && pieceUserWantToMove.location.y == 0)
                    (board.GetKing(pieceUserWantToMove.isWhite) as King).DeniedRightCastling();
            }
        }

        internal void DoPawnPromotion<T>(ChessPiece pawn) {
            board.SetBoardSquare<T>(pawn.isWhite, pawn.location.x, pawn.location.y);
        }

        bool IsDraw(bool isWhiteTurn) {
            if (IsPat(isWhiteTurn))
                return true;
            else if (IsNotEnoughPicesForCheckMate())
                return true;
            else if (IsSamePositionAndSamePlayerThirdTime(isWhiteTurn))
                return true;
            else if (IsFiftyMovesWithoutEatAndWithoutPawnMoved())
                return true;
            return false;
        }

        const int MOVESNUMALLOWED = 50;
        bool IsFiftyMovesWithoutEatAndWithoutPawnMoved() {
            var boardHistory = board.GetBoardHistory();
            if (boardHistory.Count < MOVESNUMALLOWED)
                return false;
            var counter = 0;
            for (var i = 1; i < boardHistory.Count; i++) {
                var theMove = board.GetMovesHistory()[i - 1];
                var lastBoard = boardHistory[i - 1].Item2;
                //pawn or eating
                if (lastBoard[theMove.from.x][theMove.from.y] is ChessPiece || lastBoard[theMove.to.x][theMove.to.y] != null) {
                    counter = 0;
                    if (boardHistory.Count - i < MOVESNUMALLOWED)
                        return false;
                }
                else
                    counter++;
            }
            if (counter >= MOVESNUMALLOWED)
                return true;
            return false;
        }

        bool IsSamePositionAndSamePlayerThirdTime(bool isWhiteTurn) {
            var boardHistory = board.GetBoardHistory();
            for (var i = 0; i < boardHistory.Count; i++) {
                var currentBoard = boardHistory[i];
                var counter = 0;
                for (var j = 0; j < boardHistory.Count; j++) {
                    if (currentBoard.Item1 == boardHistory[j].Item1 && IsSamePosition(currentBoard.Item2, boardHistory[j].Item2))
                        counter++;
                    if (counter >= 3)
                        return true;
                }
            }
            return false;
        }

        bool IsSamePosition(ChessPiece[][] board1, ChessPiece[][] board2) {
            for (var i = 0; i < board1.Length; i++) {
                for (var j = 0; j < board1[i].Length; j++) {
                    if (board1[i][j] != board2[i][j])
                        return false;
                }
            }
            return true;
        }

        bool IsNotEnoughPicesForCheckMate() {
            var allPices = new List<ChessPiece>();
            var gameBoard = board.GetBoard();
            for (var i = 0; i < gameBoard.Length; i++) {
                for (var j = 0; j < gameBoard[i].Length; j++) {
                    if (gameBoard[i][j] != null) {
                        allPices.Add(gameBoard[i][j]);
                    }
                }
            }
            if (allPices.Count > 3)
                return false;
            else if (allPices.Count == 2)
                return true;
            else if (
                    (allPices[0] is King || allPices[0] is Knight || allPices[0] is Bishop) &&
                    (allPices[1] is King || allPices[1] is Knight || allPices[1] is Bishop) &&
                    (allPices[2] is King || allPices[2] is Knight || allPices[2] is Bishop)
                    )
                return true;
            else
                return false;
        }

        bool IsPat(bool isWhiteTurn) {
            var gameBoard = board.GetBoard();
            if (!IsInCheck(isWhiteTurn)) {
                for (var i = 0; i < gameBoard.Length; i++) {
                    for (var j = 0; j < gameBoard[i].Length; j++) {
                        if (gameBoard[i][j] != null && gameBoard[i][j].isWhite == isWhiteTurn) {
                            var possibleMoves = GetAllPossiblePieceMoves(gameBoard[i][j]);
                            if (possibleMoves.Count > 0)
                                return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        internal bool IsEndGame(ref string message) {
            if (IsMate(out bool isWhiteCheckMate)) {
                Console.Beep(); Console.Beep(); Console.Beep();
                var str = isWhiteCheckMate ? "WHITE" : "BLACK";
                message = ("Check Mate!!! " + str + " WON!!!");
                return true;
            }
            else if (IsDraw(IsWhiteTurn())) {
                Console.Beep(); Console.Beep(); Console.Beep();
                message = "Draw!!!";
                return true;
            }
            return false;
        }

        bool IsMate(out bool isWhite) {
            var gameBoard = this.board.GetBoard();
            if (IsInCheck(true)) {
                isWhite = false;
                for (var i = 0; i < gameBoard.Length; i++) {
                    for (var j = 0; j < gameBoard[i].Length; j++) {
                        if (gameBoard[i][j] != null && gameBoard[i][j].isWhite == true) {
                            var possibleMoves = GetAllPossiblePieceMoves(gameBoard[i][j]);
                            for (var k = 0; k < possibleMoves.Count; k++)
                                if (gameBoard[i][j].IsMoveBlockCheck(possibleMoves[k]))
                                    return false;
                        }
                    }
                }
                return true;
            }
            else if (IsInCheck(false)) {
                isWhite = true;
                for (var i = 0; i < gameBoard.Length; i++) {
                    for (var j = 0; j < gameBoard[i].Length; j++) {
                        if (gameBoard[i][j] != null && gameBoard[i][j].isWhite == false) {
                            var possibleMoves = GetAllPossiblePieceMoves(gameBoard[i][j]);
                            for (var k = 0; k < possibleMoves.Count; k++)
                                if (gameBoard[i][j].IsMoveBlockCheck(possibleMoves[k]))
                                    return false;
                        }
                    }
                }
                return true;
            }

            isWhite = false;
            return false;
        }
        bool IsInCheck(bool isWhite) {
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

        List<Location> GetAllPossiblePieceMoves(ChessPiece piece) {
            var gameBoard = this.board.GetBoard();
            var allPossibleMoves = new List<Location>();
            for (var i = 0; i < 8; i++) {
                for (var j = 0; j < 8; j++) {
                    if (gameBoard[i][j] != null && gameBoard[i][j].isWhite == piece.isWhite)
                        continue;
                    var targetLocation = new Location(i, j);
                    var str = "";
                    if (piece.IsLegalMove(targetLocation) && IsLegalMove(piece,targetLocation,ref str))
                        allPossibleMoves.Add(targetLocation);
                }
            }
            return allPossibleMoves;
        }
    }
}
