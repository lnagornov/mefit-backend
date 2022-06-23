using MeFitCase_Assignment.Models.Context;
using MeFitCase_Assignment.Models.Domain;
using MeFitCase_Assignment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeFitCase_Assignment.Repositories;

public class FitnessAttributesAsyncRepository : IFitnessAttributesAsyncRepository
{
    private readonly MeFitPostgreSqlContext _context;
    
    public FitnessAttributesAsyncRepository(MeFitPostgreSqlContext context)
    {
        _context = context;
    }
    public async Task<FitnessAttribute?> GetByIdAsync(string id)
    {
        return await _context.FitnessAttributes
            .FirstOrDefaultAsync(fa => fa.Id == int.Parse(id));
    }

    public async Task<IEnumerable<FitnessAttribute?>> GetAllAsync()
    {
        return await _context.FitnessAttributes
            .ToListAsync();
    }

    public async Task<bool> ExistsWithIdAsync(string id)
    {
        return await _context.FitnessAttributes.AnyAsync(fa => fa.Id == int.Parse(id));
    }

    public async Task<FitnessAttribute?> AddAsync(FitnessAttribute fitnessAttribute)
    {
        _context.FitnessAttributes.Add(fitnessAttribute);
        await _context.SaveChangesAsync();

        return fitnessAttribute;
    }

    public async Task UpdateAsync(FitnessAttribute fitnessAttribute)
    {
        _context.Entry(fitnessAttribute).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(string id)
    {
        var fitnessAttribute = await _context.FitnessAttributes.FirstOrDefaultAsync(fa => fa.Id == int.Parse(id));
        _context.FitnessAttributes.Remove(fitnessAttribute!);
        await _context.SaveChangesAsync();
    }
}