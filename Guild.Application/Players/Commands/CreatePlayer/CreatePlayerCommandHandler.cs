using AutoMapper;
using MediatR;
using Guild.Application.Interfaces;
using Guild.Application.Players.DTOs.Responses;
using Guild.Domain;
namespace Guild.Application.Players.Commands.CreatePlayer;

public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, GetPlayerResponseDTO>
{
    private readonly IPlayersDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreatePlayerCommandHandler(IPlayersDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<GetPlayerResponseDTO> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = _mapper.Map<Player>(request.PlayerRequest);
        player.CurrentInvestments = player.JoinGuildInvestments;
        await _dbContext.Players.AddAsync(player);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<GetPlayerResponseDTO>(player);
                        
                    
                     
    }
}