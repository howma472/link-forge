using System.ComponentModel.DataAnnotations;

namespace LinkForge.Application.DTO;

public class UpdateLinkRequestDto
{
    
    public Guid Id { get; set; }
    public string OriginalUrl { get; set; } = string.Empty;
}