using Guild.Application.Players.DTOs.Responses;
using Guild.Application.Players.Queries.GetPlayer;
using MediatR;

namespace Guild.Application.Players.Queries.GetAllPlayers;

public class GetAllPlayersQuery : IRequest<IEnumerable<GetPlayerResponseDTO>>
{
}