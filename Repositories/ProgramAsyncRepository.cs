using MeFitCase_Assignment.Models.Context;
using MeFitCase_Assignment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeFitCase_Assignment.Repositories;

public class ProgramAsyncRepository : IProgramAsyncRepository
{

    private readonly MeFitPostgreSqlContext _context;

    public ProgramAsyncRepository(MeFitPostgreSqlContext context)
    {
        _context = context;
    }

    public async Task<Models.Domain.Program?> AddAsync(Models.Domain.Program program)
    {
        _context.Programs.Add(program);
        await _context.SaveChangesAsync();

        return program;
    }

    public async Task DeleteByIdAsync(string id)
    {
        var program = await _context.Programs.FirstOrDefaultAsync(p => p.Id == int.Parse(id));
        _context.Programs.Remove(program!);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsWithIdAsync(string id)
    {
        return await _context.Programs.AnyAsync(p => p.Id == int.Parse(id));
    }

    public async Task<IEnumerable<Models.Domain.Program?>> GetAllAsync()
    {
        return await _context.Programs.ToListAsync();
    }

    public async Task<Models.Domain.Program?> GetByIdAsync(string? id)
    {
        return await _context.Programs.FirstOrDefaultAsync(p => p.Id == int.Parse(id));
    }

    public async Task UpdateAsync(Models.Domain.Program program)
    {
        _context.Entry(program).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}