using MeFitCase_Assignment.Models.Domain;

namespace MeFitCase_Assignment.Repositories.Interfaces;

public interface IProfileAsyncRepository : IAsyncRepository<Profile>
{
    Task<Profile?> GetByUserIdAsync(string userId);
    Task UpdateProfileWithGoalIdAsync(Profile profile, int goalId);
}