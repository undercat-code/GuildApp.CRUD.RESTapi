namespace Guild.Application.Players.DTOs.Responses;

public class GetPlayerResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string JoinDate { get; set; }
    public long Investments { get; set; }
    public long JoinGuildInvestments { get; set; }
}