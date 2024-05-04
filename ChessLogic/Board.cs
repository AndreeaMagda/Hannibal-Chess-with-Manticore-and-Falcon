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
            this[0, 1]= new Knight(Player.Black);
            this[0, 2]= new Elephant(Player.Black); 
            this[0, 3]=new Bishop(Player.Black);
            this[0, 4]=new Queen(Player.Black);
            this[0, 5]=new King(Player.Black);
            this[0, 6] = new Bishop(Player.Black);
            this[0,7]=new Elephant(Player.Black);
            this[0,8]=new Knight(Player.Black);
            this[0,9]=new Rook(Player.Black);


            this[8, 0] = new Rook(Player.White);
            this[8, 1] = new Knight(Player.White);
            this[8, 2] = new Elephant(Player.White);
            this[8, 3] = new Bishop(Player.White);
            this[8, 4] = new Queen(Player.White);
            this[8, 5] = new King(Player.White);
            this[8, 6] = new Bishop(Player.White);
            this[8, 7] = new Elephant(Player.White);
            this[8, 8] = new Knight(Player.White);
            this[8, 9] = new Rook(Player.White);

            for (int i = 0; i < 10; i++)
            {
                this[1, i]=new Pawn(Player.Black);
                this[7,i]=new Pawn(Player.White);
            }
        }
        public static bool IsInSide(Position pos)
        {
            return pos.Row>=0 &&pos.Row<9 && pos.Column>=0 && pos.Column<=10;
        }

        public  bool IsEmpty(Position pos)
        {
            return this[pos] == null;
        }
    }
}
