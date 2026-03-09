using AutoMapper;
using LinkForge.Application.DTO;
using LinkForge.Application.Interfaces;

namespace LinkForge.Application.Queries;

public class GetLinkByIdQuery
{
    private readonly ILinkRepository _repository;
    private readonly IMapper _mapper;

    public GetLinkByIdQuery(ILinkRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<ShortLinkDto?> ExecuteAsync(Guid id)
    {
        var link = await _repository.GetByIdAsync(id);

        if (link == null)
            return null;

        return _mapper.Map<ShortLinkDto>(link);
    }
}