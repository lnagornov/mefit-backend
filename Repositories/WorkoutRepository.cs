using MeFitCase_Assignment.Models.Context;
using MeFitCase_Assignment.Models.Domain;
using MeFitCase_Assignment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeFitCase_Assignment.Repositories
{
    public class WorkoutRepository : IWorkoutAsyncRepository, IWorkoutGoalControllerAsyncRepository
    {
        private readonly MeFitPostgreSqlContext _context;

        public WorkoutRepository(MeFitPostgreSqlContext context)
        {
            _context = context;
        }

        public Task<Workout?> AddAsync(Workout entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsWithIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Workout?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        //FROM ASYNCREPO
        public Task<Workout?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get workout by Id for the Workoutgoalcontroller
        /// </summary>
        /// <param name="id">Id of the workout to retrieve</param>
        /// <returns>A workout object</returns>
        public async Task<Workout?> GetByIdAsync(int id)
        {
            return await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<Set>?> GetSetsByWorkoutId(int id)
        {
            return await _context.Sets.Where(s => s.WorkoutId == id).ToListAsync();
        }

        public Task UpdateAsync(Workout entity)
        {
            throw new NotImplementedException();
        }
    }
}
