using System;
using System.ComponentModel;

namespace lb4.abstractions;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    protected readonly string NameValidationString = "Name should be between 1 and 50 characters.";
    protected readonly string DateValidationString = "Date must be selected.";
    protected readonly int MaxNameLength = 50;
    protected readonly int MinNameLength = 1;
    
    public event PropertyChangedEventHandler PropertyChanged;

    public abstract void SubmitForm(Action successCallback, Action errorCallback);
    public abstract bool IsFormValid();

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}