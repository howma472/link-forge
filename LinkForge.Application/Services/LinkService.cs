using LinkForge.Application.DTO;
using LinkForge.Application.Generators;
using LinkForge.Application.Interfaces;
using LinkForge.Application.Validators;
using LinkForge.Domain.Entities;

namespace LinkForge.Application.Services;
/// <summary>
/// Сервис бизнес-логики для работы с сокращёнными ссылками.
/// 
/// Этот слой используется для изоляции бизнес-логики от
/// контроллеров и инфраструктуры (базы данных).
/// 
/// Благодаря этому можно тестировать логику без подключения
/// к реальной базе данных.
/// </summary>
public class LinkService
{
    private readonly ILinkRepository _repository;

    public LinkService(ILinkRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ShortLink>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<ShortLink?> GetByCodeAsync(string code)
    {
        return await _repository.GetByCodeAsync(code);
    }

    public async Task CreateAsync(CreateLinkRequest request)
    {
        if (!UrlValidator.IsValid(request.Url))
            throw new Exception("Invalid URL");

        var link = new ShortLink
        {
            Id = Guid.NewGuid(),
            OriginalUrl = request.Url,
            ShortCode = ShortCodeGenerator.Generate(),
            CreatedAt = DateTime.UtcNow,
            ClickCount = 0
        };

        await _repository.AddAsync(link);
    }

    public async Task UpdateAsync(UpdateLinkRequest request)
    {
        if (!UrlValidator.IsValid(request.OriginalUrl))
            throw new Exception("Invalid URL");

        var link = await _repository.GetByIdAsync(request.Id);

        if (link == null)
            throw new Exception("Link not found");

        link.OriginalUrl = request.OriginalUrl;

        await _repository.UpdateAsync(link);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}