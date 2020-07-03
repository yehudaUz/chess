namespace Chess {
    class Knight : ChessPiece {
        public Knight(bool isWhite, Location pos, Board board) : base(isWhite, pos, board) { }
        public override bool IsLegalMove(Location target) {
            var targetXY = target;
            if (new Location(location.x + 2, location.y + 1) != targetXY && new Location(location.x + 2, location.y - 1) != targetXY &&
                new Location(location.x - 2, location.y + 1) != targetXY && new Location(location.x - 2, location.y - 1) != targetXY &&
                new Location(location.x + 1, location.y + 2) != targetXY && new Location(location.x - 1, location.y + 2) != targetXY &&
                new Location(location.x + 1, location.y - 2) != targetXY && new Location(location.x - 1, location.y - 2) != targetXY)
                return false;

            return true;
        }
    }
}
