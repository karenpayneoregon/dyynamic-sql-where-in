using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimpleExamplesWpf.Classes
{
    public class CheckWrapper<T> : INotifyPropertyChanged
    {
        private readonly CheckableObservableCollection<T> _parent;

        public CheckWrapper(CheckableObservableCollection<T> parent)
        {
            _parent = parent;
        }

        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        private bool _isChecked;

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                _isChecked = value;
                CheckChanged();
                OnPropertyChanged();
            }
        }

        private void CheckChanged()
        {
            _parent.Refresh();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}