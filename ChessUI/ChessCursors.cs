using System;
using System.IO;
using System.Windows.Input;
using System.Windows;


namespace ChessUI
{
    public static class ChessCursors
    {

        public static readonly Cursor WhiteCursor = LoadCursor("Assets/cursorw.cur");
        public static readonly Cursor BlackCursor = LoadCursor("Assets/cursorb.cur");
        private static Cursor LoadCursor(string filePath)
        {
            Stream stream = Application.GetResourceStream(new Uri(filePath, UriKind.Relative)).Stream;
            return new Cursor(stream,true);
        }
    }
}
