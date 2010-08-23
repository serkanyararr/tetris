using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Tetris.Silverlight.Core.Shapes;
using System.Windows.Media;

namespace Tetris.Silverlight.Core
{
    public abstract class BaseBricksArray : IBricksArray
    {
        #region Özellikler
        protected int width = 0;
        protected int height = 0;
        protected string shapeString = "";
        protected IBrick[,] shapeArray = null;
        protected IPresenter presenter = null;
        #endregion

        #region Metodlar
        public string GetStringFromShapeArray()
        {
            string ret = "";
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (shapeArray[column, row] != null)
                    {
                        //ret += ((int)(shapeArray[column, row].Color)).ToString();
                        ret += "1";
                    }
                    else
                    {
                        ret += "0";
                    }
                }
            }
            return ret;
        }

        protected Color GetShapeColorFromInteger(int c)
        {
            Color ret = Colors.White;

            switch (c)
            {
                case 1:
                    ret = Colors.Blue;
                    break;
                case 2:
                    ret = Colors.DarkGray;
                    break;
                case 3:
                    ret = Colors.Green;
                    break;
                case 4:
                    ret = Colors.Orange;
                    break;
                case 5:
                    ret = Colors.LightGray;
                    break;
                case 6:
                    ret = Colors.Red;
                    break;
                case 7:
                    ret = Colors.Purple;
                    break;
                case 8:
                    ret = Colors.White;
                    break;
                case 9:
                    ret = Colors.Yellow;
                    break;
            }

            return ret;
        }

        public virtual void InitializeArray()
        {
            shapeArray = new IBrick[width, height];
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    shapeArray[column, row] = null;
                }
            }
        }

        private string Replicate(string s, int n)
        {
            string ret = "";
            for (int i = 0; i < n; i++)
            {
                ret += s;
            }
            return ret;
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public string ShapeString
        {
            get { return GetStringFromShapeArray(); }
        }

        public IBrick[,] ShapeArray
        {
            get { return shapeArray; }
        }

        public IPresenter Presenter
        {
            get { return presenter; }
            set { presenter = value; }
        }
        #endregion
    }
}
