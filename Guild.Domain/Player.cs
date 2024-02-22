namespace Guild.Domain;

public class Player
{
    public Guid Id { get; set; }
    public string NickName { get; set; }
    public string? RealName { get; set; } = string.Empty;
    public string? GuildRole { get; set; } = "Member";
    public DateTime JoinGuildDate { get; set; } = DateTime.UtcNow;
    public long JoinGuildInvestments { get; set; }
    public long CurrentInvestments { get; set; }
    public int ActiveStatus { get; set; } = 1;
}