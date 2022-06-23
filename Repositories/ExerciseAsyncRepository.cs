using MeFitCase_Assignment.Models.Context;
using MeFitCase_Assignment.Models.Domain;
using MeFitCase_Assignment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeFitCase_Assignment.Repositories
{
    public class ExerciseAsyncRepository : IExerciseAsyncRepository
    {
        private readonly MeFitPostgreSqlContext _context;

        public ExerciseAsyncRepository(MeFitPostgreSqlContext context)
        {
            _context = context;
        }

        public Task<Exercise?> AddAsync(Exercise entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsWithIdAsync(string id)
        {
            return await _context.Exercises.AnyAsync(e => e.Id == Int32.Parse(id));
        }

        public Task<IEnumerable<Exercise?>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Exercise?> GetByIdAsync(string id)
        {
            return await _context.Exercises.FirstOrDefaultAsync(e => e.Id == Int32.Parse(id));
        }

        public async Task<IEnumerable<Set>> GetSetsByWorkoutId(int workoutId)
        {
            return await _context.Sets.Where(s => s.WorkoutId == workoutId).ToListAsync();
        }

        public Task UpdateAsync(Exercise entity)
        {
            throw new NotImplementedException();
        }
    }
}
