using System.ComponentModel;
using System.Windows;

namespace lb4.abstractions;

public interface IListWindowParent : IListWindowBase
{
    public void OnEdit(object sender, RoutedEventArgs routedEventArgs);
    public void OnRemove(object sender, RoutedEventArgs routedEventArgs);
}