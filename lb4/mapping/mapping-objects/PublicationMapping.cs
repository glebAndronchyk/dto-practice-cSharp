using AutoMapper;

namespace lb4;
public class PublicationMapping : Profile
{
    public PublicationMapping()
    {
        CreateMap<Publication, PublicationDTO>().ReverseMap();
    }
}