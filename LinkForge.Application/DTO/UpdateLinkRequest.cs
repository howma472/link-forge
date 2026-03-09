using System.ComponentModel.DataAnnotations;

namespace LinkForge.Application.DTO;

public class UpdateLinkRequest
{
    
    public Guid Id { get; set; }
    [Required]
    [MaxLength(2000)]
    public string OriginalUrl { get; set; } = string.Empty;
}