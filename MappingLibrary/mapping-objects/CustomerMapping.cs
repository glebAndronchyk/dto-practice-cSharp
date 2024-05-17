using AutoMapper;
using lb4.entities.Customer;

namespace MappingLibrary;

public class CustomerMapping : Profile
{
    public CustomerMapping()
    {
        CreateMap<Customer, CustomerDTO>();
    }
}