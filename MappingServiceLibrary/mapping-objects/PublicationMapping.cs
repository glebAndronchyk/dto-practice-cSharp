using AutoMapper;
using lb4.entities.Post;

namespace MappinServiceLibrary;

public class PublicationMapping : Profile
{
    public PublicationMapping()
    {
        CreateMap<Publication, PublicationDTO>();
    }
}