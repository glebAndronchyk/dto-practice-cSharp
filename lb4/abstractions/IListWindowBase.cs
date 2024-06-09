using System.Windows;

namespace lb4.abstractions;

public interface IListWindowBase
{
    public void OnAddNew(object sender, RoutedEventArgs routedEventArgs);
}