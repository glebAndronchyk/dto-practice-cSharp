using System;
using AutoMapper;

namespace lb4;
public class PublicationMapping : Profile
{
    public PublicationMapping()
    {
        CreateMap<Publication, PublicationDTO>();
        CreateMap<PublicationDTO, Publication>()
            .ForMember(dest => dest.Student,
                opt => opt.MapFrom(src => 
                    new Student(StudentMapping.GetNamePart(src.student.fullName,0), StudentMapping.GetNamePart(src.student.fullName,0), DateTime.Parse(src.student.appliedDate), src.student.id)));
    }
}