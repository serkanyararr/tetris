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
using System.ComponentModel;
using System.Collections.Specialized;

namespace Tetris.Silverlight
{
    public class ObservableNotifiableCollection<T> :
      ObservableCollection<T> where T : INotifyPropertyChanged
    {

        public ItemPropertyChangedEventHandler ItemPropertyChanged;

        protected override void OnCollectionChanged(
          NotifyCollectionChangedEventArgs args)
        {

            base.OnCollectionChanged(args);

            if (args.NewItems != null)
                foreach (INotifyPropertyChanged item in args.NewItems)
                    item.PropertyChanged += OnItemPropertyChanged;

            if (args.OldItems != null)
                foreach (INotifyPropertyChanged item in args.OldItems)
                    item.PropertyChanged -= OnItemPropertyChanged;
        }

        void OnItemPropertyChanged(object sender,
          PropertyChangedEventArgs args)
        {

            if (ItemPropertyChanged != null)
                ItemPropertyChanged(this,
                  new ItemPropertyChangedEventArgs(sender,
                  args.PropertyName));
        }
    }

    public class ItemPropertyChangedEventArgs : PropertyChangedEventArgs
    {
        object item;

        public ItemPropertyChangedEventArgs(object item,
          string propertyName)
            : base(propertyName)
        {
            this.item = item;
        }

        public object Item
        {
            get { return item; }
        }
    }

    public delegate void ItemPropertyChangedEventHandler(object sender,
      ItemPropertyChangedEventArgs args);
}
