﻿using ChessLogic;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for PromotionMenu.xaml
    /// </summary>
    public partial class PromotionMenu : UserControl
    {
        public event Action<PieceType> OptionSelected;

        public PromotionMenu(Player player)
        {
            InitializeComponent();

            QueenImg.Source = Images.GetImage(player, PieceType.Queen);
            RookImg.Source = Images.GetImage(player, PieceType.Rook);
            BishopImg.Source = Images.GetImage(player, PieceType.Bishop);
            KnightImg.Source = Images.GetImage(player, PieceType.Knight);
        }

        private void QueenImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OptionSelected?.Invoke(PieceType.Queen);
        }

        private void RookImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OptionSelected?.Invoke(PieceType.Rook);
        }

        private void BishopImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OptionSelected?.Invoke(PieceType.Bishop);
        }

        private void KnightImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OptionSelected?.Invoke(PieceType.Knight);
        }
    }
}
