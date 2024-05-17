using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using lb4.abstractions;

namespace lb4;

public partial class Student_MainWindow : Window, IListWindow
{
    protected ObservableCollection<Student> _students;

    protected WindowController<Student, StudentDTO> _wc =
        new (new Student_AddForm(), new Student_AddForm());

    public Student_MainWindow()
    {
        InitializeComponent();
        _wc.LoadData("students.json", ref _students, ref listbox);
    }

    public void OnEdit(object sender, RoutedEventArgs routedEventArgs) => _wc.OnEdit(sender, routedEventArgs);

    public void OnClose(object sender, CancelEventArgs e) => _wc.OnClose(sender, e);

    public void OnRemove(object sender, RoutedEventArgs routedEventArgs) => _wc.OnRemove(sender, routedEventArgs);
    
    public void OnAddNew(object sender, RoutedEventArgs routedEventArgs) => new Student_AddForm().ShowDialog();
}
