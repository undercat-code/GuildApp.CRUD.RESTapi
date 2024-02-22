using AutoMapper;
using AutoMapper.QueryableExtensions;
using Guild.Application.Interfaces;
using Guild.Application.Players.Queries.GetPlayer;
using Guild.Application.Players.DTOs.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Guild.Application.Players.Queries.GetAllPlayers;

public class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, IEnumerable<GetPlayerResponseDTO>>
{
    private readonly IPlayersDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllPlayersQueryHandler(IPlayersDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetPlayerResponseDTO>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
    {
        var playersQuery = await _dbContext.Players.Where(x => x.ActiveStatus == 1)
            .AsNoTracking()
            .OrderBy(x => x.CurrentInvestments)
            .ToListAsync();

        return _mapper.Map<IEnumerable<GetPlayerResponseDTO>>(playersQuery);
    }
}