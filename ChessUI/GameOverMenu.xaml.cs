using ChessLogic;
using System;
using System.Windows.Controls;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for GameOverMenu.xaml
    /// </summary>
    public partial class GameOverMenu : UserControl
    {

        public event Action<Option> OptionSelected;
        public GameOverMenu(GameState gameState)
        {
            InitializeComponent();

            Result result = gameState.Result;
            WinnerText.Text = GetWinnerText(result.Winner);
            ReasonText.Text = GetReasonText(result.Reason, gameState.CurrentPlayer);

        }

        private static string GetWinnerText(Player winner)
        {
            return winner switch
            {
                Player.White => "White wins!",
                Player.Black => "Black wins!",
                _ => "It's a draw!"
            };
        }

        private static string PlayString(Player player)
        {
            return player switch
            {
                Player.White => "White",
                Player.Black => "Black",
                _ => " "
            };
        }

        private static string GetReasonText(EndReason reason,Player currentPlayer)
        {
            return reason switch
            {
                EndReason.Stalemate=>$"Stealmate- {PlayString(currentPlayer)} has no legal moves",
                EndReason.Checkmate => $"Checkmate- {PlayString(currentPlayer)} is in checkmate",
                EndReason.FiftyMoveRule => "Fifty move rule",
                EndReason.InsufficientMaterial => "Insufficient material",
                EndReason.ThreefoldRepetition => "Threefold repetition",
                _ => " "
            };
        }

        private void Restart_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Restart);
        }

        private void Exit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Exit);
        }
    }
}
