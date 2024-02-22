using AutoMapper;
using Guild.Application.Players.DTOs.Request;
using Guild.Domain;


namespace Guild.Application.Common.MappingsProfiles;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        CreateMap<CreatePlayerRequestDTO, Player>()
            .ForMember(
                dest => dest.NickName,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.JoinGuildDate,
                opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.JoinGuildInvestments,
                opt => opt.MapFrom(src => src.Investments));

        CreateMap<UpdatePlayerRequestDTO, Player>()
            .ForMember(
                dest => dest.NickName,
                opt => opt.MapFrom(src => src.Name));
    }
}