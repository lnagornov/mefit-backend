using MeFitCase_Assignment.Models.Context;
using MeFitCase_Assignment.Models.Domain;
using MeFitCase_Assignment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeFitCase_Assignment.Repositories;

public class ProgramWorkoutAsyncRepository : IProgramWorkoutAsyncRepository
{
    private readonly MeFitPostgreSqlContext _context;

    public ProgramWorkoutAsyncRepository(MeFitPostgreSqlContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Add a Program-Workout to the database asynchronously
    /// </summary>
    /// <param name="programWorkout">Program-Workout to add</param>
    /// <returns>Task with a result as an added goal</returns>
    public async Task<ProgramWorkout?> AddAsync(ProgramWorkout programWorkout)
    {
        _context.ProgramWorkouts.Add(programWorkout);
        await _context.SaveChangesAsync();

        return programWorkout;
    }

    /// <summary>
    /// Delete a program-workout from the database asynchronously
    /// </summary>
    /// <param name="id">program-workout id to delete</param>
    public async Task DeleteByIdAsync(string id)
    {
        var programWorkout = await _context.ProgramWorkouts.FirstOrDefaultAsync(pw => pw.Id == int.Parse(id));
        _context.ProgramWorkouts.Remove(programWorkout!);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Checks if the given program-workout id exists in the database asynchronously
    /// </summary>
    /// <param name="id">program-workout id to check</param>
    /// <returns>Task with a result as boolean</returns>
    public async Task<bool> ExistsWithIdAsync(string id)
    {
        return await _context.ProgramWorkouts.AnyAsync(pw => pw.Id == int.Parse(id));
    }

    /// <summary>
    /// Get all pairs of program-workout from the database asynchronously
    /// </summary>
    /// <returns>Task with a result as a list of program-workout pairs</returns>

    public async Task<IEnumerable<ProgramWorkout?>> GetAllAsync()
    {
        return await _context.ProgramWorkouts.ToListAsync();
    }


    /// <summary>
    /// Get a program-workout by program-workout id from the database asynchronously
    /// </summary>
    /// <param name="id">Id of the program-workout to get</param>
    /// <returns>Task with a result as a program-workout</returns>
    public async Task<ProgramWorkout?> GetByIdAsync(string? id)
    {
        return await _context.ProgramWorkouts.FirstOrDefaultAsync(pw => pw.Id == int.Parse(id));

    }

    /// <summary>
    /// Get program-workout by program id
    /// </summary>
    /// <param name="programId">program id of the program-workout to retrieve</param>
    /// <returns>a list of program-workout pairs</returns>
    public async Task<IEnumerable<ProgramWorkout?>> GetProgramWorkoutsByProgramId(int programId)
    {
        return await _context.ProgramWorkouts.Where(pw => pw.ProgramId == programId).ToListAsync();
    }

    /// <summary>
    /// Update a program-workout in the database asynchronously
    /// </summary>
    /// <param name="programWorkout">Program-Workout with updated fields</param>
    public async Task UpdateAsync(ProgramWorkout programWorkout)
    {
        _context.Entry(programWorkout).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}