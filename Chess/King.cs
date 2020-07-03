using System;

namespace Chess {
    class King : ChessPiece {
        public King(bool isWhite, Location pos, Board board) : base(isWhite, pos, board) { }
        bool canCastleRight = true, canCastleLeft = true;
        public void DeniedallCastling() {
            canCastleLeft = false;
            canCastleRight = false;
        }
        public void DeniedRightCastling() {
            canCastleRight = false;
        }
        public void DeniedaLeftCastling() {
            canCastleLeft = false;
        }
        public override bool IsLegalMove(Location target) {
            if (Math.Abs(target.x - location.x) == 2 && target.y == location.y &&
               ((location.y == 7 && isWhite) || (location.y == 0 && !isWhite))) { //casteling
                //if (IsInCheck())
                   // return false;
                if (target.x > location.x) { //casteling right
                    if (!canCastleRight)
                        return false;
                    else if (board.GetSquareData(new Location(location.x + 1, location.y)) != null || board.GetSquareData(new Location(location.x + 2, location.y)) != null) //pices on the way
                        return false;
                    else if (IsMoveMakeCheck(new Location(location.x + 1, location.y)) || IsMoveMakeCheck(new Location(location.x + 2, location.y))) //threat on the way
                        return false;
                    return true;
                }
                else { //casteling left
                    if (!canCastleLeft)
                        return false;
                    else if (board.GetSquareData(new Location(location.x - 1, location.y)) != null || board.GetSquareData(new Location(location.x - 2, location.y)) != null) //pices on the way
                        return false;
                    else if (IsMoveMakeCheck(new Location(location.x - 1, location.y)) || IsMoveMakeCheck(new Location(location.x - 2, location.y))) //threat on the way
                        return false;
                    return true;
                }
            }
            else if (Math.Abs(target.x - location.x) > 1 || Math.Abs(target.y - location.y) > 1) //no more then one step
                return false;
            //else if can't be tight to king!!!'
            return true;
        }
    }
}
