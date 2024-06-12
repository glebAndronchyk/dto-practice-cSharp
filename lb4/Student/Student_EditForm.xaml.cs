using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using lb4.abstractions;
using lb4.ViewModels;

namespace lb4;

public interface IEditWindow
{
    public bool? ShowDialog();
    public void SetCurrentData(string updateId);
}

public partial class Student_EditForm : Window, IEditWindow, IInteractiveWindow<Student, StudentDTO>
{
    private InteractiveWindowController<Student, StudentDTO> _wc;
    private string _updateId;
    
    public Student_EditForm()
    {
        InitializeComponent();
        _wc = new ("Students", "students.json", this);
    }

    public void SetCurrentData(string updateId)
    {
        _updateId = updateId;

        var currentObj = StateSingleton.Instance.Students.FirstOrDefault(s => s.Id == updateId);
        
        firstName.Text = currentObj.Name;
        lastName.Text = currentObj.Surname;
        appliedDate.SelectedDate = currentObj.AppliedDate;
    }
    
    public void OnSaveAndExit(object sender, RoutedEventArgs args) => _wc.OnSaveAndExit(() => OnSave(sender, args), (StudentViewModel)DataContext);

    public void OnSave(object sender, RoutedEventArgs args) => _wc.OnUpdate(_updateId, new ()
    {
        fullName = firstName.Text + " " + lastName.Text,
        appliedDate = appliedDate.SelectedDate.ToString(),
        id = Guid.Parse(_updateId)
    });

    public void ClosingSequence(object sender, CancelEventArgs e) => _wc.ClosingSequence(sender, e);

    public void OnClose(object sender, RoutedEventArgs args) => _wc.OnClose();
}