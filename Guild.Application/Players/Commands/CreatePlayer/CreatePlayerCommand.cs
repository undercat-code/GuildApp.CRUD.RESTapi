using Guild.Application.Players.DTOs.Request;
using Guild.Application.Players.DTOs.Responses;
using MediatR;
using Guild.Domain;
namespace Guild.Application.Players.Commands.CreatePlayer;

public class CreatePlayerCommand : IRequest<GetPlayerResponseDTO>
{
    public CreatePlayerRequestDTO PlayerRequest { get; }

    public CreatePlayerCommand(CreatePlayerRequestDTO playerRequest)
    {
        PlayerRequest = playerRequest;
    }
}