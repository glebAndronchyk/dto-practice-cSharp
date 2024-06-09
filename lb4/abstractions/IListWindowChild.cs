using System;
using System.Windows;

namespace lb4.abstractions;

public interface IListWindowChild : IListWindowBase
{
    public void OnEdit(object sender, RoutedEventArgs routedEventArgs, string id);
    public void OnRemove(Action callback);
}