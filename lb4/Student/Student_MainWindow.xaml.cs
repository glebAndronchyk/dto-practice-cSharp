﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using lb4.abstractions;

namespace lb4;

public partial class Student_MainWindow : Window, IListWindowParent
{
    protected WindowController<Student, StudentDTO> _wc;

    public Student_MainWindow()
    {
        InitializeComponent();
        WindowController<Student, StudentDTO> wc = new(
                () => new Student_AddForm(),
                () => new Student_EditForm()
            );
        listbox.ItemsSource = StateSingleton.Instance.Students;
        _wc = wc;
    }

    public void OnEdit(object sender, RoutedEventArgs routedEventArgs)
    {
        _wc.OnEdit(sender, routedEventArgs, StateSingleton.Instance.Students[listbox.SelectedIndex].Id);
    }

    public void OnRemove(object sender, RoutedEventArgs routedEventArgs) => _wc.OnRemove(() => 
        StateSingleton.Instance.Students.RemoveAt(listbox.SelectedIndex));
    
    public void OnAddNew(object sender, RoutedEventArgs routedEventArgs) => _wc.OnAddNew(sender, routedEventArgs);
}
