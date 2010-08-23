//using System;
//using System.Net;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Documents;
//using System.Windows.Ink;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Animation;
//using System.Windows.Shapes;
//using Bricks.Silverlight.ViewModels;

//namespace Bricks.Silverlight.Commands
//{
//    public class StartCommand : ICommand
//    {
//        private BricksViewModel viewModel;

//        public StartCommand(BricksViewModel viewModel)
//        {
//            this.viewModel = viewModel;
//        }

//        public bool CanExecute(object parameter)
//        {
//            return true;
//        }

//        public event EventHandler CanExecuteChanged;

//        public void Execute(object parameter)
//        {
//            viewModel.DoStart();
//        }
//    }
//}
