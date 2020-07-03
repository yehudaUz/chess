namespace Chess {
    class Rook : ChessPiece {
        public Rook(bool isWhite, Location pos, Board board) : base(isWhite, pos, board) { }

        public override bool IsLegalMove(Location target) {
            var targetSequenceLine = board.GetStrightSequence(location, target);
            if (targetSequenceLine.Count == 0) //not stright line and not diagonal
                return false;
            else if (IsBlocked(targetSequenceLine)) //have pieces on the way
                return false;
            return true;
        }
    }
}
