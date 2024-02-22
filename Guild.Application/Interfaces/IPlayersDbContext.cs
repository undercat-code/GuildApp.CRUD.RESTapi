using Guild.Domain;
using Microsoft.EntityFrameworkCore;
namespace Guild.Application.Interfaces;

public interface IPlayersDbContext
{
    DbSet<Player> Players { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}