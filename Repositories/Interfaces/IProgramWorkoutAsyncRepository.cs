using MeFitCase_Assignment.Models.Domain;

namespace MeFitCase_Assignment.Repositories.Interfaces;

public interface IProgramWorkoutAsyncRepository : IAsyncRepository<ProgramWorkout>
{
    Task<IEnumerable<ProgramWorkout?>> GetProgramWorkoutsByProgramId(int programId);
}