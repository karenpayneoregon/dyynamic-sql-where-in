using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SimpleExamplesWpf.Classes;

namespace SimpleExamplesWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
            DataOperations.GetCommandText += ReceiveQuery;
        }

        private void ReceiveQuery(string sender)
        {
            ResultsTextBox.Text = QueryParsers.Format(sender);
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            
            var identifiers = ((ViewModel)DataContext)
                .Items
                .Where(wrapper => wrapper.IsChecked)
                .Select(wrapper => wrapper.Value.Id)
                .ToList();

            if (identifiers.Count <= 0) return;

            var (list, exception) = DataOperations.GetByPrimaryKeys(identifiers);
            // TODO TaskDialog
        }
    }
}

