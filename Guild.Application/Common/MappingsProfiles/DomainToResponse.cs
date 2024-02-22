using AutoMapper;
using Guild.Application.Players.DTOs.Responses;
using Guild.Domain;

namespace Guild.Application.Common.MappingsProfiles;

public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        CreateMap<Player, GetPlayerResponseDTO>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.NickName))
            .ForMember(dest => dest.JoinDate,
                opt => opt.MapFrom(src => DateTime.UtcNow.ToShortDateString()))
            .ForMember(dest => dest.Investments,
                opt => opt.MapFrom(src => src.CurrentInvestments));

    }
}