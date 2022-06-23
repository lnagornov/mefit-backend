using MeFitCase_Assignment.Models.Domain;

namespace MeFitCase_Assignment.Repositories.Interfaces;

public interface IGoalWorkoutAsyncRepository
{
    Task AddGoalWorkoutsAsync(IEnumerable<GoalWorkout> goalWorkouts);
    Task<IEnumerable<GoalWorkout>> GetGoalWorkoutsByGoalIdAsync(int goalId);
    
    Task<GoalWorkout?> GetGoalWorkoutByGoalIdAndWorkoutIdAsync(int goalId, int workoutId);

    Task UpdateAsync(GoalWorkout goalWorkout);
}