using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Falcon:Piece
    {
        public override PieceType Type => PieceType.Falcon;
        public override Player Color { get; }

        private static readonly Direction[] directions = new Direction[]
        {
            Direction.North,
            Direction.East,
            Direction.South,
            Direction.West,
            Direction.NorthEast,
            Direction.NorthWest,
            Direction.SouthEast,
            Direction.SouthWest,
        };
        public Falcon(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Falcon copy = new Falcon(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

      

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            var moves = new List<Move>();

            var directions = new Direction[] { Direction.North, Direction.East, Direction.South, Direction.West, Direction.NorthEast, Direction.NorthWest, Direction.SouthEast, Direction.SouthWest };

            foreach (var direction in directions)
            {
                var positions = MovePositionInDirection(from, board, direction).ToList();

                if (positions.Count >= 1)
                {
                    moves.Add(new NormalMove(from, positions[0]));
                }

                if (positions.Count >= 2)
                {
                    moves.Add(new NormalMove(from, positions[1]));
                }
            }

            return moves;
        }










    }
}
