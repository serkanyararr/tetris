using System;
using System.Collections.Generic;
using System.Text;
using Tetris.Silverlight.Core.Shapes;

namespace Tetris.Silverlight.Core
{
    public interface IView
    {
        void DisplayBoard(string arrayString, IBrick[,] brickArray, int width, int height);
        void DisplayScore(int score, int hiScore, int lines, int level, IShape next);
        void GameOver();
        void HighlightCompletedRow(int row);
    }
}
