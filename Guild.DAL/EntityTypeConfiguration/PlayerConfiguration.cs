using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Guild.Domain;

namespace Guild.DAL.EntityTypeConfiguration;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(player => player.Id);
        builder.HasIndex(player => player.Id).IsUnique();
        builder.Property(player => player.NickName).IsUnicode().IsRequired().HasMaxLength(50);
        builder.Property(player => player.RealName).HasMaxLength(50);
        builder.Property(player => player.JoinGuildInvestments).IsRequired();
    }
}