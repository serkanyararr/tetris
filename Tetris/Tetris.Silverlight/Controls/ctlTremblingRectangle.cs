using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Tetris.Silverlight.Controls
{
    public class ctlTremblingRectangle : Path
    {
        Color color = Colors.Transparent;

        Point p00 = new Point(0, 0);
        Point p01 = new Point(0, 25);
        Point p02 = new Point(0, 75);
        Point p03 = new Point(0, 100);

        Point p30 = new Point(0, 0);
        Point p31 = new Point(0, 25);
        Point p32 = new Point(0, 75);
        Point p33 = new Point(0, 100);

        Point p10 = new Point(25, 0);
        Point p20 = new Point(75, 0);

        Point p13 = new Point(25, 100);
        Point p23 = new Point(75, 100);

        int amplitude = 1;

        public ctlTremblingRectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public void GenerateRandomPoints()
        {
            double h = Height;
            double w = Width;

            Random rnd = new Random();

            p00 = new Point(5 + rnd.Next(-amplitude, amplitude), 5 + rnd.Next(-amplitude, amplitude));
            p01 = new Point(5 + rnd.Next(-amplitude, amplitude), 1 * h / 4 + rnd.Next(-amplitude, amplitude));
            p02 = new Point(5 + rnd.Next(-amplitude, amplitude), 3 * h / 4 + rnd.Next(-amplitude, amplitude));
            p03 = new Point(5 + rnd.Next(-amplitude, amplitude), -5 + h + rnd.Next(-amplitude, amplitude));

            p30 = new Point(-5 + w + rnd.Next(-amplitude, amplitude), 5 + rnd.Next(-amplitude, amplitude));
            p31 = new Point(-5 + w + rnd.Next(-amplitude, amplitude), 1 * h / 4 + rnd.Next(-amplitude, amplitude));
            p32 = new Point(-5 + w + rnd.Next(-amplitude, amplitude), 3 * h / 4 + rnd.Next(-amplitude, amplitude));
            p33 = new Point(-5 + w + rnd.Next(-amplitude, amplitude), -5 + h + rnd.Next(-amplitude, amplitude));

            p10 = new Point(1 * w / 4 + rnd.Next(-amplitude, amplitude), 5 + rnd.Next(-amplitude, amplitude));
            p20 = new Point(3 * w / 4 + rnd.Next(-amplitude, amplitude), 5 + rnd.Next(-amplitude, amplitude));

            p13 = new Point(1 * w / 4 + rnd.Next(-amplitude, amplitude), -5 + h + rnd.Next(-amplitude, amplitude));
            p23 = new Point(3 * w / 4 + rnd.Next(-amplitude, amplitude), -5 + h + rnd.Next(-amplitude, amplitude));

            var figures = new PathFigureCollection();

            var pathSegmentCollection1 = new PathSegmentCollection();
            var pathSegmentCollection2 = new PathSegmentCollection();
            var pathSegmentCollection3 = new PathSegmentCollection();
            var pathSegmentCollection4 = new PathSegmentCollection();

            PointCollection pointCollection = new PointCollection();
            pointCollection.Add(p10);
            pointCollection.Add(p20);
            pointCollection.Add(p30);
            pointCollection.Add(p31);
            pointCollection.Add(p32);
            pointCollection.Add(p33);
            pointCollection.Add(p23);
            pointCollection.Add(p13);
            pointCollection.Add(p03);
            pointCollection.Add(p02);
            pointCollection.Add(p01);
            pointCollection.Add(p00);

            pathSegmentCollection4.Add(new PolyBezierSegment() { Points = pointCollection });
            figures.Add(new PathFigure() { StartPoint = p00, Segments = pathSegmentCollection4, IsClosed = false });

            Data = new PathGeometry()
            {
                Figures = figures
            };
            Stroke = new SolidColorBrush(Colors.Black);
            StrokeThickness = 2;
            //Fill = new SolidColorBrush(color);
            this.Margin = new Thickness(0, 0, 0, 0);
        }

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
    }
}
