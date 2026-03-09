namespace LinkForge.Application.DTO;

public class ShortLinkDto
{
    public Guid Id { get; set; }

    public string OriginalUrl { get; set; } = string.Empty;

    public string ShortCode { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    
    public int ClickCount { get; set; }
}