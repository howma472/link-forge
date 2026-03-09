using LinkForge.Application.Interfaces;
using LinkForge.Domain.Entities;
using LinkForge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LinkForge.Infrastructure.Repositories;
/// <summary>
/// Реализация <see cref="ILinkRepository"/> на основе EF Core.
///
/// Репозиторий изолирует слой Application от конкретной реализации
/// хранения данных (EF Core / база данных).
/// Это позволяет менять механизм хранения без изменения бизнес-логики.
/// </summary>
public class LinkRepository : ILinkRepository
{
    private readonly AppDbContext _context;

    public LinkRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ShortLink>> GetAllAsync()
    {
        return await _context.Links.ToListAsync();
    }
    /// <summary>
    /// Получает короткую ссылку по её идентификатору.
    /// </summary>
    public async Task<ShortLink?> GetByIdAsync(Guid id)
    {
        return await _context.Links.FirstOrDefaultAsync(x => x.Id == id);
    }
    /// <summary>
    /// Получает короткую ссылку по её короткому коду.
    /// </summary>
    /// <remarks>
    /// Используется при обработке редиректа,
    /// когда необходимо определить оригинальный URL
    /// по короткому коду из запроса.
    /// </remarks>
    public async Task<ShortLink?> GetByCodeAsync(string code)
    {
        return await _context.Links.FirstOrDefaultAsync(x => x.ShortCode == code);
    }
    /// <summary>
    /// Добавляет новую короткую ссылку в хранилище.
    /// </summary>
    /// <remarks>
    /// После добавления сущность начинает отслеживаться EF Core.
    /// Вызов <see cref="DbContext.SaveChangesAsync"/> фиксирует изменения
    /// в базе данных в рамках текущей операции.
    /// </remarks>
    public async Task AddAsync(ShortLink link)
    {
        await _context.Links.AddAsync(link);
        await _context.SaveChangesAsync();
    }
    /// <summary>
    /// Обновляет существующую короткую ссылку.
    /// </summary>
    public async Task UpdateAsync(ShortLink link)
    {
        _context.Links.Update(link);
        await _context.SaveChangesAsync();
    }
    /// <summary>
    /// Удаляет короткую ссылку по идентификатору.
    /// </summary>
    public async Task DeleteAsync(Guid id)
    {
        var link = await _context.Links.FindAsync(id);
        if (link != null)
        {
            _context.Links.Remove(link);
            await _context.SaveChangesAsync();
        }
    }
    
    
    
}