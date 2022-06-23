using MeFitCase_Assignment.Models.Domain;

namespace MeFitCase_Assignment.Repositories.Interfaces
{
    public interface IWorkoutGoalControllerAsyncRepository
    {
        Task<Workout?> GetByIdAsync(int id);
        Task<IEnumerable<Set>?> GetSetsByWorkoutId(int id);
    }
}
