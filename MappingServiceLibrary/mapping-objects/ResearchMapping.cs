using AutoMapper;
using ResearchLibrary;

namespace MappinServiceLibrary;

public class ResearchMapping : Profile
{
    public ResearchMapping()
    {
        CreateMap<Research, ResearchDTO>();
    }
}