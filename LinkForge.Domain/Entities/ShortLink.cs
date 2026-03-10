using System.ComponentModel.DataAnnotations;

namespace LinkForge.Domain.Entities;

public class ShortLink
{
    public Guid Id { get; set; }
    public string OriginalUrl { get; set; } = string.Empty;
    public string ShortCode { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public int ClickCount { get; set; } = 0;
}