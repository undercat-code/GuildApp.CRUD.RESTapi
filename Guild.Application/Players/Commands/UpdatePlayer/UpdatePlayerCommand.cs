using Guild.Application.Players.DTOs.Request;
using MediatR;
namespace Guild.Application.Players.Commands.UpdatePlayer;

public class UpdatePlayerCommand : IRequest<bool>
{
    public UpdatePlayerRequestDTO Player { get; }

    public UpdatePlayerCommand(UpdatePlayerRequestDTO player)
    {
        Player = player;
    }
}