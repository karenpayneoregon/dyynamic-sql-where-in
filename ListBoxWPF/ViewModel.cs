using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace ListBoxWPF
{
    public class ViewModel: ViewModelBase
    {        
        private string checkedItemsString;
        
        public ViewModel()
        {
            ItemsSource = new ObservableCollection<CheckBoxItem>
            {
                new CheckBoxItem { IsChecked=true, Name="Item 1"},
                new CheckBoxItem { IsChecked=false, Name="Item 2"},
                new CheckBoxItem { IsChecked=true, Name="Item 3"},
                new CheckBoxItem { IsChecked=false, Name="Item 4"},
                new CheckBoxItem { IsChecked=true, Name="Item 5"},
                new CheckBoxItem { IsChecked=false, Name="Item 6"},
            };

            GetCheckedItemsCommand = new DelegateCommand(OnGetCheckedItemsCommandExecute);
        }

        private void OnGetCheckedItemsCommandExecute(object obj)
        {
            var builder = new StringBuilder();
            var checkedItems = ItemsSource.Where(checkItem => checkItem.IsChecked);
            foreach (CheckBoxItem item in checkedItems)
            {
                builder.AppendLine(item.Name);
            }

            CheckedItemsString = builder.ToString();
        }

        public ObservableCollection<CheckBoxItem> ItemsSource { get; set; }
        public ICommand GetCheckedItemsCommand { get; set; }

        public string CheckedItemsString
        {
            get => checkedItemsString;

            set
            {
                if (checkedItemsString != value)
                {
                    checkedItemsString = value;
                    OnPropertyChanged(() => this.CheckedItemsString);
                }
            }
        }
    }
}
