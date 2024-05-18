using System.ComponentModel;
using System.Windows;

namespace lb4.abstractions;

public interface IInteractiveWindow<T, TDTO>
{
    public void OnSaveAndExit(object sender, RoutedEventArgs args);
    public void OnClose(object sender, RoutedEventArgs args);
    public void ClosingSequence(object sender, CancelEventArgs e);
    public void OnSave(object sender, RoutedEventArgs args);
}