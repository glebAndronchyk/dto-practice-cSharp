using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace lb4.abstractions;

public class AddFormController<T, TDTO>
{
    private string _stateKey;
    
    public AddFormController(string stateKey)
    {
        _stateKey = stateKey;
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
}