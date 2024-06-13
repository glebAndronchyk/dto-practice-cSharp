using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace lb4;

public class StateSingleton
{
    private static StateSingleton? _instance;

    public IMapper DtoMapper = MappingInitializer.GetMapper();
    public ObservableCollection<Student> Students;
    public ObservableCollection<Research> Researches;
    public ObservableCollection<Customer> Customers;
    public ObservableCollection<Publication> Publications;
    
    public static StateSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new StateSingleton();
            }

            return _instance;
        }
    }

    public void LoadData()
    {
        var students = DtoMapper.Map<List<StudentDTO>, List<Student>>(JSON.ParseFromFile<StudentDTO>("students.json"));
        var researches = DtoMapper.Map<List<ResearchDTO>, List<Research>>(JSON.ParseFromFile<ResearchDTO>("researches.json"));
        var customers = DtoMapper.Map<List<CustomerDTO>, List<Customer>>(JSON.ParseFromFile<CustomerDTO>("customers.json"));
        var publications = DtoMapper.Map<List<PublicationDTO>, List<Publication>>(JSON.ParseFromFile<PublicationDTO>("publications.json"));

        Publications = new ObservableCollection<Publication>(publications);
        Customers = new ObservableCollection<Customer>(customers);
        Researches = new ObservableCollection<Research>(researches);
        Students = new ObservableCollection<Student>(students);

        Students.CollectionChanged += Students_CollectionChanged;
    }
    
    private void Students_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        Student activeStudent;
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Remove:
                activeStudent = e.OldItems[0] as Student;
                RemoveCascade(Publications, publication => publication.Student.Id == activeStudent!.Id);
                break;
            case NotifyCollectionChangedAction.Replace:
                activeStudent = e.NewItems[0] as Student;
                ReplaceCascade(Publications, "Student", activeStudent,
                    publication => publication.Student.Id == activeStudent!.Id);
                break;
        }
    }

    private static void ReplaceCascade<T, P>(ObservableCollection<T> collection, string fieldPath, P newValue, Func<T, bool> condition)
    {
        PropertyInfo property = typeof(T).GetProperty(fieldPath);
        
        if (property == null)
        {
            throw new ArgumentException($"Field '{fieldPath}' not found on type '{typeof(T).Name}'.");
        }

        var itemsToModify = collection.Where(condition).ToList();

        foreach (var item in itemsToModify)
        {
            property.SetValue(item, newValue);
        }
    }
    
    private void RemoveCascade<T>(ObservableCollection<T> list, Func<T, bool> condition)
    {
        var itemsToRemove = list.Where(item => condition(item)).ToList();

        foreach (var item in itemsToRemove)
        {
            list.Remove(item);
        }
    }
}
