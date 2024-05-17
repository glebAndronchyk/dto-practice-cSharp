using AutoMapper;
using MappinServiceLibrary;

namespace MappingLibrary;

public class MappingInitializer
{
    public static IMapper GetMapper()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<StudentMapping>();
            cfg.AddProfile<PublicationMapping>();
            cfg.AddProfile<ResearchMapping>();
            cfg.AddProfile<CustomerMapping>();
        }).CreateMapper();
    }
}