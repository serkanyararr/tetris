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
using System.Windows.Threading;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tetris.Silverlight.Controls
{
    public class ctlTremblingCanvas : Canvas
    {
        static DispatcherTimer timer;
        static List<ctlTremblingCanvas> observers = new List<ctlTremblingCanvas>();
        ctlTremblingRectangle rect;

        public ctlTremblingCanvas()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                this.Loaded += new RoutedEventHandler(ctlTremblingGrid_Loaded);
                this.Unloaded += new RoutedEventHandler(ctlTremblingGrid_Unloaded);

            }
        }

        void ctlTremblingGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if (timer == null)
            {
                timer = new DispatcherTimer()
                {
                    Interval = new TimeSpan(0, 0, 0, 0, 1000)
                };
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }

            observers.Add(this);
            GenerateRandomPoints();
        }

        void ctlTremblingGrid_Unloaded(object sender, RoutedEventArgs e)
        {
            observers.Remove(this);
        }

        public bool IsDesignTime()
        {
            try
            {
                var host = Application.Current.Host.Source;
                return false;
            }
            catch
            {
                return true;
            }
        }

        public void GenerateRandomPoints()
        {
            ctlTremblingRectangle rect = new ctlTremblingRectangle(this.Width, this.Height);
            rect.Color = Colors.Transparent;

            if (rect != null)
                this.Children.Remove(rect);

            this.Children.Add(rect);

            rect.GenerateRandomPoints();
        }

        static void timer_Tick(object sender, EventArgs e)
        {
            //foreach (var ctl in observers)
            //{
            //    ctl.GenerateRandomPoints();
            //}
        }
    }
}
