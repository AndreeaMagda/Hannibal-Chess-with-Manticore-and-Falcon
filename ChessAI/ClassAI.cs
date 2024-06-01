using ChessLogic;
using System.Numerics;

namespace ChessAI
{
    public class ClassAI
    {

        public Move GetBestMove(GameState state, int depth)
        {
            var bestMove = default(Move);
            var bestValue = int.MinValue;

            foreach (var move in state.AllLegalMovesFor(state.CurrentPlayer))
            {
                var clone = state.Clone();
                clone.MakeMove(move);
                var boardValue = -Minimax(clone, depth - 1);

                if (boardValue > bestValue)
                {
                    bestValue = boardValue;
                    bestMove = move;
                }
            }

            return bestMove;
        }

        private int Minimax(GameState state, int depth)
        {
            if (depth == 0 || state.IsGameOver())
            {
                return Evaluate(state);
            }

            var maxValue = int.MinValue;

            foreach (var move in state.AllLegalMovesFor(state.CurrentPlayer))
            {
                var clone = state.Clone();
                clone.MakeMove(move);
                maxValue = Math.Max(maxValue, -Minimax(clone, depth - 1));
            }

            return maxValue;
        }

        private int Evaluate(GameState state)
        {
            int whiteScore = 0;
            int blackScore = 0;

            foreach (var pos in state.Board.PiecePositionsFor(Player.White))
            {
                var piece = state.Board[pos];
                whiteScore += GetPieceValue(piece);
            }

            foreach (var pos in state.Board.PiecePositionsFor(Player.Black))
            {
                var piece = state.Board[pos];
                blackScore += GetPieceValue(piece);
            }

            return whiteScore - blackScore;
        }


        private int GetPieceValue(Piece piece)
        {
            switch (piece.Type)
            {
                case PieceType.Pawn:
                    return 1;
                case PieceType.Knight:
                case PieceType.Bishop:
                    return 3;
                case PieceType.Rook:
                    return 5;
                case PieceType.Queen:
                    return 9;
                case PieceType.King:
                    return 0;
                case PieceType.Falcon:
                    return 7; // Assign a value for the Falcon piece type
                case PieceType.Manticore:
                    return 6; // Assign a value for the Manticore piece type

                case PieceType.Elephant:
                    return 4; // Assign a value for the Elephant piece type

                default:
                    throw new Exception("Unknown piece type: " + piece.Type);
            }
        }


    }
}
