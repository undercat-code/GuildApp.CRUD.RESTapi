using AutoMapper;
using MediatR;
using Guild.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Guild.Domain;
using Guild.Application.Common.Exceptions;


namespace Guild.Application.Players.Commands.UpdatePlayer;

public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, bool>
{
    private readonly IPlayersDbContext _dbContext;
    private readonly IMapper _mapper;

    public UpdatePlayerCommandHandler(IPlayersDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
    {
        var mapEntities = _mapper.Map<Player>(request.Player);
        
        var player = await _dbContext.Players.FirstOrDefaultAsync(player => player.Id == request.Player.Id, cancellationToken);
        if (player == null)
        {
            throw new NotFoundException(nameof(Player), request.Player.Id);
        }

        player.NickName = request.Player.Name;
        player.RealName = request.Player.RealName;
        player.GuildRole = request.Player.GuildRole;
        player.CurrentInvestments = request.Player.CurrentInvestments;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}