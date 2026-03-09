using AutoMapper;
using LinkForge.Application.DTO;
using LinkForge.Application.Interfaces;

namespace LinkForge.Application.Queries;

public class GetLinkByCodeQuery
{
    private readonly ILinkRepository _repository;
    private readonly IMapper _mapper;

    public GetLinkByCodeQuery(ILinkRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ShortLinkDto?> ExecuteAsync(string code)
    {
        var link = await _repository.GetByCodeAsync(code);

        if (link == null)
            return null;

        return _mapper.Map<ShortLinkDto>(link);
    }
}