using System.Reflection.Metadata;
using AutoMapper;
using Guild.Application.Common.Exceptions;
using Guild.Application.Interfaces;
using Guild.Application.Players.DTOs.Responses;
using Guild.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Guild.Application.Players.Queries.GetPlayer;

public class GetPlayerHandler : IRequestHandler<GetPlayerQuery, GetPlayerResponseDTO>
{
    private readonly IPlayersDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetPlayerHandler(IPlayersDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetPlayerResponseDTO> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
    {
        var player = await _dbContext.Players.FirstOrDefaultAsync(player => player.Id  == request.Id, cancellationToken);
        if (player == null || player.Id != request.Id)
        {
            throw new NotFoundException(nameof(Player), request.Id);
        }

        return _mapper.Map<GetPlayerResponseDTO>(player);
    }
}