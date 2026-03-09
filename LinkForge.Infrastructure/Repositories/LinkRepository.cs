using LinkForge.Application.Interfaces;
using LinkForge.Domain.Entities;
using LinkForge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LinkForge.Infrastructure.Repositories;

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
    
    public async Task<ShortLink?> GetByIdAsync(Guid id)
    {
        return await _context.Links.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ShortLink?> GetByCodeAsync(string code)
    {
        return await _context.Links.FirstOrDefaultAsync(x => x.ShortCode == code);
    }

    public async Task AddAsync(ShortLink link)
    {
        await _context.Links.AddAsync(link);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(ShortLink link)
    {
        _context.Links.Update(link);
        await _context.SaveChangesAsync();
    }

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