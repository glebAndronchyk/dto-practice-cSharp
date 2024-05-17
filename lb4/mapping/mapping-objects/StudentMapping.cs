using AutoMapper;

namespace lb4;
public class StudentMapping : Profile
{
    public StudentMapping()
    {
        CreateMap<Student, StudentDTO>()
            .ForMember(
                dest => dest.fullName,
                opt => opt.MapFrom(source => $"{source.Name} {source.Surname}")
            ).ReverseMap();
    }
}