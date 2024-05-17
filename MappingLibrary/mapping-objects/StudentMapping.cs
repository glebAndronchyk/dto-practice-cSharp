using AutoMapper;
using StudentsLibrary;

namespace MappinServiceLibrary;

public class StudentMapping : Profile
{
    public StudentMapping()
    {
        CreateMap<Student, StudentDTO>()
            .ForMember(
                dest => dest.fullName,
                opt => opt.MapFrom(source => $"{source.Name} {source.Surname}")
            );
    }
}