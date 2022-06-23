namespace MeFitCase_Assignment.Repositories.Interfaces;

public interface IAsyncRepository<T> where T : class
{
    /// <summary>
    /// Get an entity by entity id from the database asynchronously
    /// </summary>
    /// <param name="id">Id of the entity to get</param>
    /// <returns>Task with a result as an entity</returns>
    Task<T?> GetByIdAsync(string id);
    
    /// <summary>
    /// Get all entities from the database asynchronously
    /// </summary>
    /// <returns>Task with a result as a list of entities</returns>
    Task<IEnumerable<T?>> GetAllAsync();
    
    /// <summary>
    /// Checks if the given entity id exists in the database asynchronously
    /// </summary>
    /// <param name="id">Entity id to check</param>
    /// <returns>Task with a result as boolean</returns>
    Task<bool> ExistsWithIdAsync(string id);
    
    /// <summary>
    /// Add an entity to the database asynchronously
    /// </summary>
    /// <param name="entity">Entity to add</param>
    /// <returns>Task with a result as an added entity</returns>
    Task<T?> AddAsync(T entity);
    
    /// <summary>
    /// Update an entity in the database asynchronously
    /// </summary>
    /// <param name="entity">Entity with updated fields</param>
    Task UpdateAsync(T entity);
    
    /// <summary>
    /// Delete an entity from the database asynchronously
    /// </summary>
    /// <param name="id">Entity id to delete entity</param>
    Task DeleteByIdAsync(string id);
}