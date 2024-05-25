using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Elephant:Piece
    {
        public override PieceType Type => PieceType.Elephant;
        public override Player Color { get; }
        public Elephant(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Elephant copy = new Elephant(Color);
            copy.HasMoved = HasMoved;

            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            var moves = new List<Move>();

        
            var directions = new Direction[] { Direction.NorthEast, Direction.NorthWest, Direction.SouthEast, Direction.SouthWest };

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
