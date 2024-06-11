using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace lb4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StateSingleton.Instance.LoadData();
        }

        public void OnOpenStudentsForm(object sender, RoutedEventArgs e) => new Student_MainWindow().ShowDialog();
        public void OnOpenPublicationsForm(object sender, RoutedEventArgs e) => new Publication_MainWindow().ShowDialog();
    }
}