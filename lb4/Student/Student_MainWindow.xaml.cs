using System.ComponentModel;
using System.Windows;
using lb4.abstractions;

namespace lb4;

public partial class Student_MainWindow : Window, IListWindow
{
    protected WindowController<Student, StudentDTO> _wc;

    public Student_MainWindow()
    {
        InitializeComponent();
        WindowController<Student, StudentDTO> wc = new(
                () => new Student_AddForm(),
                () => new Student_AddForm()
            );
        listbox.ItemsSource = StateSingleton.Instance.Students;
        _wc = wc;
    }

    public void OnEdit(object sender, RoutedEventArgs routedEventArgs) => _wc.OnEdit(sender, routedEventArgs);
    
    public void OnRemove(object sender, RoutedEventArgs routedEventArgs) => _wc.OnRemove(sender, routedEventArgs);
    
    public void OnAddNew(object sender, RoutedEventArgs routedEventArgs) => _wc.OnAddNew(sender, routedEventArgs);
}
