using System.ComponentModel;

namespace SimpleExamplesWpf.Classes
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Items = new CheckableObservableCollection<Country>();
            Items.AddRange(DataOperations.GetCountries());
        }

        private CheckableObservableCollection<Country> _items;

        public CheckableObservableCollection<Country> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
