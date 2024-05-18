using System;
using System.ComponentModel;
using System.Windows;
using lb4.abstractions;

namespace lb4;

public partial class Student_AddForm : Window, IInteractiveWindow<Student, StudentDTO>
{
    private AddFormController<Student, StudentDTO> _wc;
    
    public Student_AddForm()
    {
        InitializeComponent();
        _wc = new AddFormController<Student, StudentDTO>("Students", this);
    }

    public void OnSaveAndExit(object sender, RoutedEventArgs args) => _wc.OnSaveAndExit(OnSave, sender, args);

    public void OnSave(object sender, RoutedEventArgs args) => _wc.OnSave(new Student(
        firstName.Text,
        lastName.Text,
        appliedDate.SelectedDate ?? DateTime.Now),
        "students.json");

    public void ClosingSequence(object sender, CancelEventArgs e) => _wc.ClosingSequence(sender, e);

    public void OnClose(object sender, RoutedEventArgs args) => _wc.OnClose();
}