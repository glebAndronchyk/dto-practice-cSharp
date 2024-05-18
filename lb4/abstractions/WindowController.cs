using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace lb4.abstractions;

public class WindowController<T, TDTO> : IListWindow
{
    private Window _addWindow;
    private Window _editWindow;
    
    public WindowController(Window addWindow, Window editWindow)
    {
        _addWindow = addWindow;
        _editWindow = editWindow;
    }
    
    public void OnEdit(object sender, RoutedEventArgs routedEventArgs)
    {
        
    }

    public void OnClose(object sender, CancelEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    public void OnRemove(object sender, RoutedEventArgs routedEventArgs)
    {
        throw new System.NotImplementedException();
    }

    public void OnAddNew(object sender, RoutedEventArgs routedEventArgs) => _addWindow.ShowDialog();
}