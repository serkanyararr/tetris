using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris.Silverlight.Core.Exceptions
{
    public class InvalidShapeSizeException : Exception
    {
    }

    public class InvalidShapeStringCharacterException : Exception
    {
    }

    public class PieceIsOffLimitsException : Exception
    {
    }

    public class NullContainerBoardException : Exception
    {
    }

    public class CantSetShapePosition : Exception
    {
    }
}
