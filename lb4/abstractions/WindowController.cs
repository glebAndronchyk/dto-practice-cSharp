using System;
using System.Windows;

namespace lb4.abstractions;

public class WindowController<T, TDTO> : IListWindow
{
    private Func<Window> _addWindowFabric;
    private Func<Window> _editWindowFabric;
    
    public WindowController(Func<Window> addWindowFabric, Func<Window> editWindowFabric)
    {
        _addWindowFabric = addWindowFabric;
        _editWindowFabric = editWindowFabric;
    }

    public void OnEdit(object sender, RoutedEventArgs routedEventArgs) => _editWindowFabric().ShowDialog();
    
    public void OnRemove(object sender, RoutedEventArgs routedEventArgs)
    {
        throw new System.NotImplementedException();
    }

    public void OnAddNew(object sender, RoutedEventArgs routedEventArgs) => _addWindowFabric().ShowDialog();
}