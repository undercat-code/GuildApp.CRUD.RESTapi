using Guild.Application.Players.DTOs.Request;
using MediatR;

namespace Guild.Application.Players.Commands.DeletePlayer;

public class DeletePLayerCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeletePLayerCommand(Guid id)
    {
        Id = id;
    }
}