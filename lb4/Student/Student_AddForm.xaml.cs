using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using lb4.abstractions;
using lb4.ViewModels;

namespace lb4;

public partial class Student_AddForm : Window, IInteractiveWindow<Student, StudentDTO>
{
    private InteractiveWindowController<Student, StudentDTO> _wc;
    
    public Student_AddForm()
    {
        InitializeComponent();
        _wc = new ("Students", "students.json", this);
    }

    public void OnSaveAndExit(object sender, RoutedEventArgs args)
    {
        var vm = (StudentViewModel)DataContext;
        vm.SubmitForm(() => _wc.OnSaveAndExit(OnSave, sender, args), _wc.TriggerInvalidWindow);
    }

    public void OnSave(object sender, RoutedEventArgs args) => _wc.OnSave(new (
        firstName.Text,
        lastName.Text,
        appliedDate.SelectedDate ?? DateTime.Now,
        Guid.NewGuid().ToString()
        ));

    public void ClosingSequence(object sender, CancelEventArgs e) => _wc.ClosingSequence(sender, e);

    public void OnClose(object sender, RoutedEventArgs args) => _wc.OnClose();
}