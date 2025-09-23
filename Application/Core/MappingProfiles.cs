using AutoMapper;
using Domain.Entities;
using Application.Entities.Companies.DTOs;
using Application.Entities.Customers.DTOs;


namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Company entity
        CreateMap<Company, CompanyDto>();
        CreateMap<Company, EditCompanyDto>();
        CreateMap<CreateCompanyDto, Company>();
        CreateMap<EditCompanyDto, Company>();

        // Customer entity
        CreateMap<Customer, CustomerDto>();
        CreateMap<Customer, EditCustomerDto>();
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<EditCustomerDto, Customer>();
    }
}
