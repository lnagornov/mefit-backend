using MeFitCase_Assignment.Models.Context;
using MeFitCase_Assignment.Models.Domain;
using MeFitCase_Assignment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeFitCase_Assignment.Repositories;

public class ProfileAsyncRepository : IProfileAsyncRepository, ILoginAsyncRepository
{
    private readonly MeFitPostgreSqlContext _context;

    public ProfileAsyncRepository(MeFitPostgreSqlContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Get a profile by profile id from the database asynchronously
    /// </summary>
    /// <param name="programId">Id of the profile to get profile</param>
    /// <returns>Task with a result as a profile</returns>
    public async Task<Profile?> GetByIdAsync(string? programId)
    {
        return await _context.Profiles
            .Include(p => p.Address)
            .Include(p => p.FitnessAttributes)
            .Include(p => p.Goal)
            .FirstOrDefaultAsync(profile => profile.Id == int.Parse(programId));
    }

    /// <summary>
    /// Get a profile by user id from the database asynchronously
    /// </summary>
    /// <param name="userId">Id of the user to get profile for</param>
    /// <returns>Task with a result as a profile</returns>
    public async Task<Profile?> GetByUserIdAsync(string userId)
    {
        return await _context.Profiles
            .Include(m => m.Address)
            .Include(m => m.FitnessAttributes)
            .Include(p => p.Goal)
            .FirstOrDefaultAsync(profile => profile.KeycloakId == userId);
    }

    /// <summary>
    /// Get all profiles from the database asynchronously
    /// </summary>
    /// <returns>Task with a result as a list of profiles</returns>
    public async Task<IEnumerable<Profile?>> GetAllAsync()
    {
        return await _context.Profiles
            .Include(m => m.Address)
            .Include(m => m.FitnessAttributes)
            .Include(p => p.Goal)
            .ToListAsync();
    }

    /// <summary>
    /// Checks if the given profile id exists in the database asynchronously
    /// </summary>
    /// <param name="userId">Profile id to check</param>
    /// <returns>Task with a result as boolean</returns>
    public async Task<bool> ExistsWithIdAsync(string userId)
    {
        return await _context.Profiles.AnyAsync(profile => profile.KeycloakId == userId);
    }

    /// <summary>
    /// Add a profile to the database asynchronously
    /// </summary>
    /// <param name="profile">Profile to add</param>
    /// <returns>Task with a result as an added profile</returns>
    public async Task<Profile?> AddAsync(Profile profile)
    {
        _context.Profiles.Add(profile);
        await _context.SaveChangesAsync();

        return profile;
    }

    /// <summary>
    /// Update a profile in the database asynchronously
    /// </summary>
    /// <param name="profile">Profile with updated fields</param>
    public async Task UpdateAsync(Profile profile)
    {
        _context.Entry(profile).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Delete a profile from the database asynchronously
    /// </summary>
    /// <param name="userId">User id to delete profile of</param>
    public async Task DeleteByIdAsync(string userId)
    {
        var profile = await _context.Profiles.FirstOrDefaultAsync(profile => profile.KeycloakId == userId);
        _context.Profiles.Remove(profile!);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Context searching the Profiles table for an existing profile based on the id given by Keycloak.
    /// If A profile exists it is returned.
    /// Otherwise a new one is created with accompanying Address and FitnessAttribute entities.
    /// The new Profile is then updated with their FK's and added to the database before being returned
    /// </summary>
    /// <param name="id">The user id given by Keycloak</param>
    /// <returns>A profile from the database</returns>
    public async Task<Profile> LoginAsync(string id)
    {
        try
        {
            var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.KeycloakId == id);
            if (profile != null) return profile;

            Address address = new Address();
            var newAddress = await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            FitnessAttribute fitnessAttribute = new FitnessAttribute();
            var newFitnessAttribute = await _context.FitnessAttributes.AddAsync(fitnessAttribute);
            await _context.SaveChangesAsync();

            profile = new Profile
            {
                KeycloakId = id,
                AddressId = newAddress.Entity.Id,
                FitnessAttributesId = newFitnessAttribute.Entity.Id,

            };
            
            await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();
            
            return profile;
        }
        catch (ArgumentNullException nullEx)
        {
            Console.WriteLine(nullEx);
            throw;
        }
    }

    /// <summary>
    /// Updates the given profile with a new goal id
    /// </summary>
    /// <param name="profile">The profile to update</param>
    /// <param name="goalId">The id of the new goal to be added to this profile</param>
    /// <returns>void</returns>
    public async Task UpdateProfileWithGoalIdAsync(Profile profile, int goalId)
    {
        profile.GoalId = goalId;
        _context.Entry(profile).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}