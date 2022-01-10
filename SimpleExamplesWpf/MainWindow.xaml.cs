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
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            List<Country> checkedCountries = ((ViewModel)DataContext)
                .Items
                .Where(wrapper => wrapper.IsChecked)
                .Select(wrapper => wrapper.Value)
                .ToList();

            if (checkedCountries.Count <= 0) return;

            foreach (var country in checkedCountries)
            {
                Debug.WriteLine($"{country.Id,-3}{country.Name}");
            }

            Debug.WriteLine("");
        }
    }
}

