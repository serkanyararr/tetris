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
using System.Collections.ObjectModel;
using Tetris.Silverlight.Core;
using System.Windows.Threading;
using System.ComponentModel;
using System.Text;
using Tetris.Silverlight.Core.Shapes;
using Tetris.Silverlight.Commands;
using SilverlightCommands;

namespace Tetris.Silverlight.ViewModels
{
    public class BricksViewModel : IView, INotifyPropertyChanged
    {
        ObservableNotifiableCollection<IBrick> bricks = new ObservableNotifiableCollection<IBrick>();
        ObservableNotifiableCollection<IBrick> nextShapeBricks = new ObservableNotifiableCollection<IBrick>();

        int score = 0;
        int hiScore = 0;
        int lines = 0;
        int level = 0;
        string next = "";

        DispatcherTimer timer = new DispatcherTimer();

        private BricksPresenter presenter = null;
        private string lastArrayString = "";

        string p1Data = "M 0,0 C 25,0 75,0 100,0";
        string p2Data = "M 0,0 C 0,25 0,75 0,100";
        string p3Data = "M 0,100 C 25,100 75,100 100,100";
        string p4Data = "M 100,0 C 100,25 100,75 100,100";
        int strokeThickness = 7;

        bool isIntroVisible = true;
        bool isGameOverVisible = false;
        bool isGamePausedVisible = false;

        bool startCanExecute = true;
        bool pauseCanExecute = false;
        bool stopCanExecute = false;

        bool isPlaying = false;

        string pauseText = "Pause";

        public BricksViewModel()
        {
            presenter = new BricksPresenter(this);
            presenter.InitializeBoard();

            for (int row = 0; row < presenter.Height; row++)
            {
                for (int col = 0; col < presenter.Width; col++)
                {
                    bricks.Add(new Brick(col, row, Colors.Transparent));
                }
            }

            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    var b = new Brick(col, row, Colors.Transparent);
                    nextShapeBricks.Add(b);
                    b.X = b.X;
                    b.Y = b.Y;
                }
            }

            //bricks.Add(new Brick(0, 0, Color.FromArgb(255, 255, 80, 80)));
            //bricks.Add(new Brick(1, 0, Color.FromArgb(255, 80, 255, 80)));
            //bricks.Add(new Brick(2, 0, Color.FromArgb(255, 80, 80, 255)));

