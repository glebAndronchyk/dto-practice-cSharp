using AutoMapper;
using lb4.entities.Customer;

namespace MappinServiceLibrary;

public class CustomerMapping : Profile
{
    public CustomerMapping()
    {
        CreateMap<Customer, CustomerDTO>();
    }
}