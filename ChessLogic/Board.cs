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
        private readonly Piece[,] pieces = new Piece[11, 10];

        public Piece this[int row, int col]
        {
            get { return pieces[row, col]; }
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
            this[1, 0] = new Rook(Player.Black);
            this[1, 1]= new Knight(Player.Black);
            this[1, 2]= new Elephant(Player.Black); 
            this[1, 3]=new Bishop(Player.Black);
            this[1, 4]=new Queen(Player.Black);
            this[1, 5]=new King(Player.Black);
            this[1, 6] = new Bishop(Player.Black);
            this[1, 7]=new Elephant(Player.Black);
            this[1, 8]=new Knight(Player.Black);
            this[1, 9]=new Rook(Player.Black);


            this[9, 0] = new Rook(Player.White);
            this[9, 1] = new Knight(Player.White);
            this[9, 2] = new Elephant(Player.White);
            this[9, 3] = new Bishop(Player.White);
            this[9, 4] = new Queen(Player.White);
            this[9, 5] = new King(Player.White);
            this[9, 6] = new Bishop(Player.White);
            this[9, 7] = new Elephant(Player.White);
            this[9, 8] = new Knight(Player.White);
            this[9, 9] = new Rook(Player.White);

            for (int i = 0; i < 10; i++)
            {
                this[2, i]=new Pawn(Player.Black);
                this[8,i]=new Pawn(Player.White);
            }
        }
        public static bool IsInSide(Position pos)
        {
            return pos.Row>=0 &&pos.Row<11 && pos.Column>=0 && pos.Column<10;
        }

        public  bool IsEmpty(Position pos)
        {
            return this[pos] == null;
        }
    }
}
