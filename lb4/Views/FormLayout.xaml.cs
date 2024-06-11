using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace lb4.Views;

public partial class FormLayout : UserControl
{
   
    public static readonly DependencyProperty OnCloseProperty =
        DependencyProperty.Register("OnClose", typeof(RoutedEventHandler), typeof(ListView));

    public RoutedEventHandler OnClose
    {
        get { return (RoutedEventHandler)GetValue(OnCloseProperty); }
        set { SetValue(OnCloseProperty, value); }
    }
    
    public static readonly DependencyProperty OnSaveAndExitProperty =
        DependencyProperty.Register("OnSaveAndExit", typeof(RoutedEventHandler), typeof(ListView));

    public RoutedEventHandler OnSaveAndExit
    {
        get { return (RoutedEventHandler)GetValue(OnSaveAndExitProperty); }
        set { SetValue(OnSaveAndExitProperty, value); }
    }
    
    public FormLayout()
    {
        InitializeComponent();
    }
    
    private void OnCloseClick(object sender, RoutedEventArgs e)
    {
        OnClose?.Invoke(this, e);
    }
    
    private void OnSaveAndExitClick(object sender, RoutedEventArgs e)
    {
        OnSaveAndExit?.Invoke(this, e);
    }
}