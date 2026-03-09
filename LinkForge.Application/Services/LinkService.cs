using LinkForge.Application.DTO;
using LinkForge.Application.Generators;
using LinkForge.Application.Interfaces;
using LinkForge.Domain.Entities;

namespace LinkForge.Application.Services;

public class LinkService
{
    private readonly ILinkRepository _repository;

    public LinkService(ILinkRepository repository)
    {
        _repository = repository;
    }
    
    public async Task CreateAsync(CreateLinkRequest request)
    {
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
        var link = await _repository.GetByIdAsync(request.Id);

        if (link == null)
            return;

        link.OriginalUrl = request.OriginalUrl;

        await _repository.UpdateAsync(link);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task IncrementClickAsync(Guid id)
    {
        var link = await _repository.GetByIdAsync(id);

        if (link == null)
            return;

        link.ClickCount++;

        await _repository.UpdateAsync(link);
    }
    
}