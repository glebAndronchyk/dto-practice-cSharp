using System.ComponentModel;
using System.Windows;

namespace lb4.abstractions;

public interface IListWindow
{
    public void OnEdit(object sender, RoutedEventArgs routedEventArgs);
    public void OnAddNew(object sender, RoutedEventArgs routedEventArgs);
    public void OnRemove(object sender, RoutedEventArgs routedEventArgs);
}