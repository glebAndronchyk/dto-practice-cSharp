using AutoMapper;

namespace lb4;
public class ResearchMapping : Profile
{
    public ResearchMapping()
    {
        CreateMap<Research, ResearchDTO>().ReverseMap();
    }
}