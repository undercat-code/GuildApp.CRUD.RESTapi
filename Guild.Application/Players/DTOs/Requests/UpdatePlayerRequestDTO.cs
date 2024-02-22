namespace Guild.Application.Players.DTOs.Request;

public class UpdatePlayerRequestDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string RealName { get; set; }
    public string GuildRole { get; set; }
    public long CurrentInvestments { get; set; }
    
}