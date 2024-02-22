using Guild.Application.Interfaces;
using Guild.DAL.EntityTypeConfiguration;
using Guild.Domain;
using Microsoft.EntityFrameworkCore;


namespace Guild.DAL;

public class PlayersDbContext : DbContext , IPlayersDbContext
{
    public DbSet<Player> Players { get; set; }

    public PlayersDbContext(DbContextOptions<PlayersDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new PlayerConfiguration());
        base.OnModelCreating(builder);
    }
}