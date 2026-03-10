using System.ComponentModel.DataAnnotations;

namespace LinkForge.Application.DTO;

public class CreateLinkRequestDto
{
    public string Url { get; set; } = string.Empty;
}