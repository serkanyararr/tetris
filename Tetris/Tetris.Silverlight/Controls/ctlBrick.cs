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
using System.Collections.Generic;
using System.Windows.Threading;

namespace Tetris.Silverlight.Controls
{
    public class ctlBrick : Grid
    {
        #region attribute
        static DispatcherTimer timer;
        static List<ctlBrick> observers = new List<ctlBrick>();
        
        private static DependencyProperty PathFillColorProperty =
        DependencyProperty.Register("PathFillColor", typeof(Color), typeof(ctlBrick), new PropertyMetadata(FrameworkElementValueChanged));

        private static DependencyProperty TimerProperty =
        DependencyProperty.Register("BrickTimer", typeof(DispatcherTimer), typeof(ctlBrick), new PropertyMetadata(FrameworkElementValueChanged));

        Path path;

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

        List<Point> points = new List<Point>();
        List<Point> originalPoints = new List<Point>();

        int amplitude = 1;

        #endregion attribute

        #region constructors
        public ctlBrick()
        {
            this.Width = 20;
            this.Height = 20;

            this.Loaded += new RoutedEventHandler(ctlBrick_Loaded);
            this.Unloaded += new RoutedEventHandler(ctlBrick_Unloaded);
        }
        #endregion constructors

        #region methods
        public void GenerateRandomPoints()
        {
            this.Children.Remove(path);
            if (color != Colors.Transparent)
            {
                double h = this.Height;
                double w = this.Width;

                Random rnd = new Random();

                p00 = new Point(2 + rnd.Next(-amplitude, amplitude), 2 + rnd.Next(-amplitude, amplitude));
                p01 = new Point(2 + rnd.Next(-amplitude, amplitude), 1 * h / 4 + rnd.Next(-amplitude, amplitude));
                p02 = new Point(2 + rnd.Next(-amplitude, amplitude), 3 * h / 4 + rnd.Next(-amplitude, amplitude));
                p03 = new Point(2 + rnd.Next(-amplitude, amplitude), -2 + h + rnd.Next(-amplitude, amplitude));

                p30 = new Point(-2 + w + rnd.Next(-amplitude, amplitude), 2 + rnd.Next(-amplitude, amplitude));
                p31 = new Point(-2 + w + rnd.Next(-amplitude, amplitude), 1 * h / 4 + rnd.Next(-amplitude, amplitude));
                p32 = new Point(-2 + w + rnd.Next(-amplitude, amplitude), 3 * h / 4 + rnd.Next(-amplitude, amplitude));
                p33 = new Point(-2 + w + rnd.Next(-amplitude, amplitude), -2 + h + rnd.Next(-amplitude, amplitude));

                p10 = new Point(1 * w / 4 + rnd.Next(-amplitude, amplitude), 2 + rnd.Next(-amplitude, amplitude));
                p20 = new Point(3 * w / 4 + rnd.Next(-amplitude, amplitude), 2 + rnd.Next(-amplitude, amplitude));

                p13 = new Point(1 * w / 4 + rnd.Next(-amplitude, amplitude), -2 + h + rnd.Next(-amplitude, amplitude));
                p23 = new Point(3 * w / 4 + rnd.Next(-amplitude, amplitude), -2 + h + rnd.Next(-amplitude, amplitude));

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
                figures.Add(new PathFigure() { StartPoint = p00, Segments = pathSegmentCollection4, IsClosed = true });

                path = new Path()
                {
                    Data = new PathGeometry()
                    {
                        Figures = figures
                    },
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 2,
                    Fill = new SolidColorBrush(color)
                };

                this.Children.Add(path);
            }
        }

        public Color PathFillColor
        {
            get { return (Color)GetValue(PathFillColorProperty); }
            set { SetValue(PathFillColorProperty, value); }
        }

        public DispatcherTimer BrickTimer
        {
            get { return (DispatcherTimer)GetValue(TimerProperty); }
            set { SetValue(TimerProperty, value); }
        }

        #endregion methods

        #region properties

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

        #endregion properties

        #region events

        void ctlBrick_Loaded(object sender, RoutedEventArgs e)
        {
            if (timer == null)
            {
                timer = new DispatcherTimer()
                {
                    Interval = new TimeSpan(0, 0, 0, 0, 100)
                };
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }

            double h = this.Height;
            double w = this.Width;

            Random rnd = new Random();

            p00 = new Point(2 + rnd.Next(-amplitude, amplitude), 2 + rnd.Next(-amplitude, amplitude));
            p01 = new Point(2 + rnd.Next(-amplitude, amplitude), 1 * h / 4 + rnd.Next(-amplitude, amplitude));
            p02 = new Point(2 + rnd.Next(-amplitude, amplitude), 3 * h / 4 + rnd.Next(-amplitude, amplitude));
            p03 = new Point(2 + rnd.Next(-amplitude, amplitude), -2 + h + rnd.Next(-amplitude, amplitude));

            p30 = new Point(-2 + w + rnd.Next(-amplitude, amplitude), 2 + rnd.Next(-amplitude, amplitude));
            p31 = new Point(-2 + w + rnd.Next(-amplitude, amplitude), 1 * h / 4 + rnd.Next(-amplitude, amplitude));
            p32 = new Point(-2 + w + rnd.Next(-amplitude, amplitude), 3 * h / 4 + rnd.Next(-amplitude, amplitude));
            p33 = new Point(-2 + w + rnd.Next(-amplitude, amplitude), -2 + h + rnd.Next(-amplitude, amplitude));

            p10 = new Point(1 * w / 4 + rnd.Next(-amplitude, amplitude), 2 + rnd.Next(-amplitude, amplitude));
            p20 = new Point(3 * w / 4 + rnd.Next(-amplitude, amplitude), 2 + rnd.Next(-amplitude, amplitude));

            p13 = new Point(1 * w / 4 + rnd.Next(-amplitude, amplitude), -2 + h + rnd.Next(-amplitude, amplitude));
            p23 = new Point(3 * w / 4 + rnd.Next(-amplitude, amplitude), -2 + h + rnd.Next(-amplitude, amplitude));

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
            figures.Add(new PathFigure() { StartPoint = p00, Segments = pathSegmentCollection4, IsClosed = true });

            path = new Path()
            {
                Data = new PathGeometry()
                {
                    Figures = figures
                },
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2,
                Fill = new SolidColorBrush(color)
            };

            observers.Add(this);
        }

        void ctlBrick_Unloaded(object sender, RoutedEventArgs e)
        {
            observers.Remove(this);
        }

        static void timer_Tick(object sender, EventArgs e)
        {
            foreach (var ctl in observers)
            {
                ctl.GenerateRandomPoints();
            }
        }

        static void FrameworkElementValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ctlBrick field = sender as ctlBrick;

            if (e.Property.Equals(PathFillColorProperty))
            {
                field.Color = (Color)e.NewValue;
            }
        }

        #endregion events
    }
}
