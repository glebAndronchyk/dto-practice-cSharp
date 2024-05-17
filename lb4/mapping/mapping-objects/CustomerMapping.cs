using AutoMapper;

namespace lb4;
public class CustomerMapping : Profile
{
    public CustomerMapping()
    {
        CreateMap<Customer, CustomerDTO>();
    }
}