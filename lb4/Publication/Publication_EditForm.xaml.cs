using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using lb4.abstractions;
using lb4.ViewModels;

namespace lb4;

public partial class Publication_EditForm : Window, IEditWindow, IInteractiveWindow<Publication, PublicationDTO>
{
    private InteractiveWindowController<Publication, PublicationDTO> _wc;
    private string _updateId;
    
    public Publication_EditForm()
    {
        InitializeComponent();
        students_combobox.ItemsSource = StateSingleton.Instance.Students;
        _wc = new ("Publications", "publications.json", this);
    }

    public void SetCurrentData(string updateId)
    {
        _updateId = updateId;
        var currentStudentObj = StateSingleton.Instance.Students.FirstOrDefault(s => s.Id == updateId);

        students_combobox.SelectedItem = currentStudentObj;
    }
    
    public void OnSaveAndExit(object sender, RoutedEventArgs args) => _wc.OnSaveAndExit(() => OnSave(sender, args), (PublicationViewModel)DataContext);

    public void OnSave(object sender, RoutedEventArgs args) => _wc.OnUpdate(_updateId, new ()
    {
        student = students_combobox.SelectedItem as Student,
        achievement = Enum.Parse<EScientificAchievement>(achievements_combobox.SelectedItem.ToString()!),
        id = Guid.Parse(_updateId)
    });

    public void ClosingSequence(object sender, CancelEventArgs e) => _wc.ClosingSequence(sender, e);

    public void OnClose(object sender, RoutedEventArgs args) => _wc.OnClose();
}