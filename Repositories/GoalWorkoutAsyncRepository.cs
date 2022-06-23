using MeFitCase_Assignment.Models.Context;
using MeFitCase_Assignment.Models.Domain;
using MeFitCase_Assignment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeFitCase_Assignment.Repositories;

public class GoalWorkoutAsyncRepository : IGoalWorkoutAsyncRepository
{
    private readonly MeFitPostgreSqlContext _context;

    public GoalWorkoutAsyncRepository(MeFitPostgreSqlContext context)
    {
        _context = context;
    }

    public async Task AddGoalWorkoutsAsync(IEnumerable<GoalWorkout> goalWorkouts)
    {
        await _context.GoalWorkouts.AddRangeAsync(goalWorkouts);
    }

    public async Task<IEnumerable<GoalWorkout>> GetGoalWorkoutsByGoalIdAsync(int goalId)
    {
        return await _context.GoalWorkouts.Where(gw => gw.GoalId == goalId).ToListAsync();
    }

    public async Task<GoalWorkout?> GetGoalWorkoutByGoalIdAndWorkoutIdAsync(int goalId, int workoutId)
    {
        return await _context.GoalWorkouts
            .FirstOrDefaultAsync(gw => gw.GoalId == goalId && gw.WorkoutId == workoutId);
    }

    public async Task UpdateAsync(GoalWorkout goalWorkout)
    {
        _context.Entry(goalWorkout).State = EntityState.Detached;
        _context.Entry(goalWorkout).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}