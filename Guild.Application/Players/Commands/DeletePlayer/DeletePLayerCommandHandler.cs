using Guild.Application.Interfaces;
using MediatR;
using Guild.Application.Common.Exceptions;
using Guild.Domain;
using Microsoft.EntityFrameworkCore;

namespace Guild.Application.Players.Commands.DeletePlayer;

public class DeletePLayerCommandHandler : IRequestHandler<DeletePLayerCommand, bool>
{
    private readonly IPlayersDbContext _dbContext;

    public DeletePLayerCommandHandler(IPlayersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(DeletePLayerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Players.FirstOrDefaultAsync(player => player.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException(nameof(Player), request.Id);
        }

        entity.ActiveStatus = 0;
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}