using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.DragDrop;

namespace ListBoxWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }

        private void RadListBox_Loaded(object sender, RoutedEventArgs e)
        {
            var listBox = sender as RadListBox;
            var listBoxItems = (listBox.DataContext as ViewModel).ItemsSource;
            this.ListBox.SelectionHelper.AddToSelection(listBoxItems.Where(i => i.IsChecked));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
