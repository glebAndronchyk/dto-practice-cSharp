using System;
using System.Windows;
using lb4.abstractions;

namespace lb4;

public partial class Student_AddForm : Window
{
    private AddFormController<Student, StudentDTO> _wc;
    
    public Student_AddForm()
    {
        InitializeComponent();
        _wc = new AddFormController<Student, StudentDTO>("Students");
    }

    public void OnSaveAndExit(object sender, RoutedEventArgs args)
    {
        OnSave(sender, args);
    }

    public void OnSave(object sender, RoutedEventArgs args) => _wc.OnSave(new Student(
        firstName.Text,
        lastName.Text,
        appliedDate.SelectedDate ?? DateTime.Now),
        "students.json");

    public void OnExit()
    {
        Close();
    }
}