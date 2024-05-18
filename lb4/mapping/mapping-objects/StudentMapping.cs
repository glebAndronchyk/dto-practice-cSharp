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
            );

        CreateMap<StudentDTO, Student>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(source => GetNamePart(source.fullName, 0))
            )
            .ForMember(
                dest => dest.Surname,
                opt => opt.MapFrom(source => GetNamePart(source.fullName, 1))
            );
    }

    private static string GetNamePart(string fullname, int index)
    {
        return fullname.Split(" ", 2)[index];
    }
}