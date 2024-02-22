using AutoMapper;
using Guild.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Guild.Application.Players.Queries;
using Guild.Application.Players.Commands;
using Guild.Application.Players.Commands.CreatePlayer;
using Guild.Application.Players.Commands.DeletePlayer;
using Guild.Application.Players.Commands.UpdatePlayer;
using Guild.Application.Players.DTOs.Request;
using Guild.Application.Players.Queries.GetAllPlayers;
using Guild.Application.Players.Queries.GetPlayer;


namespace Guild.API.Controllers;

public class PlayersController : BaseController
{
    private readonly IMediator _mediator;
    public PlayersController(IPlayersDbContext dbContext, IMapper mapper, IMediator mediator) : base(dbContext, mapper)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPlayers()
    {
        var query = new GetAllPlayersQuery();

        var result = await _mediator.Send(query);

        
        return Ok(result);
    }

    [HttpGet]
    [Route("{id:Guid}")]

    public async Task<IActionResult> GetPlayer(Guid id)
    {
        var query = new GetPlayerQuery(id);
        var result = await _mediator.Send(query);

        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddPlayer([FromBody] CreatePlayerRequestDTO player)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var command = new CreatePlayerCommand(player);
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetPlayer), new { id = result.Id }, result);
    }
    
    [HttpPut("")]
    public async Task<IActionResult> UpdatePlayer([FromBody] UpdatePlayerRequestDTO player)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        var command = new UpdatePlayerCommand(player);
        var result = await _mediator.Send(command);

        return result ? NoContent() : BadRequest();
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeletePlayer(Guid id)
    {
        var command = new DeletePLayerCommand(id);
        var result = await _mediator.Send(command);
        return result ? NoContent() : BadRequest();
    }
    
}