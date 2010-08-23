using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Text;
using Tetris.Silverlight.Core.Shapes;
using System.Windows.Media;

namespace Tetris.Silverlight.Core
{
    public interface IBoard
    {
        bool TestPieceOnPosition(IShape shape, int x, int y);
        void RemovePieceFromCurrentPosition(IShape shape);
        void PutPieceOnPosition(IShape shape, int x, int y);
        void ProcessNextMove();
        Color BackColor { get; set; }
        int Width { get; }
        int Height { get; }
        int Level { get; }
    }
}
