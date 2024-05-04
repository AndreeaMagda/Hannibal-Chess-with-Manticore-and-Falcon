using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ChessLogic;

namespace ChessUI
{
    public static class Images
    {
        private static readonly Dictionary<PieceType, ImageSource> whiteSources = new()
        {
            {PieceType.Pawn,LoadImage("Assets/wpawn.png") },
            {PieceType.Elephant,LoadImage("Assets/welephant.png") },
            {PieceType.Rook,LoadImage("Assets/wrook.png")},
            {PieceType.Bishop,LoadImage("Assets/wbishop.png")},
            {PieceType.Queen,LoadImage("Assets/wqueen.png")},
            {PieceType.King,LoadImage("Assets/wking.png")},
            {PieceType.Knight,LoadImage("Assets/wknight.png")}

        };

        private static readonly Dictionary<PieceType, ImageSource> blackSources = new()
        {
            {PieceType.Pawn,LoadImage("Assets/bpawn.png") },
            {PieceType.Elephant,LoadImage("Assets/belephant.png") },
            {PieceType.Rook,LoadImage("Assets/brook.png")},
            {PieceType.Bishop,LoadImage("Assets/bbishop.png")},
            {PieceType.Queen,LoadImage("Assets/bqueen.png")},
            {PieceType.King,LoadImage("Assets/bking.png")},
            {PieceType.Knight,LoadImage("Assets/bknight.png")}

        };
        private static ImageSource LoadImage(String filePath)
        {
            return new BitmapImage(new Uri(filePath,UriKind.Relative));
        }
        public static ImageSource GetImage(Player color,PieceType type)
        {
            return color switch
            {
                Player.White => whiteSources[type],
                Player.Black => blackSources[type],
                _ => null
            };
        }
        public static ImageSource GetImage(Piece piece)
        {
            if(piece == null)
            {
                return null;
            }
            return GetImage(piece.Color, piece.Type);
        }
    }
}
