using System;
using System.Collections.Generic;
using System.Text;
using Tetris.Silverlight.Core.Shapes;
using System.Windows.Media;
using System.ComponentModel;

namespace Tetris.Silverlight.Core
{
    public interface IBrick : INotifyPropertyChanged
    {
        double X { get; set; }
        double Y { get; set; }
        Color Color { get; set; }
    }
}
