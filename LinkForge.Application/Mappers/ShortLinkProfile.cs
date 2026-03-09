using AutoMapper;
using LinkForge.Application.DTO;
using LinkForge.Domain.Entities;

namespace LinkForge.Application.Mappings;

public class ShortLinkProfile : Profile
{
    public ShortLinkProfile()
    {
        CreateMap<ShortLink, ShortLinkDto>();
    }
}