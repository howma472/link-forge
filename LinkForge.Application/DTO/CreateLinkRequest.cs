using System.ComponentModel.DataAnnotations;

namespace LinkForge.Application.DTO;
/// <summary>
/// DTO используется для передачи данных между слоями приложения.
/// 
/// Это позволяет не передавать напрямую сущности базы данных
/// и уменьшает связанность между слоями.
/// </summary>
public class CreateLinkRequest
{
    public string Url { get; set; } = string.Empty;
}