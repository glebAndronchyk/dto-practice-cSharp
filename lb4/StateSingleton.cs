using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        var students = DtoMapper.Map<List<StudentDTO>, List<Student>>(JSON.ParseFromFile<List<StudentDTO>>("students.json"));
        var researches = DtoMapper.Map<List<ResearchDTO>, List<Research>>(JSON.ParseFromFile<List<ResearchDTO>>("researches.json"));
        var customers = DtoMapper.Map<List<CustomerDTO>, List<Customer>>(JSON.ParseFromFile<List<CustomerDTO>>("customers.json"));
        var publications = DtoMapper.Map<List<PublicationDTO>, List<Publication>>(JSON.ParseFromFile<List<PublicationDTO>>("publications.json"));

        Publications = new ObservableCollection<Publication>(publications);
        Customers = new ObservableCollection<Customer>(customers);
        Researches = new ObservableCollection<Research>(researches);
        Students = new ObservableCollection<Student>(students);
    }
}
