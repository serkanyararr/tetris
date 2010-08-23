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
    public class ctlTremblingGrid : Grid
    {
        static DispatcherTimer timer;
        static List<ctlTremblingGrid> observers = new List<ctlTremblingGrid>();
        ctlTremblingRectangle rect;

        public ctlTremblingGrid()
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
            //ctlTremblingRectangle rect = new ctlTremblingRectangle(this.Width, this.Height);
            if (rect != null)
                this.Children.Remove(rect);

            rect = new ctlTremblingRectangle(40, 20);
            
            rect.Color = Colors.Transparent;

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
