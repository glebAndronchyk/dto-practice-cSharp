using System;
using System.Collections.ObjectModel;
using System.Windows;
using lb4.abstractions;

namespace lb4;

public partial class Student_AddForm : Window
{
    private AddFormController<Student, StudentDTO> _wc;
    
    public Student_AddForm(ref ObservableCollection<Student> students)
    {
        InitializeComponent();
        _wc = new AddFormController<Student, StudentDTO>(ref students);
    }

    public void OnSave(object sender, RoutedEventArgs args) => _wc.OnSave(new Student(
        firstName.Text,
        lastName.Text,
        appliedDate.SelectedDate ?? DateTime.Now),
        "students.json");

    public void OnExit()
    {
        
    }
}