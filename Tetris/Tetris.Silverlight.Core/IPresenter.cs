using System;
using System.Collections.Generic;
using System.Text;
using Tetris.Silverlight.Core;
using Tetris.Silverlight.Core.Shapes;

namespace Tetris.Silverlight.Core
{
    public interface IPresenter
    {
        void HighlightCompletedRow(int row);
        void UpdateBoardView(string ArrayString, IBrick[,] brickArray, int width, int height);
        void UpdateScoreView(int score, int hiScore, int lines, int level, IShape next);
        IView View { get; set; }
        int Level { get; }
        void InitializeBoard();
        void GameOver();
        void Tick();
    }
}
