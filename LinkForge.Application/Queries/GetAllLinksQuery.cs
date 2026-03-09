using AutoMapper;
using LinkForge.Application.DTO;
using LinkForge.Application.Interfaces;

namespace LinkForge.Application.Queries;

public class GetAllLinksQuery
{
    private readonly ILinkRepository _repository;
    private readonly IMapper _mapper;

    public GetAllLinksQuery(ILinkRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ShortLinkDto>> ExecuteAsync()
    {
        var links = await _repository.GetAllAsync();

        return _mapper.Map<List<ShortLinkDto>>(links);
    }
}