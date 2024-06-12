using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using lb4.abstractions;
using lb4.Enums;
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
        achievements_combobox.ItemsSource = new List<KeyValuePair<EScientificAchievement, string>>(ScientificAchievementMap.DescriptionMap);
        _wc = new ("Publications", "publications.json", this);
    }

    public void SetCurrentData(string updateId)
    {
        _updateId = updateId;

        var publication = StateSingleton.Instance.Publications.FirstOrDefault(p => p.Id == updateId);
        var currentStudentObjIndex = StateSingleton.Instance.Students.ToList().FindIndex(s => publication.Student.Id == s.Id);
        var currentAchievementIndex = ScientificAchievementMap.DescriptionMap.Keys.ToList()
            .FindIndex(k => (int)k == (int)publication.Achievement);
        
        students_combobox.SelectedIndex = currentStudentObjIndex;
        achievements_combobox.SelectedIndex = currentAchievementIndex;
    }
    
    public void OnSaveAndExit(object sender, RoutedEventArgs args) => _wc.OnSaveAndExit(() => OnSave(sender, args), (PublicationViewModel)DataContext);

    public void OnSave(object sender, RoutedEventArgs args) => _wc.OnUpdate(_updateId, new ()
    {
        student = StateSingleton.Instance.DtoMapper.Map<Student, StudentDTO>(students_combobox.SelectedItem as Student),
        achievement = (int)((KeyValuePair<EScientificAchievement, string>)achievements_combobox.SelectedItem).Key,
        id = _updateId
    });

    public void ClosingSequence(object sender, CancelEventArgs e) => _wc.ClosingSequence(sender, e);

    public void OnClose(object sender, RoutedEventArgs args) => _wc.OnClose();
}