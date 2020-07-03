namespace Chess {
    class Queen : ChessPiece {
        public Queen(bool isWhite, Location pos, Board board) : base(isWhite, pos, board) { }

        public override bool IsLegalMove(Location target) {
            var targetDiagonalLine = board.GetDiagonalSequence(location, target);
            var targetStrightLine = board.GetStrightSequence(location, target);
            if (targetDiagonalLine.Count == 0 && targetStrightLine.Count == 0) //not stright line and not diagonal
                return false;
            else if ((targetDiagonalLine.Count == 0 && IsBlocked(targetStrightLine)) || (targetStrightLine.Count == 0 && IsBlocked(targetDiagonalLine))) //have pieces on the way
                return false;
            return true;
        }
    }
}
