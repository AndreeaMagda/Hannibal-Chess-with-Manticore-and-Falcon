using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Rook: Piece
    {
        public override PieceType Type => PieceType.Rook;
        public override Player Color { get; }

        private static readonly Direction[] directions = new Direction[]
        {
            Direction.North, 
            Direction.South, 
            Direction.East,
            Direction.West,
        };
        public Rook(Player color)
        {
            Color = color;
        }

        public override Rook Copy()
        {
            Rook copy = new Rook(Color);
            copy.HasMoved = HasMoved;

            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositionsInDirections(from, board, directions).Select(to => new NormalMove(from, to));
        }
    }
}
