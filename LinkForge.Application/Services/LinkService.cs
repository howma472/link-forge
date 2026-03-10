using AutoMapper;
using LinkForge.Application.DTO;
using LinkForge.Application.Generators;
using LinkForge.Application.Interfaces;
using LinkForge.Domain.Entities;

namespace LinkForge.Application.Services;
/// <summary>
/// Сервис для управления короткими ссылками.
/// Содержит бизнес-логику приложения:
/// создание, получение, обновление, удаление ссылок и подсчет переходов по ним.
/// </summary>
public class LinkService
{
    private readonly ILinkRepository _repository;
    private readonly IMapper _mapper;

    public LinkService(ILinkRepository repository,  IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ShortLinkDto?> GetByIdAsync(Guid id)
    {
        var link = await _repository.GetByIdAsync(id);

        if (link == null)
            return null;

        return _mapper.Map<ShortLinkDto>(link);
    }
    public async Task<List<ShortLinkDto>> GetAllAsync()
    {
        var links = await _repository.GetAllAsync();

        return _mapper.Map<List<ShortLinkDto>>(links);
    }
    public async Task<ShortLinkDto?> GetByCodeAsync(string code)
    {
        var link = await _repository.GetByCodeAsync(code);

        if (link == null)
            return null;

        return _mapper.Map<ShortLinkDto>(link);
    }
    
    public async Task CreateAsync(CreateLinkRequestDto requestDto)
    {
        var link = new ShortLink
        {
            Id = Guid.NewGuid(),
            OriginalUrl = requestDto.Url,
            ShortCode = ShortCodeGenerator.Generate(),
            CreatedAt = DateTime.UtcNow,
            ClickCount = 0
        };

        await _repository.AddAsync(link);
    }

    public async Task UpdateAsync(UpdateLinkRequestDto requestDto)
    {
        var link = await _repository.GetByIdAsync(requestDto.Id);

        if (link == null)
            return;

        link.OriginalUrl = requestDto.OriginalUrl;

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