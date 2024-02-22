using Guild.Application.Players.DTOs.Responses;
using MediatR;

namespace Guild.Application.Players.Queries.GetPlayer;

public class GetPlayerQuery : IRequest<GetPlayerResponseDTO>
{
    public Guid Id { get; }

    public GetPlayerQuery(Guid id)
    {
        Id = id;
    }
}