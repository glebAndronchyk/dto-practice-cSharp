using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace lb4.abstractions;

public class AddFormController<T, TDTO>
{
    private ObservableCollection<T> _list;
    
    public AddFormController(ref ObservableCollection<T> list)
    {
        _list = list;
    }

    public void OnSave(T obj, string path)
    {
        _list.Add(obj);
        var dtoList = StateSingleton.Instance.DtoMapper.Map<List<T>, List<TDTO>>(_list.ToList());
        JSON.StringifyToFile(path, dtoList);
    }
}