            this.Level = level;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            foreach (var b in bricks)
            {
                b.X = b.X;
                b.Y = b.Y;
            }
            presenter.Tick();
        }

        public ObservableNotifiableCollection<IBrick> Bricks
        {
            get
            {
                return bricks;
            }
            set
            {
                bricks = value;
            }
        }

        public ObservableNotifiableCollection<IBrick> NextShapeBricks
        {
            get
            {
                return nextShapeBricks;
            }
            set
            {
                nextShapeBricks = value;
            }
        }

        public void HighlightCompletedRow(int row)
        {
            throw new NotImplementedException();
        }

        //public void UpdateBoardView(string ArrayString, IBrick[,] brickArray, int width, int height)
        //{
        //    if (bricks.Count > 0)
        //    {
        //        for (int col = 0; col < width; col++)
        //        {
        //            for (int row = 0; row < height; row++)
        //            {
        //                if (brickArray != null)
        //                {
        //                    if (!bricks.Contains(brickArray[col, row]))
        //                    {
        //                        var b = brickArray[col, row];
        //                        if (b == null)
        //                        {
        //                            bricks[row + board.Width + col - 1].Color = Colors.Transparent;
        //                        }
        //                        else
        //                        {
        //                            bricks[row + board.Width + col - 1].Color = brickArray[col, row].Color;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        public void UpdateScoreView(int score, int hiScore, int lines, int level, Core.Shapes.IShape next)
        {
            this.Score = score;
            this.HiScore = hiScore;
            this.Lines = lines;
            this.Next = next.ToString();
            this.Level = level;
        }

        public IView View
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void InitializeBoard()
        {
            throw new NotImplementedException();
        }

        public void GameOver()
        {
            IsIntroVisible = false;
            IsGameOverVisible = true;
            IsGamePausedVisible = false;
            foreach (var b in bricks)
            {
                b.Color = Colors.Transparent;
            }

            isPlaying =
            PauseCanExecute =
            StopCanExecute =
            IsIntroVisible = false;
            StartCanExecute = true;
            presenter.InitializeBoard();
        }

        public void Tick()
        {
            throw new NotImplementedException();
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                OnPropertyChanged("Score");
            }
        }

        public int HiScore
        {
            get
            {
                return hiScore;
            }
            set
            {
                hiScore = value;
                OnPropertyChanged("HiScore");
            }
        }

        public int Lines
        {
            get
            {
                return lines;
            }
            set
            {
                lines = value;
                OnPropertyChanged("Lines");
            }
        }

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                OnPropertyChanged("Level");
            }
        }

        public string Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
                OnPropertyChanged("Next");
            }
        }

        public string P1Data
        {
            get
            {
                return p1Data;
            }
            set
            {
                p1Data = value;
                OnPropertyChanged("P1Data");
            }
        }

        public string P2Data
        {
            get
            {
                return p2Data;
            }
            set
            {
                p2Data = value;
                OnPropertyChanged("P2Data");
            }
        }

        public string P3Data
        {
            get
            {
                return p3Data;
            }
            set
            {
                p3Data = value;
                OnPropertyChanged("P3Data");
            }
        }

        public string P4Data
        {
            get
            {
                return p4Data;
            }
            set
            {
                p4Data = value;
                OnPropertyChanged("P4Data");
            }
        }

        public int StrokeThickness
        {
            get
            {
                return strokeThickness;
            }
            set
            {
                strokeThickness = value;
                OnPropertyChanged("StrokeThickness");
            }
        }

        public DispatcherTimer Timer
        {
            get
            {
                return timer;
            }
            set
            {
                timer = value;
                OnPropertyChanged("Timer");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public void DisplayBoard(string arrayString, IBrick[,] brickArray, int width, int height)
        {
            //DrawBorder(bufferedGraphics);

            if (lastArrayString == "")
            {
                lastArrayString = arrayString;
            }

            if (arrayString == "")
            {
                arrayString = Replicate("0", presenter.Width * presenter.Height);
            }

            StringBuilder sb = new StringBuilder();

            char zero = "0".ToCharArray()[0];

            //SolidBrush brush = new SolidBrush(Color.Black);

            int i = 0;
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (arrayString[i] != lastArrayString[i])
                    {
                        IBrick brick = brickArray[column, row];

                        Color color = Colors.Transparent;

                        DrawBrick(column, row, color);
                        if (brick == null)
                        {
                            color = Colors.Transparent;
                            //bufferedGraphics.FillRectangle(brush, boardCorner.X + column * 16, boardCorner.Y + row * 16, 16, 16);
                        }
                        else
                        {
                            color = brick.Color;
                            DrawBrick(column, row, color);
                        }

                    }
                    i++;
                }
            }

            lastArrayString = arrayString;
            //BricksGraphics.DrawImage(bufferedBitmap, 0, 0);
        }

        public void DisplayScore(int score, int hiScore, int lines, int level, IShape next)
        {
            Score = score;
            HiScore = hiScore;
            Lines = lines;


            if (level > this.level)
            {
                timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / (1 + (level / 2)) );
            }
            Level = level;

            string arrayString = next.ShapeString;
            int height = next.Height;
            int width = next.Width;
            StringBuilder sb = new StringBuilder();
            int i = 0;
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    string s = arrayString[i].ToString();
                    sb.Append(s);
                    i++;
                }
                sb.Append(" ");
            }

            DisplayNext(next);
        }

        private void DisplayNext(IShape next)
        {
            int height = next.Height;
            int width = next.Width;

            for (int row = 0; row < 2; row++)
            {
                for (int column = 0; column < 4 ; column++)
                {
                    IBrick brick = null;
                    Color color = Colors.Transparent;

                    if ((row < height) && (column < width))
                    {
                        brick = next.ShapeArray[column, row];
                    }
                    
                    if (brick == null)
                    {
                        color = Colors.Transparent;
                    }
                    else
                    {
                        color = brick.Color;
                    }
                    DrawNextShapeBrick(column, row, color);
                }
            }
        }

        private void DrawBrick(int x, int y, Color color)
        {
            if (bricks.Count > 0)
            {
                bricks[y * presenter.Width + x].Color = color;
            }
        }

        private void DrawNextShapeBrick(int x, int y, Color color)
        {
            if (nextShapeBricks.Count > 0)
            {
                nextShapeBricks[y * 4 + x].Color = color;
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

        public bool MoveLeft()
        {
            return presenter.MoveLeft();
        }

        public bool MoveRight()
        {
            return presenter.MoveRight();
        }

        public bool MoveDown()
        {
            return presenter.MoveDown();
        }

        public bool Rotate90()
        {
            return presenter.Rotate90();
        }

        public bool Rotate270()
        {
            return presenter.Rotate270();
        }

        public bool IsIntroVisible
        {
            get
            {
                return isIntroVisible;
            }
            set
            {
                isIntroVisible = value;
                OnPropertyChanged("IsIntroVisible");
            }
        }
        public bool IsGameOverVisible
        {
            get
            {
                return isGameOverVisible;
            }
            set
            {
                isGameOverVisible = value;
                if (isGameOverVisible)
                {
                    timer.Stop();
                }
                OnPropertyChanged("IsGameOverVisible");
            }
        }

        public bool IsGamePausedVisible
        {
            get
            {
                return isGamePausedVisible;
            }
            set
            {
                isGamePausedVisible = value;
                if (isGamePausedVisible)
                {
                    timer.Stop();
                }
                OnPropertyChanged("IsGamePausedVisible");
            }
        }

        public string PauseText
        {
            get
            {
                return pauseText;
            }
            set
            {
                pauseText = value;
                OnPropertyChanged("PauseText");
            }
        }

        public ICommand StartCommand
        {
            get { return new RelayCommand(p => DoStart()); }
        }

        public bool StartCanExecute
        {
            get
            {
                return startCanExecute;
            }
            set
            {
                startCanExecute = value;
                OnPropertyChanged("StartCanExecute");
            }
        }

        public ICommand PauseCommand
        {
            get { return new RelayCommand(p => DoPause()); }
        }

        public bool PauseCanExecute
        {
            get
            {
                return pauseCanExecute;
            }
            set
            {
                pauseCanExecute = value;
                OnPropertyChanged("PauseCanExecute");
            }
        }

        public ICommand StopCommand
        {
            get { return new RelayCommand(p => DoStop()); }
        }

        public bool StopCanExecute
        {
            get
            {
                return stopCanExecute;
            }
            set
            {
                stopCanExecute = value;
                OnPropertyChanged("StopCanExecute");
            }
        }

        public void DoStart()
        {
            isPlaying =
            PauseCanExecute = 
            StopCanExecute = true;
            IsIntroVisible =
            StartCanExecute = false;
            IsGameOverVisible = false;
            timer.Start();
        }

        public void DoPause()
        {
            if (!isGamePausedVisible)
            {
                PauseText = "Continue";
            }
            else
            {
                PauseText = "Pause";
            }

            if (timer.IsEnabled)
                timer.Stop();
            else
                timer.Start();

            IsGamePausedVisible = !IsGamePausedVisible;
        }

        public void DoStop()
        {
            timer.Stop();
            presenter.InitializeBoard();
            IsIntroVisible = true;
            StartCanExecute = true;
            PauseCanExecute = false;
            StopCanExecute = false;
            IsGamePausedVisible = false;
        }

    }

    //public class GetStartCommand : ICommand
    //{
    //    private BricksBoard _model;

    //    public GetRssFeedCommand(BricksBoard)
    //    {
    //        _feed = feed;
    //        _model = model;
    //    }

    //    public event EventHandler CanExecuteChanged;

    //    public bool CanExecute(object parameter)
    //    {
    //        return true;
    //    }

    //    public void Execute(object parameter)
    //    {
    //        _model.RssLoadComplete += new EventHandler<RssEventArgs>(OnRssLoadComplete);
    //        _model.GetRssFeedAsync(new Uri((string)parameter, UriKind.Absolute));
    //    }

    //    void OnRssLoadComplete(object sender, RssEventArgs e)
    //    {
    //        if (_feed != null) // Just to be sure
    //        {
    //            _feed.Clear();

    //            using (XmlReader reader = XmlReader.Create(e.Result))
    //            {
    //                SyndicationFeed feed = SyndicationFeed.Load(reader);

    //                foreach (SyndicationItem item in feed.Items)
    //                    _feed.Add(item);
    //            }
    //        }
    //    }
    //}

}
