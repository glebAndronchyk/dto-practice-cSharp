using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace lb4.abstractions;

public class InteractiveWindowController<T, TDTO> 
    where T : ItemWithId
    where TDTO : DTOWithId
{
    private bool _confirmClose = true;
    private string _path;
    private Window _windowCtx;
    private string _stateKey;

    public delegate void OnSaveHandlerType(object sender, RoutedEventArgs e);
    
    public InteractiveWindowController(string stateKey, string path, Window ctx)
    {
        _path = path;
        _stateKey = stateKey;
        _windowCtx = ctx;
    }

    public void OnUpdate(string updateId, TDTO dto)
    {
        var observableList = GetObservableList();
        var replaceIndex = observableList.ToList().FindIndex(e => e.Id == dto.id.ToString());
        observableList[replaceIndex] = StateSingleton.Instance.DtoMapper.Map<TDTO, T>(dto);
    }

    public void OnSave(T obj)
    {
        var observableList = GetObservableList();
        observableList.Add(obj);
    }

    public void OnSaveAndExit(OnSaveHandlerType OnSaveHandler, object sender, RoutedEventArgs args)
    {
        OnSaveHandler(sender, args);
        _confirmClose = false;
        OnClose();
    }

    public void OnClose()
    {
        _windowCtx.Close();
    }

    public void ClosingSequence(object sender, CancelEventArgs e)
    {
        if (_confirmClose)
        {
            WindowHelper.OnWindowClose(e, () => SerializeObservableList());
        }
        else
        {
            SerializeObservableList();
        }
    }

    public void TriggerInvalidWindow()
    {
        WindowHelper.TriggerInvalidWindow();
    }

    private ObservableCollection<T>? GetObservableList()
    {
        var stateInstance = StateSingleton.Instance;
        var observableField = typeof(StateSingleton).GetField(_stateKey);

        return observableField.GetValue(stateInstance) as ObservableCollection<T>;
    }

    private void SerializeObservableList()
    {
        var observableList = GetObservableList();
        var dtoList = StateSingleton.Instance.DtoMapper.Map<List<T>, List<TDTO>>(observableList.ToList());
        
        JSON.StringifyToFile(_path, dtoList);
    }
    
}