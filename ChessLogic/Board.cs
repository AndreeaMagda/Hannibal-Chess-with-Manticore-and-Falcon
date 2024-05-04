using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Board
    {
        private readonly Piece[,] pieces = new Piece[9, 10];

        public Piece this[int row, int col]
        {
            get{ return pieces[row, col]; }
            set { pieces[row, col] = value;}
        }
        public Piece this[Position pos]
        {
            get { return this[pos.Row,pos.Column]; }
            set { this[pos.Row, pos.Column] = value;}
        }

        public static Board Initial()
        {
            Board board=new Board();
            board.AddStartPieces();
            return board;
        }

        private void AddStartPieces()
        {
            this[0, 0] = new Rook(Player.Black);
        }
    }
}
