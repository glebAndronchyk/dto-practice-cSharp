using System;
using System.Windows;

namespace lb4.abstractions;

public class WindowController<T, TDTO> : IListWindowChild
{
    private Func<Window> _addWindowFabric;
    private Func<IEditWindow> _editWindowFabric;
    
    public WindowController(Func<Window> addWindowFabric, Func<IEditWindow> editWindowFabric)
    {
        _addWindowFabric = addWindowFabric;
        _editWindowFabric = editWindowFabric;
    }

    public void OnEdit(object sender, RoutedEventArgs routedEventArgs, string id)
    {
        var window = _editWindowFabric();
        
        window.SetCurrentData(id);
        window.ShowDialog();
    }

    public void OnRemove(Action callback)
    {
        var result = MessageBox.Show(
            "Do you really want to delete this element?",
            "Warning!",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning);

        if (result == MessageBoxResult.Yes)
        {
            callback();
        }
    }

    public void OnAddNew(object sender, RoutedEventArgs routedEventArgs) => _addWindowFabric().ShowDialog();
}