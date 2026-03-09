using LinkForge.Domain.Entities;

namespace LinkForge.Application.Interfaces;

public interface ILinkRepository
{
    Task<List<ShortLink>> GetAllAsync();
    Task<ShortLink?> GetByCodeAsync(string code);
    Task<ShortLink?> GetByIdAsync(Guid id);
    Task AddAsync (ShortLink link);
    Task UpdateAsync(ShortLink link);
    Task DeleteAsync (Guid id);
}