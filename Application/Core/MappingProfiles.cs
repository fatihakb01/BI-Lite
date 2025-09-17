using AutoMapper;
using Domain.Entities;
using Application.DTOs;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Company, CompanyDto>();
        CreateMap<Company, EditCompanyDto>();

        CreateMap<CreateCompanyDto, Company>();
        CreateMap<EditCompanyDto, Company>();
    }
}
