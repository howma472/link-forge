using System.ComponentModel.DataAnnotations;

namespace LinkForge.Application.DTO;

public class UpdateLinkRequest
{
    
    public Guid Id { get; set; }
    public string OriginalUrl { get; set; } = string.Empty;
}