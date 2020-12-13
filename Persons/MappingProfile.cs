using AutoMapper;
using Persons.Common.Dtos;
using Persons.DataLayer.Entities;

namespace Persons
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();

            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();

            CreateMap<Passport, PassportDto>();
            CreateMap<PassportDto, Passport>();
        }
    }
}
