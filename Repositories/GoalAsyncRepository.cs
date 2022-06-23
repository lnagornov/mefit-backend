using MeFitCase_Assignment.Models.Context;
using MeFitCase_Assignment.Models.Domain;
using MeFitCase_Assignment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeFitCase_Assignment.Repositories;

public class GoalAsyncRepository : IGoalAsyncRepository
{
    private readonly MeFitPostgreSqlContext _context;   
    
    public GoalAsyncRepository(MeFitPostgreSqlContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Get a goal by goal id from the database asynchronously
    /// </summary>
    /// <param name="id">Id of the goal to get</param>
    /// <returns>Task with a result as a goal</returns>
    public async Task<Goal?> GetByIdAsync(string? id)
    {
        return await _context.Goals
            .Include(g => g.GoalWorkouts)
            .FirstOrDefaultAsync(g => g.Id == int.Parse(id));
    }

    /// <summary>
    /// Get all goals from the database asynchronously
    /// </summary>
    /// <returns>Task with a result as a list of goals</returns>
    public async Task<IEnumerable<Goal?>> GetAllAsync()
    {
        return await _context.Goals.Include(g => g.GoalWorkouts).ToListAsync();
    }

    /// <summary>
    /// Checks if the given goal id exists in the database asynchronously
    /// </summary>
    /// <param name="id">Goal id to check</param>
    /// <returns>Task with a result as boolean</returns>
    public async Task<bool> ExistsWithIdAsync(string id)
    {
        return await _context.Goals.AnyAsync(g => g.Id == int.Parse(id));
    }

    /// <summary>
    /// Add a goal to the database asynchronously
    /// </summary>
    /// <param name="goal">Goal to add</param>
    /// <returns>Task with a result as an added goal</returns>
    public async Task<Goal?> AddAsync(Goal goal)
    {
        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();

        return goal;
    }

    /// <summary>
    /// Update a goal in the database asynchronously
    /// </summary>
    /// <param name="goal">Goal with updated fields</param>
    public async Task UpdateAsync(Goal goal)
    {
        _context.Entry(goal).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Delete a goal from the database asynchronously
    /// </summary>
    /// <param name="id">Goal id to delete</param>
    public async Task DeleteByIdAsync(string id)
    {
        var goal = await _context.Goals.FirstOrDefaultAsync(g => g.Id == int.Parse(id));
        _context.Goals.Remove(goal!);
        await _context.SaveChangesAsync();
    }
}