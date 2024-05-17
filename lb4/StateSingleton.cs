using AutoMapper;

namespace lb4;

public class StateSingleton
{
    private static StateSingleton? _instance;

    public IMapper DtoMapper = MappingInitializer.GetMapper();

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
}