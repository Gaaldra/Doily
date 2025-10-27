using AutoMapper;
using Doily.Domain.Entities;
using Doily.Domain.DTOs.Requests;

namespace Doily.API.Mapping;

public class DomainRequests : Profile
{
    public DomainRequests()
    {
        CreateMap<User, UserResgistrationDto>();
    }
}
