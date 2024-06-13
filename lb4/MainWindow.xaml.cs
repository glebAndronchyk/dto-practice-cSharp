using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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

        private void SerializeAll(object? sender, CancelEventArgs cancelEventArgs)
        {
            var stateInstance = StateSingleton.Instance;
            
            JSON.StringifyToFile("students.json", stateInstance.DtoMapper
                .Map<List<Student>, List<StudentDTO>>(stateInstance.Students.ToList()));
            
            JSON.StringifyToFile("publications.json", stateInstance.DtoMapper
                .Map<List<Publication>, List<PublicationDTO>>(stateInstance.Publications.ToList()));
        }
    }
}