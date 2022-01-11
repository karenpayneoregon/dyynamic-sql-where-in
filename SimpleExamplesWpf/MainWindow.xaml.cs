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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SimpleExamplesWpf.Classes;
using WindowsFormsLibrary.Classes;

namespace SimpleExamplesWpf
{

    public partial class MainWindow : Window
    {
        private IntPtr _intPtr;

        private bool _shown;
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ViewModel();
            DataOperations.GetCommandText += ReceiveQuery;
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            if (_shown)
            {
                return;
            }

            _shown = true;

            Window window = GetWindow(this);
            var windowInterop = new WindowInteropHelper(window ?? throw new InvalidOperationException());
            _intPtr = windowInterop.Handle;
        }

        /// <summary>
        /// Present SELECT WHERE IN from selections in ListBox
        /// </summary>
        /// <param name="sender">Actual SQL statement</param>
        private void ReceiveQuery(string sender)
        {
            ResultsTextBox.Text = QueryParsers.Format(sender);
        }

        /// <summary>
        /// If user has one or more selections create a WHERE IN statement
        /// </summary>
        /// <param name="sender"></param>
        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            
            var identifiers = ((ViewModel)DataContext)
                .Items
                .Where(wrapper => wrapper.IsChecked)
                .Select(wrapper => wrapper.Value.Id)
                .ToList();

            if (identifiers.Count <= 0) return;

            var ( _ , exception) = DataOperations.GetByPrimaryKeys(identifiers);
            if (exception is not null)
            {
                Dialogs.ErrorBox(exception);
            }

        }
    }
}

