namespace Chess {
    class Bishop : ChessPiece {
        public Bishop(bool isWhite, Location pos,Board board) : base(isWhite, pos, board) { }
        public override bool IsLegalMove(Location target) {
            var targetDiagonalLine = board.GetDiagonalSequence(location, target);
            if (targetDiagonalLine.Count == 0) //not stright line and not diagonal
                return false;
            else if (IsBlocked(targetDiagonalLine)) //have pieces on the way
                return false;
            return true;
        }
    }
}
