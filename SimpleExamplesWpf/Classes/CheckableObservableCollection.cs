using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace SimpleExamplesWpf.Classes
{
    public class CheckableObservableCollection<T> : ObservableCollection<CheckWrapper<T>>
    {
        private readonly ListCollectionView _selected;

        public CheckableObservableCollection()
        {
            _selected = new ListCollectionView(this)
            {
                Filter = checkObject => ((CheckWrapper<T>)checkObject).IsChecked
            };
        }

        public void Add(T item)
        {
            Add(new CheckWrapper<T>(this) { Value = item });
        }
        public void AddRange(List<T> list)
        {
            foreach (var item in list)
            {
                Add(new CheckWrapper<T>(this) { Value = item });
            }
        }

        public ICollectionView CheckedItems => _selected;
        internal void Refresh()
        {
            _selected.Refresh();
        }
    }
}