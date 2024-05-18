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
            LoadData();
        }

        public void OnOpenStudentsForm(object sender, RoutedEventArgs e) => new Student_MainWindow().ShowDialog();

        private void LoadData()
        {
            var mapper = StateSingleton.Instance.DtoMapper;

            var students = mapper.Map<List<StudentDTO>, List<Student>>(JSON.ParseFromFile<List<StudentDTO>>("students.json"));
            var researches = mapper.Map<List<ResearchDTO>, List<Research>>(JSON.ParseFromFile<List<ResearchDTO>>("researches.json"));
            var customers = mapper.Map<List<CustomerDTO>, List<Customer>>(JSON.ParseFromFile<List<CustomerDTO>>("customers.json"));
            var publications = mapper.Map<List<PublicationDTO>, List<Publication>>(JSON.ParseFromFile<List<PublicationDTO>>("publications.json"));

            StateSingleton.Instance.Publications = new ObservableCollection<Publication>(publications);
            StateSingleton.Instance.Customers = new ObservableCollection<Customer>(customers);
            StateSingleton.Instance.Researches = new ObservableCollection<Research>(researches);
            StateSingleton.Instance.Students = new ObservableCollection<Student>(students);
        }
    }
}