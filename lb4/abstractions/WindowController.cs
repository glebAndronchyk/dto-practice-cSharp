using System;
using System.Windows;

namespace lb4.abstractions;

public class WindowController<T, TDTO> : WindowControllerBase<T, TDTO>, IListWindowChild
{
    private readonly Func<Window> _addWindowFabric;
    private readonly Func<IEditWindow> _editWindowFabric;
    
    public WindowController(string filePath, string stateKey, Func<Window> addWindowFabric, Func<IEditWindow> editWindowFabric)
    {
        _path = filePath;
        _stateKey = stateKey;
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
            SerializeObservableList();
        }
    }

    public void OnAddNew(object sender, RoutedEventArgs routedEventArgs) => _addWindowFabric().ShowDialog();
}