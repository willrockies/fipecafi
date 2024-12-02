using AutoMapper;
using Fipecafi.Communication.Requests;
using Fipecafi.Domain.Entities;

namespace Fipecafi.Application.Services.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToDomain();
    }

    private void RequestToDomain()
    {
        CreateMap<RequestRegisterLeadsJson, Lead>()
            .ForMember(dest => dest.CursoId, opt => opt.MapFrom(src => src.CursoId))
            .ForMember(dest => dest.Curso, opt => opt.Ignore());
    }

    private void DomainToResponse()
    {

    }
}
