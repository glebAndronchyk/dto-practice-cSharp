using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using lb4.abstractions;

namespace lb4;

public partial class Publication_MainWindow : Window, IListWindowParent
{
    protected WindowController<Publication, PublicationDTO> _wc;

    public Publication_MainWindow()
    {
        InitializeComponent();
        WindowController<Publication, PublicationDTO> wc = new(
                () => new Publication_AddForm(),
                () => new Publication_EditForm()
            );
        publications_list.ItemsSource = StateSingleton.Instance.Publications;
        _wc = wc;
    }

    public void OnEdit(object sender, RoutedEventArgs routedEventArgs)
    {
        _wc.OnEdit(sender, routedEventArgs, StateSingleton.Instance.Publications[publications_list.ListBox.SelectedIndex].Id);
    }

    public void OnRemove(object sender, RoutedEventArgs routedEventArgs) => _wc.OnRemove(() => 
        StateSingleton.Instance.Publications.RemoveAt(publications_list.ListBox.SelectedIndex));
    
    public void OnAddNew(object sender, RoutedEventArgs routedEventArgs) => _wc.OnAddNew(sender, routedEventArgs);
}
