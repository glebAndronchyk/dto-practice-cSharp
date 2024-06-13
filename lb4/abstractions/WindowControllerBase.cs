using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace lb4.abstractions;

public class WindowControllerBase<T, TDTO>
{
    protected bool _confirmClose = true;
    protected string _stateKey;
    protected string _path;

    protected Action _closingDelegate = () => { };

    public void ClosingSequence(object sender, CancelEventArgs e)
    {
        if (_confirmClose)
        {
            WindowHelper.OnWindowClose(e, () => _closingDelegate());
        }
        else
        {
            _closingDelegate();
        }
    }

    protected ObservableCollection<T>? GetObservableList()
    {
        var stateInstance = StateSingleton.Instance;
        var observableField = typeof(StateSingleton).GetField(_stateKey);

        return observableField.GetValue(stateInstance) as ObservableCollection<T>;
    }

    protected void SerializeObservableList()
    {
        var observableList = GetObservableList();
        var dtoList = StateSingleton.Instance.DtoMapper.Map<List<T>, List<TDTO>>(observableList.ToList());
        
        JSON.StringifyToFile(_path, dtoList);
    }
}