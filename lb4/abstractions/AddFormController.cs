using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace lb4.abstractions;

public class AddFormController<T, TDTO>
{
    private bool _confirmClose = true;
    private Window _windowCtx;
    private string _stateKey;

    public delegate void OnSaveHandlerType(object sender, RoutedEventArgs e);
    
    public AddFormController(string stateKey, Window ctx)
    {
        _stateKey = stateKey;
        _windowCtx = ctx;
    }

    public void OnSave(T obj, string path)
    {
        var stateInstance = StateSingleton.Instance;
        var observableField = typeof(StateSingleton).GetField(_stateKey);

        if (observableField != null)
        {
            var observableList = observableField.GetValue(stateInstance) as ObservableCollection<T>;
            
            observableList.Add(obj);
            var dtoList = StateSingleton.Instance.DtoMapper.Map<List<T>, List<TDTO>>(observableList.ToList());
            JSON.StringifyToFile(path, dtoList);
        }
    }

    public void OnSaveAndExit(OnSaveHandlerType OnSaveHandler, object sender, RoutedEventArgs args)
    {
        _confirmClose = false;
        OnSaveHandler(sender, args);
        OnClose();
    }

    public void OnClose()
    {
        _windowCtx.Close();
    }

    public void ClosingSequence(object sender, CancelEventArgs e)
    {
        if (!_confirmClose) return;
        MessageBoxResult result = MessageBox.Show(
            "You have unsaved changes, do you wanna quit without saving?", 
            "Warning!", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Warning);
        
        if (result == MessageBoxResult.No)
        {
            e.Cancel = true;
        }
    }
}