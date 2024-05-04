using ChessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Image[,] pieceImages = new Image[9, 10];

        private GameState gameState;
        public MainWindow()
        {
            InitializeComponent();
            InitializeBoard();
            gameState=new GameState(Player.White,Board.Initial());
            DrawBoard(gameState.Board);
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    Image image=new Image();
                    pieceImages[row,col] = image;
                    PieceGrid.Children.Add(image);
                }
            }
        }

        private void DrawBoard(Board board)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    Piece piece = board[row,col];
                    pieceImages[row, col].Source = Images.GetImage(piece);
                }
            }
        }
    }
}
