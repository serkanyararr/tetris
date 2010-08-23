using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Tetris.Silverlight.ViewModels;
using System.Windows.Threading;

namespace Tetris.Silverlight
{
    public partial class BricksView : UserControl
    {
        DispatcherTimer timer;
        BricksViewModel viewModel = new BricksViewModel();
        int amplitude = 5;

        public BricksView()
        {
            InitializeComponent();
            this.DataContext = viewModel;

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 3, 0);

            this.Loaded += new RoutedEventHandler(BricksView_Loaded);
        }

        void BricksView_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void UserControl_KeyUp(object sender, KeyEventArgs e)
        {
            medClick.Stop();
            medClick.Play();

            switch (e.Key)
            {
                case Key.Left:
                    viewModel.MoveLeft();
                    break;
                case Key.Right:
                    viewModel.MoveRight();
                    break;
                case Key.Down:
                    viewModel.MoveDown();
                    break;
                case Key.Up:
                    viewModel.Rotate270();
                    break;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            medIntro.Stop();
            medIntro.Play();
        }

        public void GenerateRandomPoints()
        {
            Random r = new Random();

            int pt00x = r.Next(-amplitude, amplitude);
            int pt10x = 25 + r.Next(-amplitude, amplitude);
            int pt20x = 75 + r.Next(-amplitude, amplitude);
            int pt30x = 100 + r.Next(-amplitude, amplitude);
            int pt31x = 100 + r.Next(-amplitude, amplitude);
            int pt32x = 100 + r.Next(-amplitude, amplitude);
            int pt33x = 100 + r.Next(-amplitude, amplitude);
            int pt01x = r.Next(-amplitude, amplitude);
            int pt02x = r.Next(-amplitude, amplitude);
            int pt03x = r.Next(-amplitude, amplitude);
            int pt13x = 25 + r.Next(-amplitude, amplitude);
            int pt23x = 75 + r.Next(-amplitude, amplitude);
            int pt00y = r.Next(-amplitude, amplitude);
            int pt10y = r.Next(-amplitude, amplitude);
            int pt20y = r.Next(-amplitude, amplitude);
            int pt30y = r.Next(-amplitude, amplitude);
            int pt31y = 25 + r.Next(-amplitude, amplitude);
            int pt32y = 75 + r.Next(-amplitude, amplitude);
            int pt33y = 100 + r.Next(-amplitude, amplitude);
            int pt01y = 25 + r.Next(-amplitude, amplitude);
            int pt02y = 75 + r.Next(-amplitude, amplitude);
            int pt03y = 100 + r.Next(-amplitude, amplitude);
            int pt13y = 100 + r.Next(-amplitude, amplitude);
            int pt23y = 100 + r.Next(-amplitude, amplitude);

            viewModel.P1Data = string.Format("M {0},{1} C {2},{3} {4},{5} {6},{7}", pt00x, pt00y, pt01x, pt01y, pt02x, pt02y, pt03x, pt03y);
            viewModel.P2Data = string.Format("M {0},{1} C {2},{3} {4},{5} {6},{7}", pt30x, pt30y, pt31x, pt31y, pt32x, pt32y, pt33x, pt33y);
            viewModel.P3Data = string.Format("M {0},{1} C {2},{3} {4},{5} {6},{7}", pt00x, pt00y, pt10x, pt10y, pt20x, pt20y, pt30x, pt30y);
            viewModel.P4Data = string.Format("M {0},{1} C {2},{3} {4},{5} {6},{7}", pt03x, pt03y, pt13x, pt13y, pt23x, pt23y, pt33x, pt33y);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            medIntro.Stop();
        }
    }
}
