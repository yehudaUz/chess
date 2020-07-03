using System;

namespace Chess {
    public class Pawn : ChessPiece {
        public Pawn(bool isWhite, Location pos, Board board) : base(isWhite, pos, board) { }
        public override bool IsLegalMove(Location target) {
            var targetSquareData = board.GetSquareData(target);
            var lastMove = board.GetLastMove();
            ChessPiece lastMovePiece = null;
            if (lastMove != null)
                lastMovePiece = board.GetSquareData(((Move)lastMove).to);
            var opponentPawnDid2Moves = false;
            if (lastMove != null && lastMovePiece is Pawn && Math.Abs(((Move)lastMove).to.y - ((Move)lastMove).from.y) == 2 && 
                (target.x == ((Move)lastMove).to.x) && (isWhite && target.y == ((Move)lastMove).to.y-1 || !isWhite && target.y == ((Move)lastMove).to.y + 1) )
                opponentPawnDid2Moves = true;
            if ((Math.Abs(location.y - target.y) == 2 && ((target.y > location.y && board.GetSquareData(new Location(target.x, target.y - 1)) != null) || //check nothing block on the way of 2 move
                (target.y < location.y && board.GetSquareData(new Location(target.x, target.y + 1)) != null))) ||
                (Math.Abs(location.y - target.y) == 1 && Math.Abs(location.x - target.x) == 0 && targetSquareData != null))
                return false;
            else if (Math.Abs(location.y - target.y) == 2 && board.GetSquareData(new Location(target.x, target.y)) != null) //check that 2 moves not on oponnet piece
                return false;
            else if ((isWhite && target.y >= location.y) || (!isWhite && target.y <= location.y)) //correct way
                return false;
            else if ((Math.Abs(location.y - target.y) > 2) || //more then two move,or two when not start
                    (isWhite && Math.Abs(target.y - location.y) == 2 && location.y != 6) || (!isWhite && Math.Abs(location.y - target.y) == 2 && location.y != 1))
                return false;
            else if ((Math.Abs(location.x - target.x) > 1) || (Math.Abs(location.x - target.x) == 1 && Math.Abs(location.y - target.y) > 1) ||  //iligal diagonal move
                        ((Math.Abs(location.x - target.x) == 1) && (Math.Abs(location.y - target.y) == 1) && (board.GetSquareData(target) == null) &&
                        !(opponentPawnDid2Moves && ((isWhite && target.y - 1 == ((Move)lastMove).from.y) || (!isWhite && target.y + 1 == ((Move)lastMove).from.y)))))
                return false;

            return true;
        }
    }
}
