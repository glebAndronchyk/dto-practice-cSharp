using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using lb4.abstractions;
using lb4.ViewModels;

namespace lb4;

public partial class Publication_AddForm : Window, IInteractiveWindow<Publication, PublicationDTO>
{
    private InteractiveWindowController<Publication, PublicationDTO> _wc;
    
    public Publication_AddForm()
    {
        InitializeComponent();
        students_combobox.ItemsSource = StateSingleton.Instance.Students;
        _wc = new ("Publications", "publications.json", this);
    }

    public void OnSaveAndExit(object sender, RoutedEventArgs args)
    {
        _wc.OnSaveAndExit(() => OnSave(sender, args), (PublicationViewModel)DataContext);
    }

    public void OnSave(object sender, RoutedEventArgs args)
    {
        _wc.OnSave(new (
            (students_combobox.SelectedItem as Student)!, 
            Enum.Parse<EScientificAchievement>(achievements_combobox.SelectedItem.ToString()!),
            Guid.NewGuid().ToString()
        ));
    }

    public void ClosingSequence(object sender, CancelEventArgs e) => _wc.ClosingSequence(sender, e);

    public void OnClose(object sender, RoutedEventArgs args) => _wc.OnClose();
}