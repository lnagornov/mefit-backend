using MeFitCase_Assignment.Models.Domain;

namespace MeFitCase_Assignment.Repositories.Interfaces;

public interface ILoginAsyncRepository
{
    Task<Profile> LoginAsync(string id);
}