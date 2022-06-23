using MeFitCase_Assignment.Models.Domain;

namespace MeFitCase_Assignment.Repositories.Interfaces
{
    public interface IExerciseAsyncRepository:IAsyncRepository<Exercise>
    {
        Task<IEnumerable<Set>>GetSetsByWorkoutId(int workoutId);
    }
}
